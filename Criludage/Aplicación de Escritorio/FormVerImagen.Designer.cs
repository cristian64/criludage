namespace Aplicación_de_Escritorio
{
    partial class FormVerImagen
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
            this.pictureEditFoto = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditFoto.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEditFoto
            // 
            this.pictureEditFoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEditFoto.Location = new System.Drawing.Point(0, 0);
            this.pictureEditFoto.Name = "pictureEditFoto";
            this.pictureEditFoto.Properties.AllowFocused = false;
            this.pictureEditFoto.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.pictureEditFoto.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEditFoto.Properties.NullText = "Sin foto";
            this.pictureEditFoto.Properties.ReadOnly = true;
            this.pictureEditFoto.Properties.ShowMenu = false;
            this.pictureEditFoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pictureEditFoto.Size = new System.Drawing.Size(292, 266);
            this.pictureEditFoto.TabIndex = 4;
            this.pictureEditFoto.Click += new System.EventHandler(this.pictureEditFoto_Click);
            // 
            // FormVerImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.pictureEditFoto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormVerImagen";
            this.Text = "FormVerImagen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditFoto.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEditFoto;
    }
}