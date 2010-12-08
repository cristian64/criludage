namespace Aplicación_de_Taller
{
    partial class FormBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBase));
            this.panelContenido = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonVerSolicitudes = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSolicitarPieza = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContenido.Location = new System.Drawing.Point(0, 49);
            this.panelContenido.Margin = new System.Windows.Forms.Padding(0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(536, 192);
            this.panelContenido.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonVerSolicitudes,
            this.toolStripButtonSolicitarPieza});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(536, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonVerSolicitudes
            // 
            this.toolStripButtonVerSolicitudes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVerSolicitudes.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonVerSolicitudes.Image")));
            this.toolStripButtonVerSolicitudes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVerSolicitudes.Name = "toolStripButtonVerSolicitudes";
            this.toolStripButtonVerSolicitudes.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonVerSolicitudes.Text = "toolStripButtonVerSolicitudes";
            this.toolStripButtonVerSolicitudes.ToolTipText = "Ver solicitudes";
            this.toolStripButtonVerSolicitudes.Click += new System.EventHandler(this.toolStripButtonVerSolicitudes_Click);
            // 
            // toolStripButtonSolicitarPieza
            // 
            this.toolStripButtonSolicitarPieza.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSolicitarPieza.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSolicitarPieza.Image")));
            this.toolStripButtonSolicitarPieza.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSolicitarPieza.Name = "toolStripButtonSolicitarPieza";
            this.toolStripButtonSolicitarPieza.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSolicitarPieza.Text = "toolStripButtonSolicitarPieza";
            this.toolStripButtonSolicitarPieza.ToolTipText = "Solicitar nueva pieza";
            this.toolStripButtonSolicitarPieza.Click += new System.EventHandler(this.toolStripButtonSolicitarPieza_Click);
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 263);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panelContenido);
            this.Name = "FormBase";
            this.Text = "Aplicación de taller";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormBase_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonVerSolicitudes;
        private System.Windows.Forms.ToolStripButton toolStripButtonSolicitarPieza;
    }
}