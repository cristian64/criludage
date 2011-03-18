using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio_de_Gestión_de_Compra
{
    public class DebugCutre
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