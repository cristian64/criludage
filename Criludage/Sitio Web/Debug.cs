using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitio_Web
{
    public class Debug
    {
        public static void WriteLine(String mensaje)
        {
            try
            {
                const String fichero = @"C:\criludage.debug";
                System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(fichero, true);
                streamWriter.WriteLine(DateTime.Now + " " + mensaje);
                streamWriter.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}