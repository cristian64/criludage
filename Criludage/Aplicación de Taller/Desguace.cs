using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicación_de_Taller
{
    public class Desguace : SGC.ENDesguace
    {
        private Desguace(SGC.ENDesguace desguace)
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
        /// Consulta el servicio web para obtener el desguace a partir del identificador.
        /// </summary>
        /// <param name="id">Identificador del desguace.</param>
        /// <returns>Devuelve un objeto de la clase Cliente con todos atributos. Si no existe, devuelve null.</returns>
        public static Desguace Obtener(int id)
        {
            SGC.InterfazRemota interfazRemota = new SGC.InterfazRemota();
            SGC.ENDesguace desguace = interfazRemota.ObtenerDesguace(id);
            if (desguace != null)
                return new Desguace(desguace);
            else
                return null;
        }
    }
}
