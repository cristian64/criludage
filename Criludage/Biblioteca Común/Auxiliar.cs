using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

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

        /// <summary>
        /// Serializa un objecto en XML.
        /// </summary>
        /// <param name="objeto">Objeto que se va a serializar en XML.</param>
        /// <returns>Cadena de texto con el objeto serializado.</returns>
        public static String Serializar(object objeto)
        {
            XmlDocument document = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(objeto.GetType());
            MemoryStream stream = new MemoryStream();

            try
            {
                serializer.Serialize(stream, objeto);
                stream.Position = 0;
                document.Load(stream);
                return document.InnerXml;
            }
            catch (Exception)
            {

            }
            finally
            {
                stream.Close();
                stream.Dispose();
            }

            return "";
        }
    }
}
