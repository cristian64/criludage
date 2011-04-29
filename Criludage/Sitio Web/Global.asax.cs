using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Configuration;
using System.Timers;
namespace Sitio_Web
{
    public class Global : System.Web.HttpApplication
    {
        private static SGC.InterfazRemota interfazRemota = null;
        public SGC.InterfazRemota InterfazRemota
        {
            get
            {
                if (interfazRemota == null)
                {
                    interfazRemota = new SGC.InterfazRemota();
                    interfazRemota.Url = InterfazUDDI.PuntoAccesoServicio("Criludage");
                    try
                    {
                        interfazRemota.Inicializar();
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                }
                return interfazRemota;
            }
        }

        private static Biblioteca_Común.Inquiry interfazUDDI = null;
        public Biblioteca_Común.Inquiry InterfazUDDI
        {
            get
            {
                if (interfazUDDI == null)
                {
                    interfazUDDI = new Biblioteca_Común.Inquiry(ConfigurationManager.ConnectionStrings["juddi"].ConnectionString);
                }
                return interfazUDDI;
            }
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciarse la aplicación
            System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(EventoChequeoWS);
            timer.Interval = 5000;
            timer.Enabled = true;
        }

        public void EventoChequeoWS(object source, ElapsedEventArgs e)
        {
            try
            {
                InterfazRemota.ObtenerCliente(0, "", "");
            }
            catch (System.Net.WebException)
            {
                ComprobarUDDI();
            }
            catch (System.ServiceModel.FaultException)
            {
                ComprobarUDDI();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        void ComprobarUDDI()
        {
            bool OK = false;

            while (!OK)
            {
                try
                {
                    InterfazRemota.Url = InterfazUDDI.PuntoAccesoServicio("Criludage");
                    InterfazRemota.Inicializar();
                    OK = true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }


        void Application_End(object sender, EventArgs e)
        {
            //  Código que se ejecuta cuando se cierra la aplicación

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Código que se ejecuta al producirse un error no controlado

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta cuando se inicia una nueva sesión

        }

        void Session_End(object sender, EventArgs e)
        {
            // Código que se ejecuta cuando finaliza una sesión.
            // Nota: el evento Session_End se desencadena sólo cuando el modo sessionstate
            // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer 
            // o SQLServer, el evento no se genera.

        }

    }
}
