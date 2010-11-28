using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Biblioteca_Común;
using Biblioteca_de_Entidades_de_Negocio;

namespace Aplicación_de_Taller
{
    static class Program
    {
        /*static object metodillo(object objeto)
        {
            Solicitud solicitud = objeto as Solicitud;
            System.Console.WriteLine("He recibido algoooo: " + solicitud.Id);
            return null;
        }*/

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Productor productor = new Productor("tcp://192.168.0.192:61616", "pollaca");
            Solicitud solicitud = new Solicitud();
            solicitud.Id = 1729;
            productor.Enviar(solicitud);

            Consumidor consumidor = new Consumidor("tcp://192.168.0.192:61616", "pollaca", metodillo);*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormBase());
        }
    }
}
