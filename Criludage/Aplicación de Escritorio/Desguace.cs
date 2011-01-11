using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicación_de_Escritorio
{
    public class Desguace : SGC.ENDesguace
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Desguace()
        {
            Id = 0;
            Usuario = "";
            Contrasena = "";
            Nombre = "";
            CorreoElectronico = "";
            Direccion = "";
            Nif = "";
            InformacionAdicional = "";
            Telefono = "";
        }

        /// <summary>
        /// Constructor sobrecargado que realiza un upcasting desde ENDesguace a Desguace.
        /// </summary>
        /// <param name="desguace">Desguace que se va a convertir.</param>
        public Desguace(SGC.ENDesguace desguace)
        {
            Id = desguace.Id;
            Usuario = desguace.Usuario;
            Contrasena = desguace.Contrasena;
            Nombre = desguace.Nombre;
            CorreoElectronico = desguace.CorreoElectronico;
            Direccion = desguace.Direccion;
            Nif = desguace.Nif;
            InformacionAdicional = desguace.InformacionAdicional;
            Telefono = desguace.Telefono;
        }

        /// <summary>
        /// Devuelve el desguace compatible con ENDesguace. Es decir, realiza un downcasting del desguace.
        /// </summary>
        public SGC.ENDesguace ENDesguace
        {
            get
            {
                SGC.ENDesguace desguace = new SGC.ENDesguace();
                desguace.Id = Id;
                desguace.Usuario = Usuario;
                desguace.Contrasena = Contrasena;
                desguace.Nombre = Nombre;
                desguace.CorreoElectronico = CorreoElectronico;
                desguace.Direccion = Direccion;
                desguace.Nif = Nif;
                desguace.InformacionAdicional = InformacionAdicional;
                desguace.Telefono = Telefono;
                return desguace;
            }
        }

        /// <summary>
        /// Guarda el desguace en la base de datos global comunicándose con el servicio web.
        /// </summary>
        /// <returns>Devuelve verdadero si se ha guardado correctamente.</returns>
        public bool Actualizar()
        {
            try
            {
                return Program.InterfazRemota.ActualizarDesguace(this.ENDesguace, Configuracion.Default.usuario, Configuracion.Default.contrasena);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Consulta el servicio web para obtener el desguace a partir del identificador.
        /// </summary>
        /// <param name="id">Identificador del desguace.</param>
        /// <returns>Devuelve un objeto de la clase Cliente con todos atributos. Si no existe, devuelve null.</returns>
        public static Desguace Obtener(int id)
        {
            try
            {
                SGC.ENDesguace desguace = Program.InterfazRemota.ObtenerDesguace(id, Configuracion.Default.usuario, Configuracion.Default.contrasena);
                if (desguace != null)
                    return new Desguace(desguace);
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Consulta el servicio web para obtener el desguace a partir del nombre de usuario.
        /// </summary>
        /// <param name="usuario">Nombre de usuario del desguace.</param>
        /// <returns>Devuelve un objeto de la clase Cliente con todos atributos. Si no existe, devuelve null.</returns>
        public static Desguace Obtener(String usuario)
        {
            try
            {
                SGC.ENDesguace desguace = Program.InterfazRemota.ObtenerDesguacePorUsuario(usuario, Configuracion.Default.usuario, Configuracion.Default.contrasena);
                if (desguace != null)
                    return new Desguace(desguace);
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
    }
}
