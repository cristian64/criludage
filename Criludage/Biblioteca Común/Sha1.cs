using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Biblioteca_Común
{
    public class Sha1
    {
        /// <summary>
        /// Calcula el sha-1 de una cadena de caracteres.
        /// </summary>
        /// <param name="cadena">Cadena de caracteres que va a calcular.</param>
        /// <returns>Devuelve el resultado de calcular el sha-1 de la cadena.</returns>
        public static string ComputeHash(string cadena)
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
