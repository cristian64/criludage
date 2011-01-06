using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Biblioteca_Común;

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

        static void responderSolicitud()
        {

            // Ejemplo de enviar un correo usando el servidor de gmail

            // Datos para el servidor de correo
            Correo correo = new Correo( "smtp.gmail.com",
                                        587,
                                        true, // Usar SSL
                                        "criludage@gmail.com",
                                        "123456criludage"
                                        );

            // Datos del contenido del correo
            if (correo.enviar("criludage@gmail.com", "Criludage Corp.", "receptor@yopmail.com", "Buenos dias", "Pues eso"))
                System.Console.WriteLine("Correo OK!");
        }
    }
}
