using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Biblioteca_Común;
using System.Xml;
using System.Collections;
using System.Configuration;
using System.Timers;
using DevExpress.XtraBars.Alerter;
using System.Threading;

namespace Aplicación_de_Escritorio
{
    public partial class FormBase : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static FormBase instancia = null;
        public static FormBase Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new FormBase();
                return instancia;
            }

            set
            {
                instancia = value;
            }
        }
        public static bool Instanciado
        {
            get { return instancia != null; }
        }

        /// <summary>
        /// Instancia del formulario para evitar tiempos de espera.
        /// Así, puede ir actualizándose el formulario incluso cuando no se muestra.
        /// </summary>
        public FormVerSolicitudes FormVerSolicitudes;
        public FormHistorialCompras FormHistorialCompras;
        public FormVerEmpleados FormVerEmpleados;
        public FormChat FormChat;
        public FormRegistro FormRegistro;
        public FormConfiguracion FormConfiguracion;

        /// <summary>
        /// Mantiene la secuencia de cómo se mostraron los formularios para poder retroceder de un formulario al anterior.
        /// </summary>
        private ArrayList anteriores;
        private ArrayList siguientes;

        /// <summary>
        /// Es el consumidor que se ejecuta en otro hilo, recibiendo los mensajes y procesándolos.
        /// </summary>
        private Consumidor consumidorSolicitudes;

        /// <summary>
        /// Crea un objeto ENSolicitud (clase obtenida desde el servicio web) a partir de una cadena Xml.
        ///  Habrá que mantener este método conforme modifica ENSolicitud.
        /// </summary>
        /// <param name="xml">Cadena que contiene el Xml.</param>
        /// <returns>Devuelve la solicitud con el valor de los parámetros según el Xml recibido.</returns>
        private static SGC.ENSolicitud CreateENSolicitudFromXML(String xml)
        {
            SGC.ENSolicitud solicitud = new SGC.ENSolicitud();

            // Se crea el documento Xml.
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);

            // Se parsea la entrada.
            XmlNode nodo = xmlDocument.FirstChild.NextSibling.ChildNodes.Item(0);
            while (nodo != null)
            {
                switch (nodo.Name)
                {
                    case "Id":
                    {
                        solicitud.Id = int.Parse(nodo.InnerText);
                        break;
                    }
                    case "IdCliente":
                    {
                        solicitud.IdCliente = int.Parse(nodo.InnerText);
                        break;
                    }
                    case "Descripcion":
                    {
                        solicitud.Descripcion = nodo.InnerText;
                        break;
                    }
                    case "Estado":
                    {
                        solicitud.Estado = (SGC.ENEstadosPieza) Enum.Parse(typeof(SGC.ENEstadosPieza), nodo.InnerText);
                        break;
                    }
                    case "Fecha":
                    {
                        solicitud.Fecha = DateTime.Parse(nodo.InnerText);
                        break;
                    }
                    case "FechaEntrega":
                    {
                        solicitud.FechaEntrega = DateTime.Parse(nodo.InnerText);
                        break;
                    }
                    case "FechaRespuesta":
                    {
                        solicitud.FechaRespuesta = DateTime.Parse(nodo.InnerText);
                        break;
                    }
                    case "NegociadoAutomatico":
                    {
                        solicitud.NegociadoAutomatico = nodo.InnerText.Equals("true") ? true : false;
                        break;
                    }
                    case "PrecioMax":
                    {
                        solicitud.PrecioMax = float.Parse(nodo.InnerText.Replace(".", ","));
                        break;
                    }
                }
                nodo = nodo.NextSibling;
            }

            return solicitud;
        }

        private FormBase()
        {
            InitializeComponent();

            FormVerSolicitudes = new FormVerSolicitudes();
            FormHistorialCompras = new FormHistorialCompras();
            FormVerEmpleados = new FormVerEmpleados();
            FormChat = new FormChat();
            FormRegistro = new FormRegistro();
            FormConfiguracion = new FormConfiguracion();
            anteriores = new ArrayList();
            siguientes = new ArrayList();

            // Nombre de usuario en la barra de estado.
            barStaticItemEmpleado.Caption = Program.EmpleadoIdentificado.Usuario;

            // Mostramos o ocultamos según seamos administrador o no.
            if (Program.EmpleadoIdentificado.Administrador)
            {
                // Se introducen los botones referentes a los empleados en un único menú desplegable.
                // Desde el diseñador no se puede hacer, por lo que salen todos visibles.
                this.barLinkContainerItemEmpleados.AddItem(this.barButtonItemVerEmpleados);
                this.barLinkContainerItemEmpleados.AddItem(this.barButtonItemAnadirEmpleado);
                this.barLinkContainerItemEmpleados.AddItem(this.barButtonItemAnadirAdministrador);
                this.ribbonPageGroupPreferencias.ItemLinks.Remove(this.barButtonItemVerEmpleados);
                this.ribbonPageGroupPreferencias.ItemLinks.Remove(this.barButtonItemAnadirEmpleado);
                this.ribbonPageGroupPreferencias.ItemLinks.Remove(this.barButtonItemAnadirAdministrador);
            }
            else
            {
                // Se elimina todo y sólo de muestra "Ver empleados", sin poder añadirlos.
                this.ribbonPageGroupPreferencias.ItemLinks.Remove(this.barLinkContainerItemEmpleados);
                this.ribbonPageGroupPreferencias.ItemLinks.Remove(this.barButtonItemAnadirEmpleado);
                this.ribbonPageGroupPreferencias.ItemLinks.Remove(this.barButtonItemAnadirAdministrador);

                // Ocultamos también el botón para modificar la configuración del sistema.
                this.ribbonPageGroupPreferencias.ItemLinks.Remove(this.barButtonItemConfiguracion);
            }

            // Realizamos las acciones pertinentes según el perfil del empleado (normal o administrador) y según el tipo de aplicación (taller o desguace).
            if (Program.TipoAplicacion == Program.TiposAplicacion.DESGUACE)
            {
                // Se crea el consumidor de solicitudes y se arranca el hilo que consultará cada cierto tiempo el "topic" para ver si hay nuevas solicides.
                consumidorSolicitudes = new Consumidor();
                consumidorSolicitudes.Conectar(Configuracion.Default.activemq, Configuracion.Default.topic);
                timerConsumirSolicitudes.Start();

                // Se oculta el botón de "solicitar pieza".
                barButtonItemSolicitar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItemHistorialCompras.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                // Cambiamos la barra de título.
                Text = "Aplicación de Desguace - Criludage";
            }
            else
            {
                // Se arranca el temporizador que comprueba si hay nuevas propuestas para las solicitudes.
                timerSolicitudesFinalizadas.Start();

                // Cambiamos la barra de título.
                Text = "Aplicación de Taller - Criludage";
            }
            notifyIcon.Text = Text;

            // Traemos la aplicación al frente.
            BringToFront();
            Activate();
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            MostrarVerSolicitudes();
        }

        private void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show("¿Está seguro de que desea salir?", "Saliendo de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                Program.InicioSesion = false;
            }
            else
            {
                if (consumidorSolicitudes != null)
                    consumidorSolicitudes.Desconectar();
                timerConsumirSolicitudes.Stop();
                timerSolicitudesFinalizadas.Stop();
                notifyIcon.Visible = false;
                Registro.WriteLine("Cerrada la sesión: " + Program.EmpleadoIdentificado.Usuario);
            }
        }

        /// <summary>
        /// Muestra la vista de solicitudes.
        /// Sólo hay una vista, por lo que no se crea cada vez que se muestra.
        /// </summary>
        public void MostrarVerSolicitudes()
        {
            // Si ya se está mostrando "VerSolicitudes", no lo volvemos a mostrar.
            if (panelContenido.Controls.Count > 0 && panelContenido.Controls[0] is FormVerSolicitudes)
                return;
            Mostrar(FormVerSolicitudes);
        }

        /// <summary>
        /// Muestra la vista de solicitudes.
        /// Sólo hay una vista, por lo que no se crea cada vez que se muestra.
        /// </summary>
        public void MostrarHistorialCompras()
        {
            // Si ya se está mostrando "VerSolicitudes", no lo volvemos a mostrar.
            if (panelContenido.Controls.Count > 0 && panelContenido.Controls[0] is FormHistorialCompras)
                return;
            Mostrar(FormHistorialCompras);
        }

        /// <summary>
        /// Muestra los empleados.
        /// Sólo hay una vista, por lo que no se crea cada vez que se muestra.
        /// </summary>
        public void MostrarVerEmpleados()
        {
            // Si ya se está mostrando "VerEmpleados", no lo volvemos a mostrar.
            if (panelContenido.Controls.Count > 0 && panelContenido.Controls[0] is FormVerEmpleados)
                return;
            Mostrar(FormVerEmpleados);
        }

        /// <summary>
        /// Muestra la ventana de chat.
        /// Sólo hay una vista, por lo que no se crea cada vez que se muestra.
        /// </summary>
        public void MostrarChat()
        {
            // Si ya se está mostrando "Chat", no lo volvemos a mostrar.
            if (panelContenido.Controls.Count > 0 && panelContenido.Controls[0] is FormChat)
                return;
            Mostrar(FormChat);
        }

        /// <summary>
        /// Muestra la ventana de registro de log.
        /// Sólo hay una vista, por lo que no se crea cada vez que se muestra.
        /// </summary>
        public void MostrarRegistro()
        {
            // Si ya se está mostrando "Registro", no lo volvemos a mostrar.
            if (panelContenido.Controls.Count > 0 && panelContenido.Controls[0] is FormRegistro)
                return;
            Mostrar(FormRegistro);
        }

        /// <summary>
        /// Muestra la ventana de configuración.
        /// Sólo hay una vista, por lo que no se crea cada vez que se muestra.
        /// </summary>
        public void MostrarConfiguracion()
        {
            // Si ya se está mostrando "Configuracion", no lo volvemos a mostrar.
            if (panelContenido.Controls.Count > 0 && panelContenido.Controls[0] is FormConfiguracion)
                return;
            Mostrar(FormConfiguracion);
        }

        /// <summary>
        /// Muestra el formulario para solicitar una pieza.
        /// </summary>
        public void MostrarSolicitarPieza()
        {
            // Si ya se está mostrando "SolicitarPieza", no lo volvemos a mostrar.
            if (panelContenido.Controls.Count > 0 && panelContenido.Controls[0] is FormSolicitarPieza)
                return;
            Mostrar(new FormSolicitarPieza());
        }

        /// <summary>
        /// Muestra el panel para añadir un empleado.
        /// </summary>
        public void MostrarAnadirEmpleado(bool administrador)
        {
            // Si ya se está mostrando "AnadirEmpleado", sólo cambiamos el modo.
            if (panelContenido.Controls.Count > 0 && panelContenido.Controls[0] is FormAnadirEmpleado)
            {
                ((FormAnadirEmpleado) panelContenido.Controls[0]).Modo(administrador);
                return;
            }
            Mostrar(new FormAnadirEmpleado(administrador));
        }

        /// <summary>
        /// Muestra el panel para editar un empleado.
        /// </summary>
        public void MostrarEditarEmpleado(Empleado empleado)
        {
            // Si ya se está mostrando "EditarEmpleado", sólo cargamos el empleado.
            if (panelContenido.Controls.Count > 0 && panelContenido.Controls[0] is FormEditarEmpleado)
            {
                ((FormEditarEmpleado) panelContenido.Controls[0]).CargarEmpleado(empleado);
                return;
            }
            Mostrar(new FormEditarEmpleado(empleado));
        }

        /// <summary>
        /// Muestra el panel para ver un empleado.
        /// </summary>
        public void MostrarVerEmpleado(Empleado empleado)
        {
            // Si el empleado es administrador, mostramos directamente "EditarEmpleado".
            if (Program.EmpleadoIdentificado.Administrador || empleado.Id == Program.EmpleadoIdentificado.Id)
            {
                MostrarEditarEmpleado(empleado);
                return;
            }

            // Si ya se está mostrando "VerEmpleado", sólo cargamos el empleado.
            if (panelContenido.Controls.Count > 0 && panelContenido.Controls[0] is FormVerEmpleado)
            {
                ((FormVerEmpleado)panelContenido.Controls[0]).CargarEmpleado(empleado);
                return;
            }
            Mostrar(new FormVerEmpleado(empleado));
        }

        /// <summary>
        /// Muestra el panel para ver un cliente.
        /// </summary>
        public void MostrarVerClienteDesguace(Cliente cliente)
        {
            Mostrar(new FormVerClienteDesguace(cliente));
        }

        /// <summary>
        /// Muestra el panel para ver un desguace.
        /// </summary>
        public void MostrarVerClienteDesguace(Desguace desguace)
        {
            Mostrar(new FormVerClienteDesguace(desguace));
        }

        /// <summary>
        /// Muestra el panel para añadir una solicitud.
        /// </summary>
        public void MostrarVerSolicitud(Solicitud solicitud)
        {
            Mostrar(new FormVerSolicitud(solicitud));
        }

        /// <summary>
        /// Muestra el panel para añadir una propuesta.
        /// </summary>
        public void MostrarVerPropuesta(Propuesta propuesta)
        {
            Mostrar(new FormVerPropuesta(propuesta));
        }

        /// <summary>
        /// Muestra el panel para proponer una propuesta.
        /// </summary>
        /// <param name="solicitud">Solicitud a la que va referida la propuesta.</param>
        public void MostrarProponerPropuesta(Solicitud solicitud)
        {
            // Si ya se está mostrando "ProponerPropuesta", sólo cargamos la solicitud referida.
            if (panelContenido.Controls.Count > 0 && panelContenido.Controls[0] is FormProponerPropuesta)
            {
                ((FormProponerPropuesta) panelContenido.Controls[0]).CargarSolicitud(solicitud);
                return;
            }
            Mostrar(new FormProponerPropuesta(solicitud));
        }

        /// <summary>
        /// Muestra el UserControl en el panel principal.
        /// </summary>
        /// <param name="userControl"></param>
        private void Mostrar(UserControl userControl)
        {
            // Se extrae el panel actual y se inserta el nuevo.
            UserControl actual = (panelContenido.Controls.Count > 0) ? (UserControl) panelContenido.Controls[0] : null;
            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(userControl);
            barButtonItemCerrar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            // Sólo se introduce el panel en los "anteriores" si el último introducido en "anteriores" no ha sido éste.
            if (actual != null)
            {
                anteriores.Add(actual);
            }

            // Se limpian los "siguientes" porque se ha introducido un nuevo elemento.
            siguientes.Clear();
            barButtonItemSiguiente.Enabled = false;
            barButtonItemAnterior.Enabled = anteriores.Count > 0;
        }

        /// <summary>
        /// Muestra el último panel mostrado antes que el actual.
        /// </summary>
        public void MostrarAnterior()
        {
            // Se quita el panel actual y se inserta en "siguientes".
            if (panelContenido.Controls.Count > 0)
            {
                UserControl actual = (UserControl)panelContenido.Controls[0];
                siguientes.Add(actual);
                panelContenido.Controls.Clear();
                barButtonItemSiguiente.Enabled = true;
            }

            // Si hay elementos en "anteriores", se muestra el último en el panel principal.
            if (anteriores.Count > 0)
            {
                panelContenido.Controls.Add((UserControl) anteriores[anteriores.Count - 1]);
                barButtonItemCerrar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                anteriores.RemoveAt(anteriores.Count - 1);
            }

            // Comprobamos si quedan "anteriores" para activar o desactivar el botón.
            barButtonItemAnterior.Enabled = anteriores.Count > 0;
        }

        /// <summary>
        /// Muestra el panel que se mostró después que el actual.
        /// </summary>
        public void MostrarSiguiente()
        {
            // Se quita el panel actual y se inserta en "anteriores".
            if (panelContenido.Controls.Count > 0)
            {
                UserControl actual = (UserControl)panelContenido.Controls[0];
                anteriores.Add(actual);
                panelContenido.Controls.Clear();
                barButtonItemAnterior.Enabled = true;
            }

            // Si hay elementos en "siguientes", se muestra el último en el panel principal.
            if (siguientes.Count > 0)
            {
                panelContenido.Controls.Add((UserControl) siguientes[siguientes.Count - 1]);
                barButtonItemCerrar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                siguientes.RemoveAt(siguientes.Count - 1);
            }

            // Comprobamos si quedan "anteriores" para activar o desactivar el botón.
            barButtonItemSiguiente.Enabled = siguientes.Count > 0;
        }

        /// <summary>
        /// Oculta el UserControl que se esté mostrando actualmente y deja el panel principal vacío.
        /// Este método no apila ni desapila el control en "anteriores" o "siguientes".
        /// </summary>
        public void MostrarNinguno()
        {
            barButtonItemCerrar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            panelContenido.Controls.Clear();
        }

        /// <summary>
        /// Muestra un mensaje que se desvanece con el tiempo.
        /// Ejemplo: MostrarMensaje("Solicitudes archivadas", "Todavía no se ha implementado este módulo.");
        /// </summary>
        /// <param name="titulo">Título para el mensaje. Por ejemplo "Solicitud recibida".</param>
        /// <param name="mensaje">Mensaje descriptivo.</param>
        public void MostrarMensaje(String titulo, String mensaje)
        {
            alertControl.Show(this, titulo, mensaje);
        }

        /// <summary>
        /// Muestra una solicitud recibida recientemente en un popup.
        /// </summary>
        /// <param name="solicitud">Solicitud que se va a mostrar.</param>
        public void MostrarSolicitud(Solicitud solicitud)
        {
            AlertInfo info = new AlertInfo("Solicitud recibida", solicitud.Descripcion);
            info.Tag = solicitud;
            alertControlSolicitudes.Show(this, info);
        }

        /// <summary>
        /// Muestra una solicitud que ha recibido sus propuestas recientemente.
        /// </summary>
        /// <param name="solicitud">Solicitud que se va a mostrar.</param>
        public void MostrarPropuestas(Solicitud solicitud)
        {
            AlertInfo info = new AlertInfo("Solicitud nº " + solicitud.Id + " finalizada", "Se han recibido " + solicitud.ObtenerPropuestas().Count + " propuestas");
            info.Tag = solicitud;
            alertControlSolicitudes.Show(this, info);
        }

        /// <summary>
        /// Se recorren todas las páginas del historial de navegación y las que coincidan con FormVerSolicitud se actualizan.
        /// </summary>
        /// <param name="solicitud">Solicitud que se quiere actualizar.</param>
        public void ActualizarSolicitud(Solicitud solicitud)
        {
            // Se actualizan los FormVerSolicitud que tengan cargada la solicitud que acaba de finalizar.
            ArrayList navegacion = new ArrayList(anteriores);
            navegacion.AddRange(siguientes);
            foreach (UserControl k in navegacion)
                if (k is FormVerSolicitud)
                    ((FormVerSolicitud)k).ActualizarSolicitud(solicitud);
        }

        /// <summary>
        /// Se recorren todas las páginas del historial de navegación y las que coincidan con FormVerPropuesta se actualizan.
        /// </summary>
        /// <param name="solicitud">Solicitud que se quiere actualizar.</param>
        public void ActualizarPropuesta(Propuesta propuesta)
        {
            // Se actualizan los FormVerSolicitud que tengan cargada la solicitud que acaba de finalizar.
            ArrayList navegacion = new ArrayList(anteriores);
            navegacion.AddRange(siguientes);
            foreach (UserControl k in navegacion)
                if (k is FormVerPropuesta)
                    ((FormVerPropuesta)k).ActualizarPropuesta(propuesta);
        }

        /// <summary>
        /// Se recorren todas las páginas del historial de navegación y las que tengan el empleado cargado se actualizan.
        /// </summary>
        /// <param name="empleado">Empleado que se quiere actualizar.</param>
        /// <param name="eliminado">Indica si el empleado ha sido borrado o sólo modificado.</param>
        public void ActualizarEmpleado(Empleado empleado, bool eliminado)
        {
            // Se actualizan los FormVerSolicitud que tengan cargada la solicitud que acaba de finalizar.
            ArrayList navegacion = new ArrayList(anteriores);
            navegacion.AddRange(siguientes);
            foreach (UserControl k in navegacion)
            {
                if (k is FormVerSolicitud)
                {
                    ((FormVerSolicitud)k).ActualizarEmpleado(empleado);
                }
                else if (k is FormVerPropuesta)
                {
                    ((FormVerPropuesta)k).ActualizarEmpleado(empleado);
                }
                else if (k is FormEditarEmpleado)
                {
                    ((FormEditarEmpleado)k).ActualizarEmpleado(empleado, eliminado);
                }
            }
        }

        private void barButtonItemSolicitar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarSolicitarPieza();
        }

        private void barButtonItemVerSolicitudes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarVerSolicitudes();
        }

        private void barButtonItemVerEmpleados_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarVerEmpleados();
        }

        private void barButtonItemAnadirEmpleado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarAnadirEmpleado(false);
        }

        private void barButtonItemAnadirAdministrador_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarAnadirEmpleado(true);
        }

        private void barButtonItemAnterior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarAnterior();
        }

        private void barButtonItemSiguiente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarSiguiente();
        }

        private void barButtonItemSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItemCerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarNinguno();
            if (siguientes.Count > 0)
                MostrarSiguiente();
            else
                MostrarAnterior();
        }

        private void barButtonItemCerrarSesion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Indicamos que sólo queremos volver a la ventana de inicio de sesión.
            Program.InicioSesion = true;
            Close();
        }

        private void barButtonItemChat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarChat();
        }

        private void barButtonItemVer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarRegistro();
        }

        private void barButtonItemPerfil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarEditarEmpleado(Program.EmpleadoIdentificado);
        }

        private void barButtonItemAcercaDe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new FormAcercaDe().Show();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Visible = !Visible;
            if (Visible)
            {
                BringToFront();
                Activate();
            }
        }

        private void barButtonItemMinimizarBandeja_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Visible = false;
        }

        private void toolStripMenuItemSalir_Click(object sender, EventArgs e)
        {
            barButtonItemSalir_ItemClick(null, null);
        }

        private void toolStripMenuItemAbrirAplicacion_Click(object sender, EventArgs e)
        {
            Visible = true;
            BringToFront();
            Activate();
        }

        private void toolStripMenuItemCerrarSesion_Click(object sender, EventArgs e)
        {
            barButtonItemCerrarSesion_ItemClick(null, null);
        }

        private void contextMenuStripNotifyIcon_Opening(object sender, CancelEventArgs e)
        {
            toolStripMenuItemAbrirAplicacion.Enabled = !Visible;
        }

        private void alertControlSolicitudes_ButtonClick(object sender, AlertButtonClickEventArgs e)
        {
            if (e.ButtonName == "alertButtonVerSolicitud")
            {
                e.AlertForm.Close();
                FormBase.Instancia.MostrarVerSolicitud((Solicitud) e.Info.Tag);
                FormBase.Instancia.Visible = true;
                FormBase.Instancia.BringToFront();
                FormBase.Instancia.Activate();
            }
        }

        private void barButtonItemConfiguracion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarConfiguracion();
        }

        private void barButtonItemHistorialCompras_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarHistorialCompras();
        }

        private void timerSolicitudesFinalizadas_Tick(object sender, EventArgs e)
        {
            try
            {
                object[] solicitudesFinalizadas = Program.InterfazRemota.ObtenerFinalizadasNoSincronizadas(Configuracion.Default.usuario, Configuracion.Default.contrasena);
                foreach (SGC.ENSolicitud i in solicitudesFinalizadas)
                {
                    Solicitud solicitud = Solicitud.Obtener(i.Id);
                    if (solicitud != null)
                    {
                        object[] propuestas = Program.InterfazRemota.ObtenerPropuestas(solicitud.ENSolicitud, Configuracion.Default.usuario, Configuracion.Default.contrasena);
                        foreach (SGC.ENPropuesta j in propuestas)
                        {
                            Propuesta propuesta = new Propuesta(j);
                            propuesta.Guardar();
                        }

                        // Se actualizan el resto de formularios que tuvieran cargada la solicitud y se muestra un mensaje en pantalla.
                        ActualizarSolicitud(solicitud);
                        MostrarPropuestas(solicitud);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine(ex.StackTrace);
            }
        }

        private void timerConsumirSolicitudes_Tick(object sender, EventArgs e)
        {
            try
            {
                String xml = consumidorSolicitudes.Recibir(); //JORGITO BAILON: no será una simple asignación, sino que tendrás que desencriptar
                if (xml != null)
                {
                    SGC.ENSolicitud solicitud = CreateENSolicitudFromXML(xml);
                    if (solicitud != null)
                    {
                        // Se realiza un upcasting desde ENSolicitud a Solicitud.
                        Solicitud solicitud2 = new Solicitud(solicitud);
                        if (solicitud2 != null)
                        {
                            // Se guarda la solicitud en la base de datos.
                            if (solicitud2.Guardar())
                            {
                                // Finalmente se añade la solicitud al GridView y se emite un mensaje de llegada.
                                FormVerSolicitudes.ProcesarSolicitud(solicitud2);
                                MostrarSolicitud(solicitud2);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine(ex.StackTrace);
            }
        }

        private void barButtonItemLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show("¿Está seguro?", "Limpiando el registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                FormRegistro.Limpiar();
        }

        private void barButtonItemElegirFuente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormRegistro.ElegirFuente();
        }

        private void barButtonItemElegirColor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormRegistro.ElegirColor();
        }
    }
}

/*try
    {
        // TODO: Quitar esto y usar la que haya configurado el usuario.
        // TODO: y si no ha configurado pop3, entonces hay que saltarse todo y no hacer nada
        Configuracion.Default.popdir = "pop.gmail.com";
        Configuracion.Default.poppuerto = 995;
        Configuracion.Default.popssl = true;
        Configuracion.Default.correoelectronico = "criludage@gmail.com";
        Configuracion.Default.popcontrasena = "123456criludage";

        ClientePop3 clientePop3 = new ClientePop3(
            Configuracion.Default.popdir,
            Configuracion.Default.poppuerto,
            Configuracion.Default.popssl,
            Configuracion.Default.correoelectronico,
            Configuracion.Default.popcontrasena
            );

        ArrayList mensajesRecientes = clientePop3.ObtenerMensajesDesde(Configuracion.Default.popultimouid);
        foreach (ArrayList i in mensajesRecientes)
        {
            String emisor = (String)i[0];
            String uid = (String)i[1];
            String asunto = (String)i[2];

            if (emisor.ToLower().Contains("criludage"))
            {
                Console.WriteLine(emisor.ToString() + " " + uid + " " + asunto);
                try
                {
                    // Se extraen las propuestas de la solicitud y se guardan en BD.
                    int id = int.Parse(asunto.Split(new Char[] { ' ' })[2]);
                    Solicitud solicitud = Solicitud.Obtener(id);
                    if (solicitud != null)
                    {
                        procesarSolicitudFinalizada(solicitud);
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                    System.Console.WriteLine(e.StackTrace);
                }
            }
        }

        if (mensajesRecientes.Count > 0)
            Configuracion.Default.popultimouid = (String)((ArrayList)mensajesRecientes[0])[1];
    }
    catch (Exception e)
    {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine(e.StackTrace);
    }
}*/
