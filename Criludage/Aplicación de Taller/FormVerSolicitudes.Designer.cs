namespace Aplicación_de_Taller
{
    partial class FormVerSolicitudes
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewSolicitudes = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.negociadoAutomatico = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.propuestasRecibidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.propuestaAceptada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSolicitudes
            // 
            this.dataGridViewSolicitudes.AllowUserToAddRows = false;
            this.dataGridViewSolicitudes.AllowUserToDeleteRows = false;
            this.dataGridViewSolicitudes.AllowUserToOrderColumns = true;
            this.dataGridViewSolicitudes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSolicitudes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.descripcion,
            this.fecha,
            this.estado,
            this.precioMax,
            this.negociadoAutomatico,
            this.fechaEntrega,
            this.propuestasRecibidas,
            this.propuestaAceptada});
            this.dataGridViewSolicitudes.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSolicitudes.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewSolicitudes.Name = "dataGridViewSolicitudes";
            this.dataGridViewSolicitudes.ReadOnly = true;
            this.dataGridViewSolicitudes.RowHeadersVisible = false;
            this.dataGridViewSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSolicitudes.Size = new System.Drawing.Size(474, 426);
            this.dataGridViewSolicitudes.TabIndex = 0;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 43;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.MinimumWidth = 100;
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // fecha
            // 
            this.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 62;
            // 
            // estado
            // 
            this.estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Width = 65;
            // 
            // precioMax
            // 
            this.precioMax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.precioMax.HeaderText = "Precio máximo";
            this.precioMax.Name = "precioMax";
            this.precioMax.ReadOnly = true;
            this.precioMax.Width = 92;
            // 
            // negociadoAutomatico
            // 
            this.negociadoAutomatico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.negociadoAutomatico.HeaderText = "Negociado automático";
            this.negociadoAutomatico.Name = "negociadoAutomatico";
            this.negociadoAutomatico.ReadOnly = true;
            this.negociadoAutomatico.Width = 108;
            // 
            // fechaEntrega
            // 
            this.fechaEntrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fechaEntrega.HeaderText = "Fecha de entrega";
            this.fechaEntrega.Name = "fechaEntrega";
            this.fechaEntrega.ReadOnly = true;
            this.fechaEntrega.Width = 106;
            // 
            // propuestasRecibidas
            // 
            this.propuestasRecibidas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.propuestasRecibidas.HeaderText = "Propuestas recibidas";
            this.propuestasRecibidas.Name = "propuestasRecibidas";
            this.propuestasRecibidas.ReadOnly = true;
            this.propuestasRecibidas.Width = 119;
            // 
            // propuestaAceptada
            // 
            this.propuestaAceptada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.propuestaAceptada.HeaderText = "Propuesta aceptada";
            this.propuestaAceptada.Name = "propuestaAceptada";
            this.propuestaAceptada.ReadOnly = true;
            this.propuestaAceptada.Width = 98;
            // 
            // FormVerSolicitudes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.dataGridViewSolicitudes);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FormVerSolicitudes";
            this.Size = new System.Drawing.Size(474, 426);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSolicitudes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSolicitudes;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioMax;
        private System.Windows.Forms.DataGridViewCheckBoxColumn negociadoAutomatico;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn propuestasRecibidas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn propuestaAceptada;



    }
}
