namespace Aplicación_de_Escritorio
{
    partial class FormRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistro));
            this.labelControlTitulo = new DevExpress.XtraEditors.LabelControl();
            this.richEditControl = new DevExpress.XtraRichEdit.RichEditControl();
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControlTitulo
            // 
            this.labelControlTitulo.Appearance.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelControlTitulo.Appearance.Options.UseFont = true;
            this.labelControlTitulo.Location = new System.Drawing.Point(3, 3);
            this.labelControlTitulo.Name = "labelControlTitulo";
            this.labelControlTitulo.Size = new System.Drawing.Size(86, 31);
            this.labelControlTitulo.TabIndex = 4;
            this.labelControlTitulo.Text = "Registro";
            // 
            // richEditControl
            // 
            this.richEditControl.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.richEditControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richEditControl.Appearance.Text.Font = new System.Drawing.Font("DejaVu Sans Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richEditControl.Appearance.Text.Options.UseFont = true;
            this.richEditControl.Location = new System.Drawing.Point(0, 40);
            this.richEditControl.Name = "richEditControl";
            this.richEditControl.Options.DocumentCapabilities.Bookmarks = DevExpress.XtraRichEdit.DocumentCapability.Hidden;
            this.richEditControl.ReadOnly = true;
            this.richEditControl.Size = new System.Drawing.Size(1123, 467);
            this.richEditControl.TabIndex = 5;
            this.richEditControl.Text = resources.GetString("richEditControl.Text");
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.SynchronizingObject = this;
            // 
            // FormRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richEditControl);
            this.Controls.Add(this.labelControlTitulo);
            this.Name = "FormRegistro";
            this.Size = new System.Drawing.Size(1123, 507);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControlTitulo;
        private DevExpress.XtraRichEdit.RichEditControl richEditControl;
        private System.IO.FileSystemWatcher fileSystemWatcher;
    }
}
