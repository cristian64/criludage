using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca_de_Entidades_de_Negocio
{
    public class Cliente
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
        /// Identificador del cliente.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Nombre de usuario del cliente.
        /// </summary>
        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        /// <summary>
        /// Contraseña del cliente.
        /// </summary>
        public String Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        /// <summary>
        /// Nombre completo del cliente.
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
        /// Correo electrónico del cliente.
        /// </summary>
        public String CorreoElectronico
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }

        /// <summary>
        /// Número o números de teléfono del cliente.
        /// </summary>
        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        /// <summary>
        /// Dirección postal del cliente (calle, ciudad, provincia, código postal, ...).
        /// </summary>
        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        /// <summary>
        /// Información adicional que pueda ser relevante para el cliente.
        /// </summary>
        public String InformacionAdicional
        {
            get { return informacionAdicional; }
            set { informacionAdicional = value; }
        }
    }
}
