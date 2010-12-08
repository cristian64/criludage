﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

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
        private Consumidor consumidor;

        public FormBase()
        {
            InitializeComponent();
            formVerSolicitudes = new FormVerSolicitudes();
            consumidor = new Consumidor(ConfigurationManager.AppSettings["servidor"], ConfigurationManager.AppSettings["topic"], formVerSolicitudes.procesarSolicitud);
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            mostrarVerSolicitudes();
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
    }
}
