namespace Aplicación_de_Taller
{
    partial class FormVerEmpleados
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
            this.labelControlTitulo = new DevExpress.XtraEditors.LabelControl();
            this.gridControlEmpleados = new DevExpress.XtraGrid.GridControl();
            this.gridViewEmpleados = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEmpleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControlTitulo
            // 
            this.labelControlTitulo.Appearance.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelControlTitulo.Appearance.Options.UseFont = true;
            this.labelControlTitulo.Location = new System.Drawing.Point(3, 3);
            this.labelControlTitulo.Name = "labelControlTitulo";
            this.labelControlTitulo.Size = new System.Drawing.Size(112, 31);
            this.labelControlTitulo.TabIndex = 2;
            this.labelControlTitulo.Text = "Empleados";
            // 
            // gridControlEmpleados
            // 
            this.gridControlEmpleados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlEmpleados.Location = new System.Drawing.Point(0, 40);
            this.gridControlEmpleados.MainView = this.gridViewEmpleados;
            this.gridControlEmpleados.Margin = new System.Windows.Forms.Padding(0);
            this.gridControlEmpleados.Name = "gridControlEmpleados";
            this.gridControlEmpleados.Size = new System.Drawing.Size(771, 331);
            this.gridControlEmpleados.TabIndex = 5;
            this.gridControlEmpleados.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEmpleados});
            this.gridControlEmpleados.DoubleClick += new System.EventHandler(this.gridControlEmpleados_DoubleClick);
            // 
            // gridViewEmpleados
            // 
            this.gridViewEmpleados.GridControl = this.gridControlEmpleados;
            this.gridViewEmpleados.Name = "gridViewEmpleados";
            this.gridViewEmpleados.OptionsBehavior.Editable = false;
            this.gridViewEmpleados.OptionsCustomization.AllowGroup = false;
            this.gridViewEmpleados.OptionsCustomization.AllowRowSizing = true;
            this.gridViewEmpleados.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewEmpleados.OptionsSelection.MultiSelect = true;
            this.gridViewEmpleados.OptionsView.ShowGroupPanel = false;
            // 
            // FormVerEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlEmpleados);
            this.Controls.Add(this.labelControlTitulo);
            this.Name = "FormVerEmpleados";
            this.Size = new System.Drawing.Size(771, 371);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEmpleados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControlTitulo;
        private DevExpress.XtraGrid.GridControl gridControlEmpleados;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEmpleados;
    }
}
