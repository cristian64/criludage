using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicación_de_Escritorio
{
    public class Cliente : SGC.ENCliente
    {
        private Cliente(SGC.ENCliente cliente)
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
        /// Consulta el servicio web para obtener el cliente a partir del identificador.
        /// </summary>
        /// <param name="id">Identificador del cliente.</param>
        /// <returns>Devuelve un objeto de la clase Cliente con todos atributos. Si no existe, devuelve null.</returns>
        public static Cliente Obtener(int id)
        {
            SGC.InterfazRemota interfazRemota = new SGC.InterfazRemota();
            SGC.ENCliente cliente = interfazRemota.ObtenerCliente(id);
            if (cliente != null)
                return new Cliente(cliente);
            else
                return null;
        }
    }
}
