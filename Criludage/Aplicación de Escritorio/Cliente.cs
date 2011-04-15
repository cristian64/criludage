using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicación_de_Escritorio
{
    public class Cliente : SGC.ENCliente
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Cliente()
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
        /// Constructor sobrecargado que realiza un upcasting desde ENCliente a Cliente.
        /// </summary>
        /// <param name="cliente">Cliente que se va a convertir.</param>
        public Cliente(SGC.ENCliente cliente)
        {
            Id = cliente.Id;
            Usuario = cliente.Usuario;
            Contrasena = cliente.Contrasena;
            Nombre = cliente.Nombre;
            CorreoElectronico = cliente.CorreoElectronico;
            Direccion = cliente.Direccion;
            Nif = cliente.Nif;
            InformacionAdicional = cliente.InformacionAdicional;
            Telefono = cliente.Telefono;
        }

        /// <summary>
        /// Devuelve el cliente compatible con ENCliente. Es decir, realiza un downcasting del cliente.
        /// </summary>
        public SGC.ENCliente ENCliente
        {
            get
            {
                SGC.ENCliente cliente = new SGC.ENCliente();
                cliente.Id = Id;
                cliente.Usuario = Usuario;
                cliente.Contrasena = Contrasena;
                cliente.Nombre = Nombre;
                cliente.CorreoElectronico = CorreoElectronico;
                cliente.Direccion = Direccion;
                cliente.Nif = Nif;
                cliente.InformacionAdicional = InformacionAdicional;
                cliente.Telefono = Telefono;
                return cliente;
            }
        }

        /// <summary>
        /// Guarda el cliente en la base de datos global comunicándose con el servicio web.
        /// </summary>
        /// <returns>Devuelve verdadero si se ha guardado correctamente.</returns>
        public bool Actualizar()
        {
            try
            {
                return Program.InterfazRemota().ActualizarCliente(this.ENCliente, Configuracion.Default.usuario, Configuracion.Default.contrasena);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Consulta el servicio web para obtener el cliente a partir del identificador.
        /// </summary>
        /// <param name="id">Identificador del cliente.</param>
        /// <returns>Devuelve un objeto de la clase Cliente con todos atributos. Si no existe, devuelve null.</returns>
        public static Cliente Obtener(int id)
        {
            try
            {
                SGC.ENCliente cliente = Program.InterfazRemota().ObtenerCliente(id, Configuracion.Default.usuario, Configuracion.Default.contrasena);
                if (cliente != null)
                    return new Cliente(cliente);
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
        /// Consulta el servicio web para obtener el cliente a partir del nombre de usuario.
        /// </summary>
        /// <param name="usuario2">Nombre de usuario del cliente.</param>
        /// <param name="usuario">Nombre de usuario del usuario que quiere acceder al método.</param>
        /// <param name="contrasena">Contraseña del usuario que quiere acceder al método.</param>
        /// <returns>Devuelve un objeto de la clase Cliente con todos atributos. Si no existe, devuelve null.</returns>
        public static Cliente Obtener(String usuario)
        {
            try
            {
                SGC.ENCliente cliente = Program.InterfazRemota().ObtenerClientePorUsuario(usuario, Configuracion.Default.usuario, Configuracion.Default.contrasena);
                if (cliente != null)
                    return new Cliente(cliente);
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
