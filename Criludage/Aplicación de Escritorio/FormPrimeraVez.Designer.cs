﻿namespace Aplicación_de_Escritorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrimeraVez));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu();
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
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.textEditServicioWeb = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.textEditActiveMq = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.wizardPageFinalizar = new DevExpress.XtraWizard.CompletionWizardPage();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.wizardPageUsuarioServidor = new DevExpress.XtraWizard.WizardPage();
            this.textEditCorreoElectronico = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.checkEditYaRegistrado = new DevExpress.XtraEditors.CheckEdit();
            this.textEditUsuario = new DevExpress.XtraEditors.TextEdit();
            this.textEditContrasena2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.dropDownButtonTipoAplicacion = new DevExpress.XtraEditors.DropDownButton();
            this.applicationMenuTiposAplicacion = new DevExpress.XtraBars.Ribbon.ApplicationMenu();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.textEditContrasena = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.textEditEmpleadoUsuario = new DevExpress.XtraEditors.TextEdit();
            this.textEditEmpleadoContrasena2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.textEditEmpleadoContrasena = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl)).BeginInit();
            this.wizardControl.SuspendLayout();
            this.wizardPageBienvenida.SuspendLayout();
            this.wizardPageUbicacionServidor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditServicioWeb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditActiveMq.Properties)).BeginInit();
            this.wizardPageFinalizar.SuspendLayout();
            this.wizardPageUsuarioServidor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCorreoElectronico.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditYaRegistrado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditContrasena2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenuTiposAplicacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditContrasena.Properties)).BeginInit();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditEmpleadoUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditEmpleadoContrasena2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditEmpleadoContrasena.Properties)).BeginInit();
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
            this.wizardControl.Size = new System.Drawing.Size(724, 394);
            this.wizardControl.Text = "Asistente de configuración";
            this.wizardControl.TitleImage = global::Aplicación_de_Escritorio.Properties.Resources.panda;
            this.wizardControl.WizardStyle = DevExpress.XtraWizard.WizardStyle.WizardAero;
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
            this.wizardPageUbicacionServidor.Controls.Add(this.labelControl6);
            this.wizardPageUbicacionServidor.Controls.Add(this.textEditServicioWeb);
            this.wizardPageUbicacionServidor.Controls.Add(this.labelControl5);
            this.wizardPageUbicacionServidor.Controls.Add(this.textEditActiveMq);
            this.wizardPageUbicacionServidor.Controls.Add(this.labelControl3);
            this.wizardPageUbicacionServidor.DescriptionText = "Rellene el siguiente formulario con los datos del servidor en el que se ubica el " +
                "Servicio de Gestión de Compra";
            this.wizardPageUbicacionServidor.Name = "wizardPageUbicacionServidor";
            this.wizardPageUbicacionServidor.Size = new System.Drawing.Size(664, 231);
            this.wizardPageUbicacionServidor.Text = "Ubicación del servidor";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(123, 92);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 13);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Servicio web";
            // 
            // textEditServicioWeb
            // 
            this.textEditServicioWeb.EditValue = "http://localhost:1132/InterfazRemota.asmx";
            this.dxErrorProvider.SetIconAlignment(this.textEditServicioWeb, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.textEditServicioWeb.Location = new System.Drawing.Point(189, 85);
            this.textEditServicioWeb.MenuManager = this.ribbon;
            this.textEditServicioWeb.Name = "textEditServicioWeb";
            this.textEditServicioWeb.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.textEditServicioWeb.Properties.Appearance.Options.UseFont = true;
            this.textEditServicioWeb.Properties.ReadOnly = true;
            this.textEditServicioWeb.Size = new System.Drawing.Size(395, 26);
            this.textEditServicioWeb.TabIndex = 4;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(79, 57);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(104, 13);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Servidor de ActiveMQ";
            // 
            // textEditActiveMq
            // 
            this.textEditActiveMq.EditValue = "tcp://localhost:61616";
            this.dxErrorProvider.SetIconAlignment(this.textEditActiveMq, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.textEditActiveMq.Location = new System.Drawing.Point(189, 50);
            this.textEditActiveMq.MenuManager = this.ribbon;
            this.textEditActiveMq.Name = "textEditActiveMq";
            this.textEditActiveMq.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.textEditActiveMq.Properties.Appearance.Options.UseFont = true;
            this.textEditActiveMq.Properties.ReadOnly = true;
            this.textEditActiveMq.Size = new System.Drawing.Size(395, 26);
            this.textEditActiveMq.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(3, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(521, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Rellene el siguiente formulario con los datos del servidor en el que se ubica el " +
                "Servicio de Gestión de Compra.";
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
            this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl9.Location = new System.Drawing.Point(3, 3);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(658, 52);
            this.labelControl9.TabIndex = 2;
            this.labelControl9.Text = resources.GetString("labelControl9.Text");
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl4.Location = new System.Drawing.Point(3, 215);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(226, 13);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "Pulsa finalizar para enviar los datos al servidor.";
            // 
            // wizardPageUsuarioServidor
            // 
            this.wizardPageUsuarioServidor.Controls.Add(this.textEditCorreoElectronico);
            this.wizardPageUsuarioServidor.Controls.Add(this.labelControl12);
            this.wizardPageUsuarioServidor.Controls.Add(this.checkEditYaRegistrado);
            this.wizardPageUsuarioServidor.Controls.Add(this.textEditUsuario);
            this.wizardPageUsuarioServidor.Controls.Add(this.textEditContrasena2);
            this.wizardPageUsuarioServidor.Controls.Add(this.labelControl11);
            this.wizardPageUsuarioServidor.Controls.Add(this.dropDownButtonTipoAplicacion);
            this.wizardPageUsuarioServidor.Controls.Add(this.labelControl7);
            this.wizardPageUsuarioServidor.Controls.Add(this.textEditContrasena);
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
            this.textEditCorreoElectronico.Location = new System.Drawing.Point(189, 119);
            this.textEditCorreoElectronico.MenuManager = this.ribbon;
            this.textEditCorreoElectronico.Name = "textEditCorreoElectronico";
            this.textEditCorreoElectronico.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.textEditCorreoElectronico.Properties.Appearance.Options.UseFont = true;
            this.textEditCorreoElectronico.Size = new System.Drawing.Size(395, 26);
            this.textEditCorreoElectronico.TabIndex = 19;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(95, 126);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(88, 13);
            this.labelControl12.TabIndex = 18;
            this.labelControl12.Text = "Correo electrónico";
            // 
            // checkEditYaRegistrado
            // 
            this.checkEditYaRegistrado.Location = new System.Drawing.Point(467, 151);
            this.checkEditYaRegistrado.MenuManager = this.ribbon;
            this.checkEditYaRegistrado.Name = "checkEditYaRegistrado";
            this.checkEditYaRegistrado.Properties.AutoWidth = true;
            this.checkEditYaRegistrado.Properties.Caption = "Ya estoy registrado";
            this.checkEditYaRegistrado.Size = new System.Drawing.Size(117, 19);
            this.checkEditYaRegistrado.TabIndex = 17;
            this.checkEditYaRegistrado.CheckedChanged += new System.EventHandler(this.checkEditYaRegistrado_CheckedChanged);
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
            this.textEditUsuario.TabIndex = 16;
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
            this.textEditContrasena2.TabIndex = 14;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(110, 170);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(73, 13);
            this.labelControl11.TabIndex = 13;
            this.labelControl11.Text = "Tipo de usuario";
            // 
            // dropDownButtonTipoAplicacion
            // 
            this.dropDownButtonTipoAplicacion.DropDownControl = this.applicationMenuTiposAplicacion;
            this.dropDownButtonTipoAplicacion.Location = new System.Drawing.Point(189, 153);
            this.dropDownButtonTipoAplicacion.MenuManager = this.ribbon;
            this.dropDownButtonTipoAplicacion.Name = "dropDownButtonTipoAplicacion";
            this.dropDownButtonTipoAplicacion.Size = new System.Drawing.Size(127, 46);
            this.dropDownButtonTipoAplicacion.TabIndex = 12;
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
            this.textEditContrasena.TabIndex = 10;
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
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.checkEdit1);
            this.wizardPage1.Controls.Add(this.textEditEmpleadoUsuario);
            this.wizardPage1.Controls.Add(this.textEditEmpleadoContrasena2);
            this.wizardPage1.Controls.Add(this.labelControl13);
            this.wizardPage1.Controls.Add(this.textEditEmpleadoContrasena);
            this.wizardPage1.Controls.Add(this.labelControl14);
            this.wizardPage1.Controls.Add(this.labelControl16);
            this.wizardPage1.DescriptionText = "Datos para el primer empleado de la aplicación que tendrá privilegios de administ" +
                "rador";
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(664, 231);
            this.wizardPage1.Text = "Introduciendo el primer empleado";
            // 
            // checkEdit1
            // 
            this.checkEdit1.EditValue = true;
            this.checkEdit1.Location = new System.Drawing.Point(187, 120);
            this.checkEdit1.MenuManager = this.ribbon;
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.AutoWidth = true;
            this.checkEdit1.Properties.Caption = "Administrador";
            this.checkEdit1.Properties.ReadOnly = true;
            this.checkEdit1.Size = new System.Drawing.Size(89, 19);
            this.checkEdit1.TabIndex = 24;
            // 
            // textEditEmpleadoUsuario
            // 
            this.textEditEmpleadoUsuario.EditValue = "";
            this.dxErrorProvider.SetIconAlignment(this.textEditEmpleadoUsuario, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.textEditEmpleadoUsuario.Location = new System.Drawing.Point(189, 50);
            this.textEditEmpleadoUsuario.MenuManager = this.ribbon;
            this.textEditEmpleadoUsuario.Name = "textEditEmpleadoUsuario";
            this.textEditEmpleadoUsuario.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.textEditEmpleadoUsuario.Properties.Appearance.Options.UseFont = true;
            this.textEditEmpleadoUsuario.Size = new System.Drawing.Size(395, 26);
            this.textEditEmpleadoUsuario.TabIndex = 23;
            // 
            // textEditEmpleadoContrasena2
            // 
            this.textEditEmpleadoContrasena2.EditValue = "";
            this.dxErrorProvider.SetIconAlignment(this.textEditEmpleadoContrasena2, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.textEditEmpleadoContrasena2.Location = new System.Drawing.Point(390, 85);
            this.textEditEmpleadoContrasena2.MenuManager = this.ribbon;
            this.textEditEmpleadoContrasena2.Name = "textEditEmpleadoContrasena2";
            this.textEditEmpleadoContrasena2.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.textEditEmpleadoContrasena2.Properties.Appearance.Options.UseFont = true;
            this.textEditEmpleadoContrasena2.Properties.PasswordChar = '●';
            this.textEditEmpleadoContrasena2.Size = new System.Drawing.Size(194, 26);
            this.textEditEmpleadoContrasena2.TabIndex = 22;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(127, 92);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(56, 13);
            this.labelControl13.TabIndex = 21;
            this.labelControl13.Text = "Contraseña";
            // 
            // textEditEmpleadoContrasena
            // 
            this.textEditEmpleadoContrasena.EditValue = "";
            this.dxErrorProvider.SetIconAlignment(this.textEditEmpleadoContrasena, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.textEditEmpleadoContrasena.Location = new System.Drawing.Point(189, 85);
            this.textEditEmpleadoContrasena.MenuManager = this.ribbon;
            this.textEditEmpleadoContrasena.Name = "textEditEmpleadoContrasena";
            this.textEditEmpleadoContrasena.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.textEditEmpleadoContrasena.Properties.Appearance.Options.UseFont = true;
            this.textEditEmpleadoContrasena.Properties.PasswordChar = '●';
            this.textEditEmpleadoContrasena.Size = new System.Drawing.Size(195, 26);
            this.textEditEmpleadoContrasena.TabIndex = 20;
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
            ((System.ComponentModel.ISupportInitialize)(this.textEditServicioWeb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditActiveMq.Properties)).EndInit();
            this.wizardPageFinalizar.ResumeLayout(false);
            this.wizardPageFinalizar.PerformLayout();
            this.wizardPageUsuarioServidor.ResumeLayout(false);
            this.wizardPageUsuarioServidor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCorreoElectronico.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditYaRegistrado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditContrasena2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenuTiposAplicacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditContrasena.Properties)).EndInit();
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditEmpleadoUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditEmpleadoContrasena2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditEmpleadoContrasena.Properties)).EndInit();
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
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit textEditServicioWeb;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit textEditActiveMq;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit textEditContrasena;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.DropDownButton dropDownButtonTipoAplicacion;
        private DevExpress.XtraEditors.CheckEdit checkEditYaRegistrado;
        private DevExpress.XtraEditors.TextEdit textEditUsuario;
        private DevExpress.XtraEditors.TextEdit textEditContrasena2;
        private DevExpress.XtraEditors.TextEdit textEditCorreoElectronico;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenuTiposAplicacion;
        private DevExpress.XtraBars.BarButtonItem barButtonItemTaller;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDesguace;
        private DevExpress.XtraEditors.TextEdit textEditEmpleadoUsuario;
        private DevExpress.XtraEditors.TextEdit textEditEmpleadoContrasena2;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.TextEdit textEditEmpleadoContrasena;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}