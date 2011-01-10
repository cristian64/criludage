using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Collections;


namespace Biblioteca_Común
{
    public class Correo
    {
        SmtpClient cliente;

        /// <summary>
        /// Constructor para envío de correo.
        /// </summary>
        /// <param name="servidor">Servidor SMTP</param> 
        /// <param name="puerto">Puerto para el uso del servidor</param> 
        /// <param name="activarSsl">Indica si se activa SSL</param> 
        public Correo(String servidor, Int32 puerto, bool activarSsl)
        {
            cliente = new SmtpClient(servidor, puerto);
            cliente.EnableSsl = activarSsl;
        }

        /// <summary>
        /// Constructor para envío de correo que necesite credenciales.
        /// </summary>
        /// <param name="servidor"> Servidor SMTP </param>
        /// <param name="puerto">Puerto para el uso del servidor</param> 
        /// <param name="activarSsl">Indica si se activa SSL</param> 
        /// <param name="usuario">Usuario para la credencial</param> 
        /// <param name="contraseña">Contraseña para la credencial</param> 
        public Correo(String servidor, Int32 puerto, bool activarSsl, String usuario, String contraseña)
        {
            cliente = new SmtpClient(servidor, puerto);
            cliente.EnableSsl = activarSsl;
            cliente.Credentials = new NetworkCredential(usuario,contraseña);
        }

        /// <summary>
        /// Envía un correo con la información indicada.
        /// </summary>
        /// <param name="correoEmisor">Dirección del emisor del mensaje</param> 
        /// <param name="nombreEmisor">Nombre del emisor del mensaje</param> 
        /// <param name="destinatarios">Destinatario</param>
        /// <param name="asunto">Asunto del mensaje</param>
        /// <param name="cuerpo">Cuerpo del mensaje</param>
        /// <returns>Verdadero si el correo se ha enviado correctamente</returns>
        public bool enviar(String correoEmisor, String nombreEmisor, String destinatario, String asunto, String cuerpo)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(correoEmisor, nombreEmisor);
            mail.To.Add(new MailAddress(destinatario));
            mail.Subject = asunto;
            mail.Body = cuerpo;
            mail.IsBodyHtml = true; // Activar HTML

            try
            {
                cliente.Send(mail);
                return true;
            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Envía un correo a multiples destintarios con la información indicada.
        /// </summary>
        /// <param name="correoEmisor">Dirección del emisor del mensaje</param> 
        /// <param name="nombreEmisor">Nombre del emisor del mensaje</param> 
        /// <param name="destinatarios">Lista de destinatarios</param>
        /// <param name="asunto">Asunto del mensaje</param>
        /// <param name="cuerpo">Cuerpo del mensaje</param>
        /// <returns>Verdadero si el correo se ha enviado correctamente</returns>
        public bool enviar(String correoEmisor, String nombreEmisor, ArrayList destinatarios, String asunto, String cuerpo)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(correoEmisor, nombreEmisor);

            foreach(String d in destinatarios)
                mail.To.Add(new MailAddress(d));

            mail.Subject = asunto;
            mail.Body = cuerpo;

            try
            {
                cliente.Send(mail);
                return true;
            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
