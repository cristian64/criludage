﻿namespace Aplicación_de_Escritorio
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
            this.labelControlTitulo = new DevExpress.XtraEditors.LabelControl();
            this.gridControlSolicitudes = new DevExpress.XtraGrid.GridControl();
            this.gridViewSolicitudes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.timer = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSolicitudes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControlTitulo
            // 
            this.labelControlTitulo.Appearance.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelControlTitulo.Appearance.Options.UseFont = true;
            this.labelControlTitulo.Location = new System.Drawing.Point(3, 3);
            this.labelControlTitulo.Name = "labelControlTitulo";
            this.labelControlTitulo.Size = new System.Drawing.Size(111, 31);
            this.labelControlTitulo.TabIndex = 2;
            this.labelControlTitulo.Text = "Solicitudes";
            // 
            // gridControlSolicitudes
            // 
            this.gridControlSolicitudes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlSolicitudes.Location = new System.Drawing.Point(0, 40);
            this.gridControlSolicitudes.MainView = this.gridViewSolicitudes;
            this.gridControlSolicitudes.Margin = new System.Windows.Forms.Padding(0);
            this.gridControlSolicitudes.Name = "gridControlSolicitudes";
            this.gridControlSolicitudes.Size = new System.Drawing.Size(978, 386);
            this.gridControlSolicitudes.TabIndex = 4;
            this.gridControlSolicitudes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSolicitudes});
            // 
            // gridViewSolicitudes
            // 
            this.gridViewSolicitudes.Appearance.FocusedRow.BackColor = System.Drawing.Color.White;
            this.gridViewSolicitudes.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewSolicitudes.Appearance.FocusedRow.Image = global::Aplicación_de_Escritorio.Properties.Resources.fila;
            this.gridViewSolicitudes.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewSolicitudes.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewSolicitudes.Appearance.FocusedRow.Options.UseImage = true;
            this.gridViewSolicitudes.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.White;
            this.gridViewSolicitudes.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewSolicitudes.Appearance.HideSelectionRow.Image = global::Aplicación_de_Escritorio.Properties.Resources.fila;
            this.gridViewSolicitudes.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridViewSolicitudes.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewSolicitudes.Appearance.HideSelectionRow.Options.UseImage = true;
            this.gridViewSolicitudes.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewSolicitudes.GridControl = this.gridControlSolicitudes;
            this.gridViewSolicitudes.Name = "gridViewSolicitudes";
            this.gridViewSolicitudes.OptionsBehavior.Editable = false;
            this.gridViewSolicitudes.OptionsCustomization.AllowGroup = false;
            this.gridViewSolicitudes.OptionsCustomization.AllowRowSizing = true;
            this.gridViewSolicitudes.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewSolicitudes.OptionsSelection.MultiSelect = true;
            this.gridViewSolicitudes.OptionsView.ShowGroupPanel = false;
            this.gridViewSolicitudes.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewSolicitudes_RowStyle);
            this.gridViewSolicitudes.DoubleClick += new System.EventHandler(this.gridViewSolicitudes_DoubleClick);
            this.gridViewSolicitudes.RowCountChanged += new System.EventHandler(this.gridViewSolicitudes_RowCountChanged);
            // 
            // timer
            // 
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FormVerSolicitudes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlSolicitudes);
            this.Controls.Add(this.labelControlTitulo);
            this.Name = "FormVerSolicitudes";
            this.Size = new System.Drawing.Size(978, 426);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSolicitudes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSolicitudes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControlTitulo;
        private DevExpress.XtraGrid.GridControl gridControlSolicitudes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSolicitudes;
        private System.Windows.Forms.Timer timer;



    }
}
