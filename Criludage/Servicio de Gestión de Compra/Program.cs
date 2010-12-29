using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Servicio_de_Gestión_de_Compra
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrancar ActiveMQ.
            // Crear el topic dinamicamente y establecer los persmisos de los usuarios que pueden conectarse.
            // Arrancar el servicio web.
            // Arrancar página web.
            // (aunque estas cosillas igual se hace mejor desde un programa en bash o tal...)

            // bucle principal:
            //      Comprobar qué solicitudes han finalizado pero todavía no se han enviado.
            //      Enviar e-mail a los talleres.
            //      Marcar la solicitud como finalizada.

            bool valorInicial = System.Console.NumberLock;
            while (System.Console.NumberLock == valorInicial)
            {
                System.Console.WriteLine("pollaca");
                Thread.Sleep(1000);
            }
        }
    }
}
