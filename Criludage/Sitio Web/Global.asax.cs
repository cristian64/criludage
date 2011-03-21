﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Configuration;

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
                    interfazRemota.Url = ConfigurationManager.ConnectionStrings["servicioweb"].ConnectionString;
                }
                return interfazRemota;
            }
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciarse la aplicación
            System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
            InterfazRemota.Inicializar();
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
