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
            this.barButtonItemTaller = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDesguace = new DevExpress.XtraBars.BarButtonItem();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.wizardControl = new DevExpress.XtraWizard.WizardControl();
            this.wizardPageBienvenida = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.wizardPageUbicacionServidor = new DevExpress.XtraWizard.WizardPage();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.textEditUDDI = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.wizardPageFinalizar = new DevExpress.XtraWizard.CompletionWizardPage();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.wizardPageUsuarioServidor = new DevExpress.XtraWizard.WizardPage();
            this.textEditCorreoElectronico = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.textEditServicioUsuario = new DevExpress.XtraEditors.TextEdit();
            this.textEditServicioContrasena2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.dropDownButtonTipoAplicacion = new DevExpress.XtraEditors.DropDownButton();
            this.applicationMenuTiposAplicacion = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.textEditServicioContrasena = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.wizardPagePrimerEmpleado = new DevExpress.XtraWizard.WizardPage();
            this.checkEditAdministrador = new DevExpress.XtraEditors.CheckEdit();
            this.textEditUsuario = new DevExpress.XtraEditors.TextEdit();
            this.textEditContrasena2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.textEditContrasena = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.wizardPageEnviando = new DevExpress.XtraWizard.WizardPage();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl)).BeginInit();
            this.wizardControl.SuspendLayout();
            this.wizardPageBienvenida.SuspendLayout();
            this.wizardPageUbicacionServidor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUDDI.Properties)).BeginInit();
            this.wizardPageFinalizar.SuspendLayout();
            this.wizardPageUsuarioServidor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCorreoElectronico.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditServicioUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditServicioContrasena2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenuTiposAplicacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditServicioContrasena.Properties)).BeginInit();
            this.wizardPagePrimerEmpleado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditAdministrador.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditContrasena2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditContrasena.Properties)).BeginInit();
            this.wizardPageEnviando.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.applicationMenu;
            this.ribbon.ApplicationButtonText = null;
            this.ribbon.ApplicationIcon = global::Aplicación_de_Escritorio.Properties.Resources.desplegable;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemAcercaDe,
            this.barButtonItemSalir,
            this.barButtonItemTaller,
            this.barButtonItemDesguace});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 4;
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
            // barButtonItemTaller
            // 
            this.barButtonItemTaller.Caption = "Aplicación de Taller";
            this.barButtonItemTaller.Description = "Inicializa la aplicación de los talleres";
            this.barButtonItemTaller.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.taller;
            this.barButtonItemTaller.Id = 2;
            this.barButtonItemTaller.Name = "barButtonItemTaller";
            this.barButtonItemTaller.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemTaller_ItemClick);
            // 
            // barButtonItemDesguace
            // 
            this.barButtonItemDesguace.Caption = "Aplicación de Desguace";
            this.barButtonItemDesguace.Description = "Inicializa la aplicación de los desguaces";
            this.barButtonItemDesguace.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.forklift32;
            this.barButtonItemDesguace.Id = 3;
            this.barButtonItemDesguace.Name = "barButtonItemDesguace";
            this.barButtonItemDesguace.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDesguace_ItemClick);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.wizardControl);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 48);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(724, 394);
            this.clientPanel.TabIndex = 0;
            // 
            // wizardControl
            // 
            this.wizardControl.AnimationInterval = 500;
            this.wizardControl.CancelText = "&Cancelar";
            this.wizardControl.Controls.Add(this.wizardPageBienvenida);
            this.wizardControl.Controls.Add(this.wizardPageUbicacionServidor);
            this.wizardControl.Controls.Add(this.wizardPageFinalizar);
            this.wizardControl.Controls.Add(this.wizardPageUsuarioServidor);
            this.wizardControl.Controls.Add(this.wizardPagePrimerEmpleado);
            this.wizardControl.Controls.Add(this.wizardPageEnviando);
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
            this.wizardPagePrimerEmpleado,
            this.wizardPageEnviando,
            this.wizardPageFinalizar});
            this.wizardControl.PreviousText = "< &Anterior";
            this.wizardControl.Size = new System.Drawing.Size(724, 394);
            this.wizardControl.Text = "Asistente de configuración";
            this.wizardControl.TitleImage = global::Aplicación_de_Escritorio.Properties.Resources.panda;
            this.wizardControl.WizardStyle = DevExpress.XtraWizard.WizardStyle.WizardAero;
            this.wizardControl.SelectedPageChanged += new DevExpress.XtraWizard.WizardPageChangedEventHandler(this.wizardControl_SelectedPageChanged);
            this.wizardControl.SelectedPageChanging += new DevExpress.XtraWizard.WizardPageChangingEventHandler(this.wizardControl_SelectedPageChanging);
            this.wizardControl.CancelClick += new System.ComponentModel.CancelEventHandler(this.wizardControl_CancelClick);
            this.wizardControl.FinishClick += new System.ComponentModel.CancelEventHandler(this.wizardControl_FinishClick);
            // 
            // wizardPageBienvenida
            // 
            this.wizardPageBienvenida.Controls.Add(this.labelControl2);
            this.wizardPageBienvenida.Controls.Add(this.labelControl1);
            this.wizardPageBienvenida.IntroductionText = resources.GetString("wizardPageBienvenida.IntroductionText");
            this.wizardPageBienvenida.Name = "wizardPageBienvenida";
            this.wizardPageBienvenida.ProceedText = "Pulsa siguiente para continuar";
            this.wizardPageBienvenida.Size = new System.Drawing.Size(664, 231);
            this.wizardPageBienvenida.Text = "Bienvenido a Criludage";
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.Location = new System.Drawing.Point(3, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(658, 52);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = resources.GetString("labelControl2.Text");
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Location = new System.Drawing.Point(3, 215);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(144, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Pulsa siguiente para empezar.";
            // 
            // wizardPageUbicacionServidor
            // 
            this.wizardPageUbicacionServidor.Controls.Add(this.labelControl5);
            this.wizardPageUbicacionServidor.Controls.Add(this.textEditUDDI);
            this.wizardPageUbicacionServidor.Controls.Add(this.labelControl3);
            this.wizardPageUbicacionServidor.DescriptionText = "Rellene el siguiente formulario con los datos del servidor en el que se ubica el " +
                "Servicio de Gestión de Compra";
            this.wizardPageUbicacionServidor.Name = "wizardPageUbicacionServidor";
            this.wizardPageUbicacionServidor.Size = new System.Drawing.Size(664, 231);
            this.wizardPageUbicacionServidor.Text = "Ubicación del servidor";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(56, 57);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(127, 13);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Servidor de servicios UDDI";
            // 
            // textEditUDDI
            // 
            this.textEditUDDI.EditValue = "";
            this.dxErrorProvider.SetIconAlignment(this.textEditUDDI, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.textEditUDDI.Location = new System.Drawing.Point(189, 50);
            this.textEditUDDI.MenuManager = this.ribbon;
            this.textEditUDDI.Name = "textEditUDDI";
            this.textEditUDDI.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.textEditUDDI.Properties.Appearance.Options.UseFont = true;
            this.textEditUDDI.Size = new System.Drawing.Size(395, 26);
            this.textEditUDDI.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(3, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(583, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Rellene el siguiente formulario con la dirección de la máquina en la que se ubica" +
                " el servidor de descubrimiento de servicios.";
            // 
            // wizardPageFinalizar
            // 
            this.wizardPageFinalizar.Controls.Add(this.labelControl9);
            this.wizardPageFinalizar.Controls.Add(this.labelControl4);
            this.wizardPageFinalizar.FinishText = "El asistente ha finalizado correctamente.";
            this.wizardPageFinalizar.Name = "wizardPageFinalizar";
            this.wizardPageFinalizar.ProceedText = "Pulsa finalizar para abrir la aplicación";
            this.wizardPageFinalizar.Size = new System.Drawing.Size(664, 231);
            this.wizardPageFinalizar.Text = "Finalizando el asistente";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl9.Appearance.ForeColor = System.Drawing.Color.Green;
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Appearance.Options.UseForeColor = true;
            this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl9.Location = new System.Drawing.Point(3, 3);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(658, 13);
            this.labelControl9.TabIndex = 2;
            this.labelControl9.Text = "La configuración ha finalizado correctamente.";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl4.Location = new System.Drawing.Point(3, 215);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(180, 13);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "Pulsa finalizar para iniciar la aplicación";
            // 
            // wizardPageUsuarioServidor
            // 
            this.wizardPageUsuarioServidor.Controls.Add(this.textEditCorreoElectronico);
            this.wizardPageUsuarioServidor.Controls.Add(this.labelControl12);
            this.wizardPageUsuarioServidor.Controls.Add(this.textEditServicioUsuario);
            this.wizardPageUsuarioServidor.Controls.Add(this.textEditServicioContrasena2);
            this.wizardPageUsuarioServidor.Controls.Add(this.labelControl11);
            this.wizardPageUsuarioServidor.Controls.Add(this.dropDownButtonTipoAplicacion);
            this.wizardPageUsuarioServidor.Controls.Add(this.labelControl7);
            this.wizardPageUsuarioServidor.Controls.Add(this.textEditServicioContrasena);
            this.wizardPageUsuarioServidor.Controls.Add(this.labelControl8);
            this.wizardPageUsuarioServidor.Controls.Add(this.labelControl10);
            this.wizardPageUsuarioServidor.DescriptionText = "Datos de usuario con los que se conectará al Servicio de Gestión de Compra";
            this.wizardPageUsuarioServidor.Name = "wizardPageUsuarioServidor";
            this.wizardPageUsuarioServidor.Size = new System.Drawing.Size(664, 231);
            this.wizardPageUsuarioServidor.Text = "Registro de usuario en el servicio";
            // 
            // textEditCorreoElectronico
            // 
            this.textEditCorreoElectronico.EditValue = "";
            this.dxErrorProvider.SetIconAlignment(this.textEditCorreoElectronico, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.textEditCorreoElectronico.Location = new System.Drawing.Point(189, 120);
            this.textEditCorreoElectronico.MenuManager = this.ribbon;
            this.textEditCorreoElectronico.Name = "textEditCorreoElectronico";
            this.textEditCorreoElectronico.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.textEditCorreoElectronico.Properties.Appearance.Options.UseFont = true;
            this.textEditCorreoElectronico.Size = new System.Drawing.Size(395, 26);
            this.textEditCorreoElectronico.TabIndex = 3;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(95, 127);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(88, 13);
            this.labelControl12.TabIndex = 18;
            this.labelControl12.Text = "Correo electrónico";
            // 
            // textEditServicioUsuario
            // 
            this.textEditServicioUsuario.EditValue = "";
            this.dxErrorProvider.SetIconAlignment(this.textEditServicioUsuario, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.textEditServicioUsuario.Location = new System.Drawing.Point(189, 50);
            this.textEditServicioUsuario.MenuManager = this.ribbon;
            this.textEditServicioUsuario.Name = "textEditServicioUsuario";
            this.textEditServicioUsuario.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.textEditServicioUsuario.Properties.Appearance.Options.UseFont = true;
            this.textEditServicioUsuario.Size = new System.Drawing.Size(395, 26);
            this.textEditServicioUsuario.TabIndex = 0;
            // 
            // textEditServicioContrasena2
            // 
            this.textEditServicioContrasena2.EditValue = "";
            this.dxErrorProvider.SetIconAlignment(this.textEditServicioContrasena2, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.textEditServicioContrasena2.Location = new System.Drawing.Point(390, 85);
            this.textEditServicioContrasena2.MenuManager = this.ribbon;
            this.textEditServicioContrasena2.Name = "textEditServicioContrasena2";
            this.textEditServicioContrasena2.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.textEditServicioContrasena2.Properties.Appearance.Options.UseFont = true;
            this.textEditServicioContrasena2.Properties.PasswordChar = '●';
            this.textEditServicioContrasena2.Size = new System.Drawing.Size(194, 26);
            this.textEditServicioContrasena2.TabIndex = 2;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(110, 171);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(73, 13);
            this.labelControl11.TabIndex = 13;
            this.labelControl11.Text = "Tipo de usuario";
            // 
            // dropDownButtonTipoAplicacion
            // 
            this.dropDownButtonTipoAplicacion.DropDownControl = this.applicationMenuTiposAplicacion;
            this.dropDownButtonTipoAplicacion.Location = new System.Drawing.Point(189, 154);
            this.dropDownButtonTipoAplicacion.MenuManager = this.ribbon;
            this.dropDownButtonTipoAplicacion.Name = "dropDownButtonTipoAplicacion";
            this.dropDownButtonTipoAplicacion.Size = new System.Drawing.Size(127, 46);
            this.dropDownButtonTipoAplicacion.TabIndex = 4;
            this.dropDownButtonTipoAplicacion.Click += new System.EventHandler(this.dropDownButtonTipoAplicacion_Click);
            // 
            // applicationMenuTiposAplicacion
            // 
            this.applicationMenuTiposAplicacion.BottomPaneControlContainer = null;
            this.applicationMenuTiposAplicacion.ItemLinks.Add(this.barButtonItemTaller);
            this.applicationMenuTiposAplicacion.ItemLinks.Add(this.barButtonItemDesguace);
            this.applicationMenuTiposAplicacion.Name = "applicationMenuTiposAplicacion";
            this.applicationMenuTiposAplicacion.Ribbon = this.ribbon;
            this.applicationMenuTiposAplicacion.RightPaneControlContainer = null;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(127, 92);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(56, 13);
            this.labelControl7.TabIndex = 11;
            this.labelControl7.Text = "Contraseña";
            // 
            // textEditServicioContrasena
            // 
            this.textEditServicioContrasena.EditValue = "";
            this.dxErrorProvider.SetIconAlignment(this.textEditServicioContrasena, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.textEditServicioContrasena.Location = new System.Drawing.Point(189, 85);
            this.textEditServicioContrasena.MenuManager = this.ribbon;
            this.textEditServicioContrasena.Name = "textEditServicioContrasena";
            this.textEditServicioContrasena.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.textEditServicioContrasena.Properties.Appearance.Options.UseFont = true;
            this.textEditServicioContrasena.Properties.PasswordChar = '●';
            this.textEditServicioContrasena.Size = new System.Drawing.Size(195, 26);
            this.textEditServicioContrasena.TabIndex = 1;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(93, 57);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(90, 13);
            this.labelControl8.TabIndex = 9;
            this.labelControl8.Text = "Nombre de usuario";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(3, 3);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(367, 13);
            this.labelControl10.TabIndex = 6;
            this.labelControl10.Text = "Datos de usuario con los que se conectará al Servicio de Gestión de Compra.";
            // 
            // wizardPagePrimerEmpleado
            // 
            this.wizardPagePrimerEmpleado.Controls.Add(this.checkEditAdministrador);
            this.wizardPagePrimerEmpleado.Controls.Add(this.textEditUsuario);
            this.wizardPagePrimerEmpleado.Controls.Add(this.textEditContrasena2);
            this.wizardPagePrimerEmpleado.Controls.Add(this.labelControl13);
            this.wizardPagePrimerEmpleado.Controls.Add(this.textEditContrasena);
            this.wizardPagePrimerEmpleado.Controls.Add(this.labelControl14);
            this.wizardPagePrimerEmpleado.Controls.Add(this.labelControl16);
            this.wizardPagePrimerEmpleado.DescriptionText = "Datos para el primer empleado de la aplicación que tendrá privilegios de administ" +
                "rador";
            this.wizardPagePrimerEmpleado.Name = "wizardPagePrimerEmpleado";
            this.wizardPagePrimerEmpleado.Size = new System.Drawing.Size(664, 231);
            this.wizardPagePrimerEmpleado.Text = "Introduciendo el primer empleado";
            // 
            // checkEditAdministrador
            // 
            this.checkEditAdministrador.EditValue = true;
            this.checkEditAdministrador.Location = new System.Drawing.Point(187, 120);
            this.checkEditAdministrador.MenuManager = this.ribbon;
            this.checkEditAdministrador.Name = "checkEditAdministrador";
            this.checkEditAdministrador.Properties.AutoWidth = true;
            this.checkEditAdministrador.Properties.Caption = "Administrador";
            this.checkEditAdministrador.Properties.ReadOnly = true;
            this.checkEditAdministrador.Size = new System.Drawing.Size(89, 19);
            this.checkEditAdministrador.TabIndex = 24;
            // 
            // textEditUsuario
            // 
            this.textEditUsuario.EditValue = "";
            this.dxErrorProvider.SetIconAlignment(this.textEditUsuario, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.textEditUsuario.Location = new System.Drawing.Point(189, 50);
            this.textEditUsuario.MenuManager = this.ribbon;
            this.textEditUsuario.Name = "textEditUsuario";
            this.textEditUsuario.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.textEditUsuario.Properties.Appearance.Options.UseFont = true;
            this.textEditUsuario.Size = new System.Drawing.Size(395, 26);
            this.textEditUsuario.TabIndex = 0;
            // 
            // textEditContrasena2
            // 
            this.textEditContrasena2.EditValue = "";
            this.dxErrorProvider.SetIconAlignment(this.textEditContrasena2, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.textEditContrasena2.Location = new System.Drawing.Point(390, 85);
            this.textEditContrasena2.MenuManager = this.ribbon;
            this.textEditContrasena2.Name = "textEditContrasena2";
            this.textEditContrasena2.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.textEditContrasena2.Properties.Appearance.Options.UseFont = true;
            this.textEditContrasena2.Properties.PasswordChar = '●';
            this.textEditContrasena2.Size = new System.Drawing.Size(194, 26);
            this.textEditContrasena2.TabIndex = 2;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(127, 92);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(56, 13);
            this.labelControl13.TabIndex = 21;
            this.labelControl13.Text = "Contraseña";
            // 
            // textEditContrasena
            // 
            this.textEditContrasena.EditValue = "";
            this.dxErrorProvider.SetIconAlignment(this.textEditContrasena, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.textEditContrasena.Location = new System.Drawing.Point(189, 85);
            this.textEditContrasena.MenuManager = this.ribbon;
            this.textEditContrasena.Name = "textEditContrasena";
            this.textEditContrasena.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.textEditContrasena.Properties.Appearance.Options.UseFont = true;
            this.textEditContrasena.Properties.PasswordChar = '●';
            this.textEditContrasena.Size = new System.Drawing.Size(195, 26);
            this.textEditContrasena.TabIndex = 1;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(93, 57);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(90, 13);
            this.labelControl14.TabIndex = 19;
            this.labelControl14.Text = "Nombre de usuario";
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(3, 3);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(410, 13);
            this.labelControl16.TabIndex = 17;
            this.labelControl16.Text = "Datos para el primer empleado de la aplicación que tendrá privilegios de administ" +
                "rador";
            // 
            // wizardPageEnviando
            // 
            this.wizardPageEnviando.Controls.Add(this.labelControl17);
            this.wizardPageEnviando.Controls.Add(this.labelControl15);
            this.wizardPageEnviando.Name = "wizardPageEnviando";
            this.wizardPageEnviando.Size = new System.Drawing.Size(664, 231);
            this.wizardPageEnviando.Text = "Enviando información";
            // 
            // labelControl17
            // 
            this.labelControl17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl17.Location = new System.Drawing.Point(3, 215);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(259, 13);
            this.labelControl17.TabIndex = 6;
            this.labelControl17.Text = "Pulsa enviar para validar la información en el servidor.";
            // 
            // labelControl15
            // 
            this.labelControl15.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl15.Location = new System.Drawing.Point(3, 3);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(658, 52);
            this.labelControl15.TabIndex = 4;
            this.labelControl15.Text = resources.GetString("labelControl15.Text");
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // FormPrimeraVez
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 442);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormPrimeraVez";
            this.Ribbon = this.ribbon;
            this.Text = "Abriendo la aplicación por primera vez - Criludage";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl)).EndInit();
            this.wizardControl.ResumeLayout(false);
            this.wizardPageBienvenida.ResumeLayout(false);
            this.wizardPageBienvenida.PerformLayout();
            this.wizardPageUbicacionServidor.ResumeLayout(false);
            this.wizardPageUbicacionServidor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUDDI.Properties)).EndInit();
            this.wizardPageFinalizar.ResumeLayout(false);
            this.wizardPageFinalizar.PerformLayout();
            this.wizardPageUsuarioServidor.ResumeLayout(false);
            this.wizardPageUsuarioServidor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCorreoElectronico.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditServicioUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditServicioContrasena2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenuTiposAplicacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditServicioContrasena.Properties)).EndInit();
            this.wizardPagePrimerEmpleado.ResumeLayout(false);
            this.wizardPagePrimerEmpleado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditAdministrador.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditContrasena2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditContrasena.Properties)).EndInit();
            this.wizardPageEnviando.ResumeLayout(false);
            this.wizardPageEnviando.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
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
        private DevExpress.XtraWizard.WizardPage wizardPagePrimerEmpleado;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit textEditUDDI;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit textEditServicioContrasena;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.DropDownButton dropDownButtonTipoAplicacion;
        private DevExpress.XtraEditors.TextEdit textEditServicioUsuario;
        private DevExpress.XtraEditors.TextEdit textEditServicioContrasena2;
        private DevExpress.XtraEditors.TextEdit textEditCorreoElectronico;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenuTiposAplicacion;
        private DevExpress.XtraBars.BarButtonItem barButtonItemTaller;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDesguace;
        private DevExpress.XtraEditors.TextEdit textEditUsuario;
        private DevExpress.XtraEditors.TextEdit textEditContrasena2;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.TextEdit textEditContrasena;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit checkEditAdministrador;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraWizard.WizardPage wizardPageEnviando;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl17;
    }
}