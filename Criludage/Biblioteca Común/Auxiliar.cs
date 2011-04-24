using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca_Común
{
    public class Auxiliar
    {
        /// <summary>
        /// Extrae la dirección IP (o dominio) de una URI que obligatoriamente empeza por http:// o https:// y que
        /// obligatoriamente tiene : o una / al final.
        /// </summary>
        /// <param name="uri">Ruta que se va a parsear.</param>
        /// <returns>La dirección IP que se ha extraído.</returns>
        public static String ExtraerIP(String uri)
        {
            String ip;
            if (uri.Contains("http://"))
            {
                ip = uri.Substring(7);
            }
            else
            {
                ip = uri.Substring(8);
            }

            Console.WriteLine(ip);

            if (ip.Contains(":"))
            {
                ip = ip.Substring(0, ip.IndexOf(":"));
            }
            else
            {
                ip = ip.Substring(0, ip.IndexOf("/"));
            }

            return ip;
        }
    }
}
