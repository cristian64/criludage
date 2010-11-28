using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Biblioteca_de_Entidades_de_Negocio
{
    public class Propuesta
    {
        private int id;
        private String descripcion;
        private byte[] foto;
        private DateTime fechaEntrega;
        private EstadosPieza estado;
        private int precio;
        private bool aceptada;

        private Desguace desguace;
        private Solicitud solicitud;
        
        /// <summary>
        /// Identificador de la propuesta
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Descripción de la pieza propuesta
        /// </summary>
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        /// <summary>
        /// Foto de la pieza propuesta
        /// </summary>
        public byte[] Foto
        {
            get { return foto; }
            set { foto = value; }
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
        /// Estado de la pieza propuesta
        /// </summary>
        public EstadosPieza Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        /// <summary>
        /// Precio de la propuesta
        /// </summary>
        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        /// <summary>
        /// Indica si la propuesta ha sido aceptada
        /// </summary>
        public bool Aceptada
        {
            get { return aceptada; }
            set { aceptada = value; }
        }

        /// <summary>
        /// Desguace que ha realizado la propuesta
        /// </summary>
        public Desguace Desguace
        {
            get { return desguace; }
            set { desguace = value; }
        }

        /// <summary>
        /// Solicitud a la que se propone la pieza
        /// </summary>
        public Solicitud Solicitud 
        {
            get { return solicitud; }
            set { solicitud = value; }
        }
    }
}
