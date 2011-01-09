using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Biblioteca_de_Entidades_de_Negocio;

namespace Servicio_de_Gestión_de_Compra
{
    public class Desguace : ENDesguace
    {
        private Desguace(ENDesguace desguace)
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
        /// Consulta la base de datos para obtener el desguace a partir del identificador.
        /// </summary>
        /// <param name="id">Identificador del desguace.</param>
        /// <returns>Devuelve un objeto de la clase Cliente con todos atributos. Si no existe, devuelve null.</returns>
        public static Desguace Obtener(int id)
        {
            return null;
        }
    }
}
