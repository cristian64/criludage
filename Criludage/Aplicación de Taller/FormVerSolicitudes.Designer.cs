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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerSolicitudes));
            this.gridSolicitudes = new System.Windows.Forms.DataGridView();
            this.gridcolumnDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridcolumnFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridcolumnNegociadoAutomatico = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSolicitudes
            // 
            this.gridSolicitudes.AllowUserToAddRows = false;
            this.gridSolicitudes.AllowUserToDeleteRows = false;
            this.gridSolicitudes.AllowUserToResizeColumns = false;
            this.gridSolicitudes.AllowUserToResizeRows = false;
            this.gridSolicitudes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridSolicitudes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridcolumnDescripcion,
            this.gridcolumnFecha,
            this.gridcolumnNegociadoAutomatico});
            this.gridSolicitudes.Location = new System.Drawing.Point(28, 25);
            this.gridSolicitudes.Name = "gridSolicitudes";
            this.gridSolicitudes.ReadOnly = true;
            this.gridSolicitudes.Size = new System.Drawing.Size(700, 227);
            this.gridSolicitudes.TabIndex = 0;
            // 
            // gridcolumnDescripcion
            // 
            this.gridcolumnDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridcolumnDescripcion.HeaderText = "Descripción";
            this.gridcolumnDescripcion.Name = "gridcolumnDescripcion";
            this.gridcolumnDescripcion.ReadOnly = true;
            // 
            // gridcolumnFecha
            // 
            this.gridcolumnFecha.HeaderText = "Fecha";
            this.gridcolumnFecha.Name = "gridcolumnFecha";
            this.gridcolumnFecha.ReadOnly = true;
            this.gridcolumnFecha.Width = 150;
            // 
            // gridcolumnNegociadoAutomatico
            // 
            this.gridcolumnNegociadoAutomatico.HeaderText = "Negociado automático";
            this.gridcolumnNegociadoAutomatico.Name = "gridcolumnNegociadoAutomatico";
            this.gridcolumnNegociadoAutomatico.ReadOnly = true;
            this.gridcolumnNegociadoAutomatico.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(524, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Arriba son muchas columnas, yo creo que mejor poner aqui abajo la informacion de " +
                "cada una cuando pinchas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(369, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "si alguien sabe quitar esa primera columna que no tiene nada que lo quite xD";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 348);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(327, 117);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // FormVerSolicitudes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridSolicitudes);
            this.Name = "FormVerSolicitudes";
            this.Size = new System.Drawing.Size(760, 540);
            ((System.ComponentModel.ISupportInitialize)(this.gridSolicitudes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridSolicitudes;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridcolumnDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridcolumnFecha;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridcolumnNegociadoAutomatico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;


    }
}
