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
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
            if (EmpleadoIdentificado != null)
                Application.Run(FormBase.GetInstancia());
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
