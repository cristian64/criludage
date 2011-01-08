using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Biblioteca_Común;
using System.Security.Cryptography;
using System.Text;

namespace Aplicación_de_Escritorio
{
    static class Program
    {
        /// <summary>
        /// Instancia de la interfaz remota.
        /// </summary>
        public static SGC.InterfazRemota InterfazRemota;

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

            // Se inicializan los servicios de la aplicación.
            InterfazRemota = new SGC.InterfazRemota();
            InterfazRemota.Inicializar();

            // Si no hay empleados, se supone que es la primera vez que se accede a la aplicación.
            if (Empleado.ObtenerTodos().Count == 0)
            {
                InicioSesion = false;
                EmpleadoIdentificado = null;
                Application.Run(new FormPrimeraVez());
                if (EmpleadoIdentificado != null)
                {
                    FormBase.Instancia = null;
                    Application.Run(FormBase.Instancia);
                }
            }

            // Se repite el bucle mientras el usuario no decida cerrar la aplicación completamente.
            // Es decir, se repite el bucle mientras sólo cierre la sesión.
            while (InicioSesion)
            {
                InicioSesion = false;
                EmpleadoIdentificado = null;
                Application.Run(new FormLogin());
                if (EmpleadoIdentificado != null)
                {
                    FormBase.Instancia = null;
                    Application.Run(FormBase.Instancia);
                }
            }
        }

        /// <summary>
        /// Calcula el sha-1 de una cadena de caracteres.
        /// </summary>
        /// <param name="cadena">Cadena de caracteres que va a calcular.</param>
        /// <returns>Devuelve el resultado de calcular el sha-1 de la cadena.</returns>
        public static string Sha1(string cadena)
        {
            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(cadena));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
