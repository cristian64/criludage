namespace Visor_de_Registro
{
    partial class VisorRegistro
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisorRegistro));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barCheckItemRefrescar = new DevExpress.XtraBars.BarCheckItem();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.gridControlRegistro = new DevExpress.XtraGrid.GridControl();
            this.gridViewRegistro = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRegistro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRegistro)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonText = null;
            this.ribbon.ApplicationIcon = global::Visor_de_Registro.Properties.Resources.transparent;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barCheckItemRefrescar});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 10;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageHeaderItemLinks.Add(this.barCheckItemRefrescar);
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(993, 48);
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // barCheckItemRefrescar
            // 
            this.barCheckItemRefrescar.Caption = "Refrescar cada cierto tiempo";
            this.barCheckItemRefrescar.Description = "Refrescar cada cierto tiempo";
            this.barCheckItemRefrescar.Glyph = global::Visor_de_Registro.Properties.Resources.refrescar;
            this.barCheckItemRefrescar.Hint = "Refrescar cada cierto tiempo";
            this.barCheckItemRefrescar.Id = 9;
            this.barCheckItemRefrescar.Name = "barCheckItemRefrescar";
            this.barCheckItemRefrescar.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItemRefrescar_CheckedChanged);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.clientPanel.Controls.Add(this.gridControlRegistro);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 48);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(993, 410);
            this.clientPanel.TabIndex = 3;
            // 
            // gridControlRegistro
            // 
            this.gridControlRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlRegistro.Location = new System.Drawing.Point(2, 3);
            this.gridControlRegistro.MainView = this.gridViewRegistro;
            this.gridControlRegistro.Margin = new System.Windows.Forms.Padding(0);
            this.gridControlRegistro.Name = "gridControlRegistro";
            this.gridControlRegistro.Size = new System.Drawing.Size(989, 405);
            this.gridControlRegistro.TabIndex = 5;
            this.gridControlRegistro.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRegistro});
            // 
            // gridViewRegistro
            // 
            this.gridViewRegistro.Appearance.FocusedRow.BackColor = System.Drawing.Color.White;
            this.gridViewRegistro.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewRegistro.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewRegistro.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewRegistro.Appearance.FocusedRow.Options.UseImage = true;
            this.gridViewRegistro.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.White;
            this.gridViewRegistro.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewRegistro.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridViewRegistro.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewRegistro.Appearance.HideSelectionRow.Options.UseImage = true;
            this.gridViewRegistro.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewRegistro.GridControl = this.gridControlRegistro;
            this.gridViewRegistro.Name = "gridViewRegistro";
            this.gridViewRegistro.OptionsBehavior.Editable = false;
            this.gridViewRegistro.OptionsCustomization.AllowRowSizing = true;
            this.gridViewRegistro.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewRegistro.OptionsSelection.MultiSelect = true;
            this.gridViewRegistro.RowCountChanged += new System.EventHandler(this.gridViewRegistro_RowCountChanged);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // VisorRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 458);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VisorRegistro";
            this.Ribbon = this.ribbon;
            this.Text = "Visor de Registro";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRegistro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRegistro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.XtraGrid.GridControl gridControlRegistro;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRegistro;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraBars.BarCheckItem barCheckItemRefrescar;

    }
}

