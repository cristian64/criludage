using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicación_de_Escritorio
{
    public class Registro
    {
        public static string NombreFichero = @"registro.log";

        public static void WriteLine(String mensaje)
        {
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(NombreFichero, true);
            streamWriter.WriteLine(DateTime.Now + " " + mensaje);
            streamWriter.Close();
            if (FormBase.Instanciado)
                FormBase.Instancia.FormRegistro.WriteLine(mensaje);
        }
    }
}