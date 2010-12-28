using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Biblioteca_de_Entidades_de_Negocio
{
    public class ENSolicitud
    {
        private int id;
        private int idLocal;
        private String descripcion;
        private DateTime fecha;
        private DateTime fechaEntrega;
        private ENEstadosPieza estado;
        private float precioMax;
        private bool negociadoAutomatico;
                
        private int idCliente;

        /// <summary>
        /// Identificador de la solicitud
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Identificador de la solicitud en la aplicación local.
        /// </summary>
        public int IdLocal
        {
            get { return idLocal; }
            set { idLocal = value; }
        }

        /// <summary>
        /// Descripción de la solicitud.
        /// </summary>
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        /// <summary>
        /// Fecha de creación de la solicitud.
        /// </summary>
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        /// <summary>
        /// Indica si está activado el negociado automático.
        /// </summary>
        public bool NegociadoAutomatico
        {
            get { return negociadoAutomatico; }
            set { negociadoAutomatico = value; }
        }

        /// <summary>
        /// Condición de fecha de entrega para la solicitud.
        /// </summary>
        public DateTime FechaEntrega
        {
            get { return fechaEntrega; }
            set { fechaEntrega = value; }
        }

        /// <summary>
        /// Condición de estado para la solicitud.
        /// </summary>
        public ENEstadosPieza Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        /// <summary>
        /// Condición de precio máximo para la solicitud.
        /// </summary>
        public float PrecioMax
        {
            get { return precioMax; }
            set { precioMax = value; }
        }

        /// <summary>
        /// Identificador del cliente que ha realizado la solicitud.
        /// </summary>
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
    }
}
