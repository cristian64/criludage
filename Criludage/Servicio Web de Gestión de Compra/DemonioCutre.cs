using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace Servicio_Web_de_Gestión_de_Compra
{
    public class DemonioCutre
    {
        private static Thread demonio = null;
        private static void realizarAcciones()
        {
            try
            {
                while (true)
                {
                    DebugCutre.WriteLine("hilo en funcionamiento");
                    Thread.Sleep(5000);
                }
            }
            catch (Exception e)
            {
                DebugCutre.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Crea un hilo y arranca el bucle que se ejecuta indefinidamente.
        /// </summary>
        public static void Iniciar()
        {
            if (demonio == null)
            {
                demonio = new Thread(realizarAcciones);
                demonio.Start();
            }
        }

        public static void Detener()
        {
            if (demonio != null)
            {
                demonio.Abort();
                demonio = null;
            }
        }
    }
}