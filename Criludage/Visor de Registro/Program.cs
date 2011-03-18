using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Visor_de_Registro
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Modificamos "DataDirectory" porque la BD está en otro directorio.
            string mdf = Application.ExecutablePath;
            mdf = mdf.Remove(mdf.LastIndexOf(@"\bin\"));
            string mdf2 = mdf.Remove(mdf.LastIndexOf(@"\Visor de Registro"));
            mdf2 += @"\Servicio de Gestión de Compra\App_Data";
            AppDomain.CurrentDomain.SetData("DataDirectory", @mdf2);

            Application.Run(new VisorRegistro());
        }
    }
}
