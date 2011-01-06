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

namespace Aplicación_de_Escritorio
{
    public partial class FormBase : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static FormBase instancia = null;
        public static FormBase GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new FormBase();
            }
            return instancia;
        }

        /// <summary>
        /// Instancia de la interfaz remota.
        /// </summary>
        public SGC.InterfazRemota InterfazRemota;

        /// <summary>
        /// Instancia del formulario para evitar tiempos de espera.
        /// Así, puede ir actualizándose el formulario incluso cuando no se muestra.
        /// </summary>
        public FormVerSolicitudes FormVerSolicitudes;
        public FormVerEmpleados FormVerEmpleados;

        /// <summary>
        /// Mantiene la secuencia de cómo se mostraron los formularios para poder retroceder de un formulario al anterior.
        /// </summary>
        private ArrayList anteriores;
        private ArrayList siguientes;

        /// <summary>
        /// Es el consumidor que se ejecuta en otro hilo, recibiendo los mensajes y procesándolos.
        /// </summary>
        private Consumidor consumidorSolicitudes;
        private System.Timers.Timer temporizador;
        private delegate void delegado(object sender, ElapsedEventArgs ev);
        private void consumirSolicitud(object sender, ElapsedEventArgs ev)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new delegado(consumirSolicitud), new object[] { sender, ev });
            }
            else
            {
                try
                {
                    String xml = consumidorSolicitudes.Recibir();
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
                                    FormBase.GetInstancia().MostrarMensaje("Solicitud recibida", "Se ha recibido una nueva solicitud");
                                    //TODO: que aparezca un botón en el popup para que se pueda ir directamente a ver la solicitud
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                    System.Console.WriteLine(e.StackTrace);
                }
            }
        }

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

            // Se introducen los botones referentes a los empleados en un único menú desplegable.
            // Desde el diseñador no se puede hacer, por lo que salen todos visibles.
            this.barLinkContainerItemEmpleados.AddItem(this.barButtonItemVerEmpleados);
            this.barLinkContainerItemEmpleados.AddItem(this.barButtonItemAnadirEmpleado);
            this.barLinkContainerItemEmpleados.AddItem(this.barButtonItemAnadirAdministrador);
            this.ribbonPageGroupAdministracion.ItemLinks.Remove(this.barButtonItemVerEmpleados);
            this.ribbonPageGroupAdministracion.ItemLinks.Remove(this.barButtonItemAnadirEmpleado);
            this.ribbonPageGroupAdministracion.ItemLinks.Remove(this.barButtonItemAnadirAdministrador);

            InterfazRemota = new SGC.InterfazRemota();
            FormVerSolicitudes = new FormVerSolicitudes();
            FormVerEmpleados = new FormVerEmpleados();
            anteriores = new ArrayList();
            siguientes = new ArrayList();

            // Nombre de usuario en la barra de estado.
            barStaticItemEmpleado.Caption = Program.EmpleadoIdentificado.Usuario;

            // Realizamos las acciones pertinentes según el perfil del empleado (normal o administrador) y según el tipo de aplicación (taller o desguace).
            if (Program.TipoAplicacion == Program.TiposAplicacion.DESGUACE)
            {
                // Se crea el consumidor de solicitudes y el hilo que consultará cada 1 segundo los mensajes pendientes.
                consumidorSolicitudes = new Consumidor(ConfigurationManager.ConnectionStrings["activemq"].ConnectionString, ConfigurationManager.ConnectionStrings["topic"].ConnectionString);
                temporizador = new System.Timers.Timer();
                temporizador.Elapsed += new ElapsedEventHandler(consumirSolicitud);
                temporizador.Interval = 3000;
                temporizador.Enabled = true;

                // Se oculta el botón de "solicitar pieza".
                barButtonItemSolicitar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {

            }
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
        /// Muestra el panel para añadir un empleado.
        /// </summary>
        public void MostrarVerEmpleado(Empleado empleado)
        {
            // Si ya se está mostrando "VerEmpleado", sólo cargamos el empleado.
            if (panelContenido.Controls.Count > 0 && panelContenido.Controls[0] is FormVerEmpleado)
            {
                ((FormVerEmpleado)panelContenido.Controls[0]).CargarEmpleado(empleado);
                return;
            }
            Mostrar(new FormVerEmpleado(empleado));
        }

        /// <summary>
        /// Muestra el panel para añadir un empleado.
        /// </summary>
        public void MostrarVerSolicitud(Solicitud solicitud)
        {
            // Si ya se está mostrando "VerSolicitud", sólo cargamos la solicitud.
            if (panelContenido.Controls.Count > 0 && panelContenido.Controls[0] is FormVerSolicitud)
            {
                ((FormVerSolicitud)panelContenido.Controls[0]).CargarSolicitud(solicitud);
                return;
            }
            Mostrar(new FormVerSolicitud(solicitud));
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
            FormBase.GetInstancia().MostrarNinguno();
            if (siguientes.Count > 0)
                FormBase.GetInstancia().MostrarSiguiente();
            else
                FormBase.GetInstancia().MostrarAnterior();
        }
    }
}
