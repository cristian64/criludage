﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Biblioteca_Común;
using Biblioteca_de_Entidades_de_Negocio;

namespace Aplicación_de_Taller
{
    public partial class FormBase : Form
    {
        /// <summary>
        /// Instancia del formulario para evitar tiempos de espera.
        /// Así, puede ir actualizándose el formulario incluso cuando no se muestra.
        /// </summary>
        private FormVerSolicitudes formVerSolicitudes;

        /// <summary>
        /// Es el consumidor que se ejecuta en otro hilo, recibiendo los mensajes y procesándolos.
        /// </summary>
        private Consumidor consumidorSolicitudes;
        private Thread hiloConsumidorSolicitudes;
        private void consumirSolicitudes()
        {
            try
            {
                while (true)
                {
                    ENSolicitud mensaje = consumidorSolicitudes.Recibir(1) as ENSolicitud;
                    if (mensaje != null)
                    {
                        formVerSolicitudes.procesarSolicitud(mensaje);
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("consumirSolicitudes()");
                System.Console.WriteLine(e.Message);
            }
        }

        public FormBase()
        {
            InitializeComponent();
            formVerSolicitudes = new FormVerSolicitudes();

            // Se crea el consumidor de solicitudes y el hilo que consultará cada 1 segundo los mensajes pendientes.
            consumidorSolicitudes = new Consumidor(Settings.Default.servidor, Settings.Default.topic);
            hiloConsumidorSolicitudes = new Thread(consumirSolicitudes);
            hiloConsumidorSolicitudes.Start();
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            mostrarVerSolicitudes();
        }

        private void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea salir?", "Saliendo de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void toolStripButtonSolicitarPieza_Click(object sender, EventArgs e)
        {
            mostrarSolicitarPieza();
        }

        private void toolStripButtonVerSolicitudes_Click(object sender, EventArgs e)
        {
            mostrarVerSolicitudes();
        }

        public void mostrarVerSolicitudes()
        {
            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(formVerSolicitudes);
        }

        public void mostrarSolicitarPieza()
        {
            FormSolicitarPieza formSolicitarPieza = new FormSolicitarPieza(this);
            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(formSolicitarPieza);
        }

        private void barButtonItemSolicitar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mostrarSolicitarPieza();
        }

        private void barButtonItemPendientes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mostrarVerSolicitudes();
        }

        private void barButtonItemFinalizadas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarMensaje("Solicitudes archivadas", "Todavía no se ha implementado este módulo.");
        }

        /// <summary>
        /// Muestra un mensaje que se desvanece con el tiempo.
        /// </summary>
        /// <param name="titulo">Título para el mensaje. Por ejemplo "Solicitud recibida".</param>
        /// <param name="mensaje">Mensaje descriptivo.</param>
        public void MostrarMensaje(String titulo, String mensaje)
        {
            alertControl.Show(this, titulo, mensaje);
        }
    }
}
