using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca_de_Entidades_de_Negocio
{
    public class ENDesguace
    {
        private int id;
        private String usuario;
        private String contrasena;
        private String nombre;
        private String nif;
        private String correoElectronico;
        private String telefono;
        private String direccion;
        private String informacionAdicional;

        /// <summary>
        /// Identificador del desguace.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Nombre de usuario del desguace.
        /// </summary>
        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        /// <summary>
        /// Contraseña del desguace.
        /// </summary>
        public String Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        /// <summary>
        /// Nombre completo del desguace.
        /// </summary>
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Número de identificación fiscal.
        /// </summary>
        public String Nif
        {
            get { return nif; }
            set { nif = value; }
        }

        /// <summary>
        /// Correo electrónico del desguace.
        /// </summary>
        public String CorreoElectronico
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }

        /// <summary>
        /// Número o números de teléfono del desguace.
        /// </summary>
        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        /// <summary>
        /// Dirección postal del desguace (calle, ciudad, provincia, código postal, ...).
        /// </summary>
        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        /// <summary>
        /// Información adicional que pueda ser relevante para el desguace.
        /// </summary>
        public String InformacionAdicional
        {
            get { return informacionAdicional; }
            set { informacionAdicional = value; }
        }
    }
}
