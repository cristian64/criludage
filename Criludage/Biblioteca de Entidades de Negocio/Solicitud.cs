using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Biblioteca_de_Entidades_de_Negocio
{
    public class Solicitud
    {
        private int id;
        private String descripcion;
        private DateTime fecha;
        private bool negociadoAutomatico;
        private DateTime fechaEntrega;
        private EstadosPieza estado;
        private float precioMax;
                
        private Cliente cliente;
        private ArrayList propuestas;
        private Propuesta propuestaAceptada;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Solicitud()
        {
            id = 0;
            descripcion = "";
            fecha = DateTime.Now;
            negociadoAutomatico = false;
            fechaEntrega = DateTime.Now.AddDays(4);
            estado = EstadosPieza.USADA;
            precioMax = 0;

            cliente = null;
            propuestas = new ArrayList();
            propuestaAceptada = null;
        }

        /// <summary>
        /// Identificador de la solicitud
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Descripción de la solicitud
        /// </summary>
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        /// <summary>
        /// Fecha de creación de la solicitud
        /// </summary>
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        /// <summary>
        /// Indica si está activado el negociado automático
        /// </summary>
        public bool NegociadoAutomatico
        {
            get { return negociadoAutomatico; }
            set { negociadoAutomatico = value; }
        }

        /// <summary>
        /// Condición de fecha de entrega para la solicitud
        /// </summary>
        public DateTime FechaEntrega
        {
            get { return fechaEntrega; }
            set { fechaEntrega = value; }
        }

        /// <summary>
        /// Condición de estado para la solicitud
        /// </summary>
        public EstadosPieza Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        /// <summary>
        /// Condición de precio máximo para la solicitud
        /// </summary>
        public float PrecioMax
        {
            get { return precioMax; }
            set { precioMax = value; }
        }

        /// <summary>
        /// Cliente que ha realizado la solicitud
        /// </summary>
        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        /// <summary>
        /// Propuestas realizadas a la solicitud
        /// </summary>
        public ArrayList Propuestas
        {
            get { return propuestas; }
            set { propuestas = value; }
        }

        /// <summary>
        /// Propuesta aceptada de la solicitud
        /// </summary>
        public Propuesta PropuestaAceptada
        {
            get { return propuestaAceptada; }
            set { propuestaAceptada = value; }
        }

    }
}
