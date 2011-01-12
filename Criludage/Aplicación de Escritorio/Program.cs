using System;
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
        public static SGC.InterfazRemota InterfazRemota = new SGC.InterfazRemota();

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

            Application.Run(new FormDEBUG());

            // Si no se ha especificado, se supone que es la primera vez que se accede a la aplicación.
            // El formulario de FormPrimeraVez arrancará todos los servicios y establecerá los parámetros necesarios.
            if (Configuracion.Default.usuario.Length == 0)
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
                Program.TipoAplicacion = (Configuracion.Default.desguace) ? Program.TiposAplicacion.DESGUACE : Program.TiposAplicacion.TALLER;

                // Se arranca el servicio web.
                InterfazRemota.Url = Configuracion.Default.servicioweb;
                try
                {
                    InterfazRemota.Inicializar();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }

                // Se carga el objeto del taller o del desguace, según el tipo de aplicación.
                ClienteIdentificado = Cliente.Obtener(Configuracion.Default.usuario);
                DesguaceIdentificado = Desguace.Obtener(Configuracion.Default.usuario);

                // Comprobamos si se ha podido iniciar sesión con el servicio. Si no, salimos de la aplicación.
                if (ClienteIdentificado == null && DesguaceIdentificado == null)
                {
                    InicioSesion = false;
                    DevExpress.XtraEditors.XtraMessageBox.Show("Se produjo un error al identificarse en el servidor. Revisa la ventana de comandos para ver el error.", "Accediendo a la aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    FormBase.Instancia = null;
                }
            }
        }
    }
}
