using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Biblioteca_de_Entidades_de_Negocio
{
    public class ENPropuesta
    {
        private int id;
        private String descripcion;
        private DateTime fechaEntrega;
        private ENEstadosPieza estado;
        private float precio;
        private byte[] foto;

        private int idDesguace;
        private int idSolicitud;
        
        /// <summary>
        /// Identificador de la propuesta.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Descripción de la pieza propuesta.
        /// </summary>
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        /// <summary>
        /// Fecha de entrega de la pieza propuesta
        /// </summary>
        public DateTime FechaEntrega
        {
            get { return fechaEntrega; }
            set { fechaEntrega = value; }
        }

        /// <summary>
        /// Estado de la pieza propuesta.
        /// </summary>
        public ENEstadosPieza Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        /// <summary>
        /// Precio de la pieza propuesta.
        /// </summary>
        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        /// <summary>
        /// Foto de la pieza propuesta.
        /// </summary>
        public byte[] Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        /// <summary>
        /// Identificador del desguace que ha realizado la propuesta.
        /// </summary>
        public int IdDesguace
        {
            get { return idDesguace; }
            set { idDesguace = value; }
        }

        /// <summary>
        /// Identificador de la solicitud a la que hace referencia la propuesta.
        /// </summary>
        public int IdSolicitud 
        {
            get { return idSolicitud; }
            set { idSolicitud = value; }
        }
    }
}
