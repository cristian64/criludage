namespace Aplicación_de_Escritorio
{
    partial class FormHistorialCompras
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
            this.gridControlPropuestas = new DevExpress.XtraGrid.GridControl();
            this.gridViewPropuestas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControlTitulo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPropuestas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPropuestas)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlPropuestas
            // 
            this.gridControlPropuestas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlPropuestas.Location = new System.Drawing.Point(0, 40);
            this.gridControlPropuestas.MainView = this.gridViewPropuestas;
            this.gridControlPropuestas.Margin = new System.Windows.Forms.Padding(0);
            this.gridControlPropuestas.Name = "gridControlPropuestas";
            this.gridControlPropuestas.Size = new System.Drawing.Size(516, 258);
            this.gridControlPropuestas.TabIndex = 3;
            this.gridControlPropuestas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPropuestas});
            this.gridControlPropuestas.DoubleClick += new System.EventHandler(this.gridControlPropuestas_DoubleClick);
            // 
            // gridViewPropuestas
            // 
            this.gridViewPropuestas.Appearance.FocusedRow.BackColor = System.Drawing.Color.White;
            this.gridViewPropuestas.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewPropuestas.Appearance.FocusedRow.Image = global::Aplicación_de_Escritorio.Properties.Resources.fila;
            this.gridViewPropuestas.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewPropuestas.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewPropuestas.Appearance.FocusedRow.Options.UseImage = true;
            this.gridViewPropuestas.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.White;
            this.gridViewPropuestas.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewPropuestas.Appearance.HideSelectionRow.Image = global::Aplicación_de_Escritorio.Properties.Resources.fila;
            this.gridViewPropuestas.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridViewPropuestas.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewPropuestas.Appearance.HideSelectionRow.Options.UseImage = true;
            this.gridViewPropuestas.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewPropuestas.GridControl = this.gridControlPropuestas;
            this.gridViewPropuestas.Name = "gridViewPropuestas";
            this.gridViewPropuestas.OptionsBehavior.Editable = false;
            this.gridViewPropuestas.OptionsCustomization.AllowGroup = false;
            this.gridViewPropuestas.OptionsCustomization.AllowRowSizing = true;
            this.gridViewPropuestas.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewPropuestas.OptionsSelection.MultiSelect = true;
            this.gridViewPropuestas.OptionsView.ShowGroupPanel = false;
            // 
            // labelControlTitulo
            // 
            this.labelControlTitulo.Appearance.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelControlTitulo.Appearance.Options.UseFont = true;
            this.labelControlTitulo.Location = new System.Drawing.Point(3, 3);
            this.labelControlTitulo.Name = "labelControlTitulo";
            this.labelControlTitulo.Size = new System.Drawing.Size(212, 31);
            this.labelControlTitulo.TabIndex = 4;
            this.labelControlTitulo.Text = "Historial de compras";
            // 
            // FormHistorialCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlPropuestas);
            this.Controls.Add(this.labelControlTitulo);
            this.Name = "FormHistorialCompras";
            this.Size = new System.Drawing.Size(516, 298);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPropuestas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPropuestas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlPropuestas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPropuestas;
        private DevExpress.XtraEditors.LabelControl labelControlTitulo;
    }
}
