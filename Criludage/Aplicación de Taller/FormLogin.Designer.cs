namespace Aplicación_de_Taller
{
    partial class FormLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.barButtonItemAcercaDe = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSalir = new DevExpress.XtraBars.BarButtonItem();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEditUsuario = new DevExpress.XtraEditors.TextEdit();
            this.textEditContrasena = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonEntrar = new DevExpress.XtraEditors.SimpleButton();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditContrasena.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.applicationMenu;
            this.ribbon.ApplicationButtonText = null;
            this.ribbon.ApplicationIcon = global::Aplicación_de_Taller.Properties.Resources.transparent;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemSalir,
            this.barButtonItemAcercaDe});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 2;
            this.ribbon.Name = "ribbon";
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.Size = new System.Drawing.Size(466, 48);
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // applicationMenu
            // 
            this.applicationMenu.BottomPaneControlContainer = null;
            this.applicationMenu.ItemLinks.Add(this.barButtonItemAcercaDe);
            this.applicationMenu.ItemLinks.Add(this.barButtonItemSalir);
            this.applicationMenu.Name = "applicationMenu";
            this.applicationMenu.Ribbon = this.ribbon;
            this.applicationMenu.RightPaneControlContainer = null;
            // 
            // barButtonItemAcercaDe
            // 
            this.barButtonItemAcercaDe.Caption = "Acerca de Criludage";
            this.barButtonItemAcercaDe.Description = "Información sobre la aplicación y los desarrolladores";
            this.barButtonItemAcercaDe.Glyph = global::Aplicación_de_Taller.Properties.Resources.panda;
            this.barButtonItemAcercaDe.Id = 1;
            this.barButtonItemAcercaDe.Name = "barButtonItemAcercaDe";
            // 
            // barButtonItemSalir
            // 
            this.barButtonItemSalir.Caption = "Salir";
            this.barButtonItemSalir.Description = "Cancelar el acceso a la aplicación";
            this.barButtonItemSalir.Glyph = global::Aplicación_de_Taller.Properties.Resources.salir;
            this.barButtonItemSalir.Id = 0;
            this.barButtonItemSalir.Name = "barButtonItemSalir";
            this.barButtonItemSalir.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemSalir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSalir_ItemClick);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.clientPanel.Controls.Add(this.pictureEdit1);
            this.clientPanel.Controls.Add(this.labelControl1);
            this.clientPanel.Controls.Add(this.textEditUsuario);
            this.clientPanel.Controls.Add(this.textEditContrasena);
            this.clientPanel.Controls.Add(this.simpleButtonEntrar);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 48);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(466, 493);
            this.clientPanel.TabIndex = 2;
            this.clientPanel.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.clientPanel_PreviewKeyDown);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::Aplicación_de_Taller.Properties.Resources.panda256;
            this.pictureEdit1.Location = new System.Drawing.Point(23, 24);
            this.pictureEdit1.MenuManager = this.ribbon;
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Size = new System.Drawing.Size(418, 267);
            this.pictureEdit1.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 315);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(231, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Introduce el nombre de usuario y la contraseña:";
            // 
            // textEditUsuario
            // 
            this.textEditUsuario.Location = new System.Drawing.Point(23, 334);
            this.textEditUsuario.MenuManager = this.ribbon;
            this.textEditUsuario.Name = "textEditUsuario";
            this.textEditUsuario.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 20F);
            this.textEditUsuario.Properties.Appearance.Options.UseFont = true;
            this.textEditUsuario.Size = new System.Drawing.Size(418, 39);
            this.textEditUsuario.TabIndex = 0;
            this.textEditUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEditUsuario_KeyPress);
            // 
            // textEditContrasena
            // 
            this.textEditContrasena.Location = new System.Drawing.Point(23, 379);
            this.textEditContrasena.MenuManager = this.ribbon;
            this.textEditContrasena.Name = "textEditContrasena";
            this.textEditContrasena.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 20F);
            this.textEditContrasena.Properties.Appearance.Options.UseFont = true;
            this.textEditContrasena.Properties.PasswordChar = '*';
            this.textEditContrasena.Size = new System.Drawing.Size(418, 39);
            this.textEditContrasena.TabIndex = 1;
            this.textEditContrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEditContrasena_KeyPress);
            // 
            // simpleButtonEntrar
            // 
            this.simpleButtonEntrar.Location = new System.Drawing.Point(336, 424);
            this.simpleButtonEntrar.Name = "simpleButtonEntrar";
            this.simpleButtonEntrar.Size = new System.Drawing.Size(105, 44);
            this.simpleButtonEntrar.TabIndex = 2;
            this.simpleButtonEntrar.Text = "Entrar";
            this.simpleButtonEntrar.Click += new System.EventHandler(this.simpleButtonEntrar_Click);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 541);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(474, 545);
            this.MinimumSize = new System.Drawing.Size(474, 545);
            this.Name = "FormLogin";
            this.Ribbon = this.ribbon;
            this.Text = "Inicio de sesión";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormLogin_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            this.clientPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditContrasena.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSalir;
        private DevExpress.XtraEditors.TextEdit textEditContrasena;
        private DevExpress.XtraEditors.SimpleButton simpleButtonEntrar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditUsuario;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAcercaDe;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}