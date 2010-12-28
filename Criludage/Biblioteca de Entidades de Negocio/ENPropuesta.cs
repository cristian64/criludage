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
        private int idLocal;
        private String descripcion;
        private DateTime fechaEntrega;
        private ENEstadosPieza estado;
        private int precio;

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
        /// Identificador de la propuesta en la aplicación local.
        /// </summary>
        public int IdLocal
        {
            get { return idLocal; }
            set { idLocal = value; }
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
        public int Precio
        {
            get { return precio; }
            set { precio = value; }
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
