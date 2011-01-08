namespace Aplicación_de_Escritorio
{
    partial class FormPrimeraVez
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrimeraVez));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.barButtonItemAcercaDe = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSalir = new DevExpress.XtraBars.BarButtonItem();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.wizardControl = new DevExpress.XtraWizard.WizardControl();
            this.wizardPageBienvenida = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wizardPageUbicacionServidor = new DevExpress.XtraWizard.WizardPage();
            this.wizardPageFinalizar = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wizardPageUsuarioServidor = new DevExpress.XtraWizard.WizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl)).BeginInit();
            this.wizardControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.applicationMenu;
            this.ribbon.ApplicationButtonText = null;
            this.ribbon.ApplicationIcon = global::Aplicación_de_Escritorio.Properties.Resources.desplegable;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemAcercaDe,
            this.barButtonItemSalir});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 2;
            this.ribbon.Name = "ribbon";
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.Size = new System.Drawing.Size(724, 48);
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
            this.barButtonItemAcercaDe.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.panda;
            this.barButtonItemAcercaDe.Id = 0;
            this.barButtonItemAcercaDe.Name = "barButtonItemAcercaDe";
            this.barButtonItemAcercaDe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAcercaDe_ItemClick);
            // 
            // barButtonItemSalir
            // 
            this.barButtonItemSalir.Caption = "Salir";
            this.barButtonItemSalir.Description = "Cancela el acceso a la aplicación";
            this.barButtonItemSalir.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.salir;
            this.barButtonItemSalir.Id = 1;
            this.barButtonItemSalir.Name = "barButtonItemSalir";
            this.barButtonItemSalir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSalir_ItemClick);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.wizardControl);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 48);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(724, 401);
            this.clientPanel.TabIndex = 2;
            // 
            // wizardControl
            // 
            this.wizardControl.AnimationInterval = 500;
            this.wizardControl.CancelText = "&Cancelar";
            this.wizardControl.Controls.Add(this.wizardPageBienvenida);
            this.wizardControl.Controls.Add(this.wizardPageUbicacionServidor);
            this.wizardControl.Controls.Add(this.wizardPageFinalizar);
            this.wizardControl.Controls.Add(this.wizardPageUsuarioServidor);
            this.wizardControl.Controls.Add(this.wizardPage1);
            this.wizardControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl.FinishText = "&Finalizar";
            this.wizardControl.HelpText = "&Ayuda";
            this.wizardControl.Image = global::Aplicación_de_Escritorio.Properties.Resources.panda256;
            this.wizardControl.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.wizardControl.ImageWidth = 240;
            this.wizardControl.Location = new System.Drawing.Point(0, 0);
            this.wizardControl.Name = "wizardControl";
            this.wizardControl.NextText = "&Siguiente >";
            this.wizardControl.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.wizardPageBienvenida,
            this.wizardPageUbicacionServidor,
            this.wizardPageUsuarioServidor,
            this.wizardPage1,
            this.wizardPageFinalizar});
            this.wizardControl.PreviousText = "< &Anterior";
            this.wizardControl.Size = new System.Drawing.Size(724, 401);
            this.wizardControl.Text = "";
            this.wizardControl.CancelClick += new System.ComponentModel.CancelEventHandler(this.wizardControl_CancelClick);
            this.wizardControl.FinishClick += new System.ComponentModel.CancelEventHandler(this.wizardControl_FinishClick);
            // 
            // wizardPageBienvenida
            // 
            this.wizardPageBienvenida.IntroductionText = resources.GetString("wizardPageBienvenida.IntroductionText");
            this.wizardPageBienvenida.Name = "wizardPageBienvenida";
            this.wizardPageBienvenida.ProceedText = "Pulsa siguiente para continuar";
            this.wizardPageBienvenida.Size = new System.Drawing.Size(452, 268);
            this.wizardPageBienvenida.Text = "Bienvenido a Criludage";
            // 
            // wizardPageUbicacionServidor
            // 
            this.wizardPageUbicacionServidor.DescriptionText = "Rellene el siguiente formulario con los datos del servidor en el que se ubica el " +
                "Servicio de Gestión de Compra";
            this.wizardPageUbicacionServidor.Name = "wizardPageUbicacionServidor";
            this.wizardPageUbicacionServidor.Size = new System.Drawing.Size(692, 256);
            this.wizardPageUbicacionServidor.Text = "Ubicación del servidor";
            // 
            // wizardPageFinalizar
            // 
            this.wizardPageFinalizar.FinishText = "El asistente ha finalizado correctamente.";
            this.wizardPageFinalizar.Name = "wizardPageFinalizar";
            this.wizardPageFinalizar.ProceedText = "Pulsa finalizar para abrir la aplicación";
            this.wizardPageFinalizar.Size = new System.Drawing.Size(452, 268);
            this.wizardPageFinalizar.Text = "Finalizando el asistente";
            // 
            // wizardPageUsuarioServidor
            // 
            this.wizardPageUsuarioServidor.DescriptionText = "Datos de usuario con los que se conectará al Servicio de Gestión de Compra";
            this.wizardPageUsuarioServidor.Name = "wizardPageUsuarioServidor";
            this.wizardPageUsuarioServidor.Size = new System.Drawing.Size(692, 256);
            this.wizardPageUsuarioServidor.Text = "Registro de usuario en el servicio";
            // 
            // wizardPage1
            // 
            this.wizardPage1.DescriptionText = "Datos para el primer empleado de la aplicación que tendrá privilegios de administ" +
                "rador";
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(692, 256);
            this.wizardPage1.Text = "Introduciendo el primer empleado";
            // 
            // FormPrimeraVez
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 449);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrimeraVez";
            this.Ribbon = this.ribbon;
            this.Text = "Abriendo la aplicación por primera vez - Criludage";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl)).EndInit();
            this.wizardControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.XtraWizard.WizardControl wizardControl;
        private DevExpress.XtraWizard.WelcomeWizardPage wizardPageBienvenida;
        private DevExpress.XtraWizard.WizardPage wizardPageUbicacionServidor;
        private DevExpress.XtraWizard.CompletionWizardPage wizardPageFinalizar;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAcercaDe;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSalir;
        private DevExpress.XtraWizard.WizardPage wizardPageUsuarioServidor;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
    }
}