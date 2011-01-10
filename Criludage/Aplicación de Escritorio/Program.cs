﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Biblioteca_Común;
using System.Text;
using System.Configuration;

namespace Aplicación_de_Escritorio
{
    static class Program
    {
        /// <summary>
        /// Instancia de la interfaz remota.
        /// </summary>
        public static SGC.InterfazRemota InterfazRemota;

        /// <summary>
        /// Cliente que se ha identificado (sólo si la aplicación es de taller).
        /// </summary>
        public static Cliente ClienteIdentificado = null;

        /// <summary>
        /// Desguace que se ha identificado (sólo si la aplicación es de desguace).
        /// </summary>
        public static Desguace DesguaceIdentificado = null;

        /// <summary>
        /// Empleado que se ha identificado.
        /// </summary>
        public static Empleado EmpleadoIdentificado = null;

        /// <summary>
        /// Diferentes tipos de aplicación.
        /// </summary>
        public enum TiposAplicacion { TALLER, DESGUACE }

        /// <summary>
        /// Indica si la aplicación se comporta como un taller o como un desguace.
        /// </summary>
        public static TiposAplicacion TipoAplicacion = TiposAplicacion.TALLER;

        /// <summary>
        /// Indica si hay que salir de la aplicación o volvemos a lanzar la ventana de login.
        /// Cuando el usuario quiera conectar con otro empleado en vez de salir, se establece este valor a "true".
        /// </summary>
        public static bool InicioSesion = true;

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Skins.SkinManager.EnableFormSkins();

            // Se crea la interfaz remota. Todavía no se establece ninguna comunicación.
            InterfazRemota = new SGC.InterfazRemota();

            // Si no se ha especificado, se supone que es la primera vez que se accede a la aplicación.
            // El formulario de FormPrimeraVez arrancará todos los servicios y establecerá los parámetros necesarios.
            if (Resources.Configuracion.usuario.Length == 0)
            {
                InicioSesion = false;
                EmpleadoIdentificado = null;
                Application.Run(new FormPrimeraVez());

                // El FormPrimeraVez se encarga de establecer "EmpleadoIdentificado". Si no lo establece, es que no ha completado la configuración.
                if (EmpleadoIdentificado != null)
                {
                    FormBase.Instancia = null;
                    Application.Run(FormBase.Instancia);
                }
            }

            // Si no es la primera vez, se arrancan los servicios con la configuración existente.
            else
            {
                // Se arranca el servicio web.
                InterfazRemota.Url = Resources.Configuracion.servicioweb;
                InterfazRemota.Inicializar();

                // Se carga el objeto del taller o del desguace, según el tipo de aplicación.
                //TODO: yo había supuesto que no habría repetidos, por lo que ésta sería una forma de hacerlo para saber si es un taller o un desguace
                ClienteIdentificado = Cliente.Obtener(Resources.Configuracion.usuario);
                DesguaceIdentificado = Desguace.Obtener(Resources.Configuracion.usuario);
                Program.TipoAplicacion = (DesguaceIdentificado == null) ? Program.TiposAplicacion.TALLER : Program.TiposAplicacion.DESGUACE;
            }

            // Se repite el bucle mientras el usuario no decida cerrar la aplicación completamente.
            // Es decir, se repite el bucle mientras sólo cierre la sesión.
            while (InicioSesion)
            {
                InicioSesion = false;
                EmpleadoIdentificado = null;
                Application.Run(new FormLogin());

                // El FormLogin se encarga de establecer "EmpleadoIdentificado". Si no lo establece, es que no ha conseguido entrar.
                if (EmpleadoIdentificado != null)
                {
                    FormBase.Instancia = null;
                    Application.Run(FormBase.Instancia);
                }
            }
        }
    }
}
