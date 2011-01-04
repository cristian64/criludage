using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Biblioteca_Común;
using System.Xml;
using System.Collections;

namespace Aplicación_de_Taller
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
        public FormSolicitarPieza FormSolicitarPieza;
        public FormVerEmpleados FormVerEmpleados;
        public FormAnadirEmpleado FormAnadirEmpleado;
        public FormVerEmpleado FormVerEmpleado;

        /// <summary>
        /// Mantiene la secuencia de cómo se mostraron los formularios para poder retroceder de un formulario al anterior.
        /// </summary>
        private ArrayList anteriores;
        private ArrayList siguientes;

        /// <summary>
        /// Es el consumidor que se ejecuta en otro hilo, recibiendo los mensajes y procesándolos.
        /// </summary>
        private Consumidor consumidorSolicitudes;
        private Thread hiloConsumidorSolicitudes;
        private void consumirSolicitudes()
        {
            try
            {
                while (true)
                {
                    String xml = consumidorSolicitudes.Recibir(1);
                    if (xml != null)
                    {
                        SGC.ENSolicitud solicitud = CreateENSolicitudFromXML(xml);
                        if (solicitud != null)
                        {
                            // Se realiza un upcasting desde ENSolicitud a Solicitud y se añade la solicitud a la tabla.
                            FormVerSolicitudes.ProcesarSolicitud(new Solicitud(solicitud));
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
            FormSolicitarPieza = new FormSolicitarPieza();
            FormVerEmpleados = new FormVerEmpleados();
            FormAnadirEmpleado = new FormAnadirEmpleado();
            FormVerEmpleado = new FormVerEmpleado();
            anteriores = new ArrayList();
            siguientes = new ArrayList();

            // Se crea el consumidor de solicitudes y el hilo que consultará cada 1 segundo los mensajes pendientes.
            consumidorSolicitudes = new Consumidor(Settings.Default.servidor, Settings.Default.topic);
            hiloConsumidorSolicitudes = new Thread(consumirSolicitudes);
            hiloConsumidorSolicitudes.Start();
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            MostrarVerSolicitudes();
        }

        private void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea salir?", "Saliendo de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                hiloConsumidorSolicitudes.Abort();
            }
        }

        /// <summary>
        /// Muestra la vista de solicitudes.
        /// </summary>
        public void MostrarVerSolicitudes()
        {
            Mostrar(FormVerSolicitudes);
        }

        /// <summary>
        /// Muestra el formulario para solicitar una pieza.
        /// </summary>
        public void MostrarSolicitarPieza()
        {
            Mostrar(FormSolicitarPieza);
        }

        /// <summary>
        /// Muestra los empleados.
        /// </summary>
        public void MostrarVerEmpleados()
        {
            Mostrar(FormVerEmpleados);
        }

        /// <summary>
        /// Muestra el panel para añadir un empleado.
        /// </summary>
        public void MostrarAnadirEmpleado()
        {
            Mostrar(FormAnadirEmpleado);
        }

        /// <summary>
        /// Muestra el panel para añadir un empleado.
        /// </summary>
        public void MostrarVerEmpleado(Empleado empleado)
        {
            FormVerEmpleado.CargarEmpleado(empleado);
            Mostrar(FormVerEmpleado);
        }

        /// <summary>
        /// Muestra el UserControl en el panel principal.
        /// </summary>
        /// <param name="userControl"></param>
        public void Mostrar(UserControl userControl)
        {
            // Se extrae el panel actual y se inserta el nuevo.
            UserControl actual = (panelContenido.Controls.Count > 0) ? (UserControl) panelContenido.Controls[0] : null;
            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(userControl);

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
            }
            panelContenido.Controls.Clear();
            barButtonItemSiguiente.Enabled = true;

            // Si hay elementos en "anteriores", se muestra el último en el panel principal.
            if (anteriores.Count > 0)
            {
                panelContenido.Controls.Add((UserControl) anteriores[anteriores.Count - 1]);
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
            }
            panelContenido.Controls.Clear();
            barButtonItemAnterior.Enabled = true;

            // Si hay elementos en "siguientes", se muestra el último en el panel principal.
            if (siguientes.Count > 0)
            {
                panelContenido.Controls.Add((UserControl) siguientes[siguientes.Count - 1]);
                siguientes.RemoveAt(siguientes.Count - 1);
            }

            // Comprobamos si quedan "anteriores" para activar o desactivar el botón.
            barButtonItemSiguiente.Enabled = siguientes.Count > 0;
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
            MostrarAnadirEmpleado();
            FormAnadirEmpleado.Modo(false);
        }

        private void barButtonItemAnadirAdministrador_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarAnadirEmpleado();
            FormAnadirEmpleado.Modo(true);
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
    }
}
