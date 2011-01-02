namespace Aplicación_de_Taller
{
    partial class FormBase
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
            this.panelContenido = new System.Windows.Forms.Panel();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemVerSolicitudes = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSolicitar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemVerEmpleados = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAnadirEmpleado = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAnadirAdministrador = new DevExpress.XtraBars.BarButtonItem();
            this.barListItemIdioma = new DevExpress.XtraBars.BarListItem();
            this.barButtonItemOpciones = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDatos = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMiPerfil = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemConectar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDesconectar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemVer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLimpiar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemEnviar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMostrarChat = new DevExpress.XtraBars.BarButtonItem();
            this.barLinkContainerItemEmpleados = new DevExpress.XtraBars.BarLinkContainerItem();
            this.ribbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupSolicitudes = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupPreferencias = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupAyudaEnLinea = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupRegistro = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupAdministracion = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.alertControl = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.ribbonPageSolicitudesDesguace = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemVerSolicitudesDesguace = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContenido.Location = new System.Drawing.Point(0, 124);
            this.panelContenido.Margin = new System.Windows.Forms.Padding(0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(1090, 339);
            this.panelContenido.TabIndex = 0;
            // 
            // ribbonControl
            // 
            this.ribbonControl.ApplicationButtonText = null;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemVerSolicitudes,
            this.barButtonItemSolicitar,
            this.barButtonItemVerEmpleados,
            this.barButtonItemAnadirEmpleado,
            this.barButtonItemAnadirAdministrador,
            this.barListItemIdioma,
            this.barButtonItemOpciones,
            this.barButtonItemDatos,
            this.barButtonItemMiPerfil,
            this.barButtonItemConectar,
            this.barButtonItemDesconectar,
            this.barButtonItemVer,
            this.barButtonItemLimpiar,
            this.barButtonItemEnviar,
            this.barButtonItemMostrarChat,
            this.barLinkContainerItemEmpleados});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 35;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage});
            this.ribbonControl.SelectedPage = this.ribbonPage;
            this.ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl.Size = new System.Drawing.Size(1090, 121);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            // 
            // barButtonItemVerSolicitudes
            // 
            this.barButtonItemVerSolicitudes.Caption = "Ver solicitudes";
            this.barButtonItemVerSolicitudes.Glyph = global::Aplicación_de_Taller.Properties.Resources.document_32;
            this.barButtonItemVerSolicitudes.Id = 0;
            this.barButtonItemVerSolicitudes.Name = "barButtonItemVerSolicitudes";
            this.barButtonItemVerSolicitudes.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemVerSolicitudes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemVerSolicitudes_ItemClick);
            // 
            // barButtonItemSolicitar
            // 
            this.barButtonItemSolicitar.Caption = "Solicitar pieza";
            this.barButtonItemSolicitar.Glyph = global::Aplicación_de_Taller.Properties.Resources.document_add_32;
            this.barButtonItemSolicitar.Id = 2;
            this.barButtonItemSolicitar.Name = "barButtonItemSolicitar";
            this.barButtonItemSolicitar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemSolicitar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSolicitar_ItemClick);
            // 
            // barButtonItemVerEmpleados
            // 
            this.barButtonItemVerEmpleados.Caption = "Ver empleados";
            this.barButtonItemVerEmpleados.Glyph = global::Aplicación_de_Taller.Properties.Resources.verempleados;
            this.barButtonItemVerEmpleados.Id = 3;
            this.barButtonItemVerEmpleados.Name = "barButtonItemVerEmpleados";
            this.barButtonItemVerEmpleados.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemVerEmpleados.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemVerEmpleados_ItemClick);
            // 
            // barButtonItemAnadirEmpleado
            // 
            this.barButtonItemAnadirEmpleado.Caption = "Añadir empleado";
            this.barButtonItemAnadirEmpleado.Glyph = global::Aplicación_de_Taller.Properties.Resources.anadiruser;
            this.barButtonItemAnadirEmpleado.Id = 4;
            this.barButtonItemAnadirEmpleado.Name = "barButtonItemAnadirEmpleado";
            this.barButtonItemAnadirEmpleado.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemAnadirEmpleado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAnadirEmpleado_ItemClick);
            // 
            // barButtonItemAnadirAdministrador
            // 
            this.barButtonItemAnadirAdministrador.Caption = "Añadir administrador";
            this.barButtonItemAnadirAdministrador.Glyph = global::Aplicación_de_Taller.Properties.Resources.anadiradmin;
            this.barButtonItemAnadirAdministrador.Id = 5;
            this.barButtonItemAnadirAdministrador.Name = "barButtonItemAnadirAdministrador";
            this.barButtonItemAnadirAdministrador.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemAnadirAdministrador.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAnadirAdministrador_ItemClick);
            // 
            // barListItemIdioma
            // 
            this.barListItemIdioma.Caption = "Idioma";
            this.barListItemIdioma.Glyph = global::Aplicación_de_Taller.Properties.Resources.spanish;
            this.barListItemIdioma.Id = 6;
            this.barListItemIdioma.Name = "barListItemIdioma";
            this.barListItemIdioma.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemOpciones
            // 
            this.barButtonItemOpciones.Caption = "Opciones";
            this.barButtonItemOpciones.Glyph = global::Aplicación_de_Taller.Properties.Resources.options;
            this.barButtonItemOpciones.Id = 7;
            this.barButtonItemOpciones.Name = "barButtonItemOpciones";
            this.barButtonItemOpciones.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemDatos
            // 
            this.barButtonItemDatos.Caption = "Datos de conexión";
            this.barButtonItemDatos.Glyph = global::Aplicación_de_Taller.Properties.Resources.settings;
            this.barButtonItemDatos.Id = 9;
            this.barButtonItemDatos.Name = "barButtonItemDatos";
            this.barButtonItemDatos.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemMiPerfil
            // 
            this.barButtonItemMiPerfil.Caption = "Mi perfil";
            this.barButtonItemMiPerfil.Glyph = global::Aplicación_de_Taller.Properties.Resources.editaruser;
            this.barButtonItemMiPerfil.Id = 11;
            this.barButtonItemMiPerfil.Name = "barButtonItemMiPerfil";
            this.barButtonItemMiPerfil.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemConectar
            // 
            this.barButtonItemConectar.Caption = "Conectar";
            this.barButtonItemConectar.Glyph = global::Aplicación_de_Taller.Properties.Resources.green_button;
            this.barButtonItemConectar.Id = 12;
            this.barButtonItemConectar.Name = "barButtonItemConectar";
            this.barButtonItemConectar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemDesconectar
            // 
            this.barButtonItemDesconectar.Caption = "Desconectar";
            this.barButtonItemDesconectar.Glyph = global::Aplicación_de_Taller.Properties.Resources.red_button;
            this.barButtonItemDesconectar.Id = 13;
            this.barButtonItemDesconectar.Name = "barButtonItemDesconectar";
            this.barButtonItemDesconectar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemVer
            // 
            this.barButtonItemVer.Caption = "Ver registro";
            this.barButtonItemVer.Glyph = global::Aplicación_de_Taller.Properties.Resources.clipboard;
            this.barButtonItemVer.Id = 14;
            this.barButtonItemVer.Name = "barButtonItemVer";
            this.barButtonItemVer.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemLimpiar
            // 
            this.barButtonItemLimpiar.Caption = "Limpiar registro";
            this.barButtonItemLimpiar.Glyph = global::Aplicación_de_Taller.Properties.Resources.limpiar;
            this.barButtonItemLimpiar.Id = 15;
            this.barButtonItemLimpiar.Name = "barButtonItemLimpiar";
            this.barButtonItemLimpiar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemEnviar
            // 
            this.barButtonItemEnviar.Caption = "Enviar al servidor";
            this.barButtonItemEnviar.Glyph = global::Aplicación_de_Taller.Properties.Resources.send;
            this.barButtonItemEnviar.Id = 16;
            this.barButtonItemEnviar.Name = "barButtonItemEnviar";
            this.barButtonItemEnviar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemMostrarChat
            // 
            this.barButtonItemMostrarChat.Caption = "Mostrar ventana de chat";
            this.barButtonItemMostrarChat.Glyph = global::Aplicación_de_Taller.Properties.Resources.mostrarchat;
            this.barButtonItemMostrarChat.Id = 21;
            this.barButtonItemMostrarChat.Name = "barButtonItemMostrarChat";
            this.barButtonItemMostrarChat.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barLinkContainerItemEmpleados
            // 
            this.barLinkContainerItemEmpleados.Caption = "Empleados";
            this.barLinkContainerItemEmpleados.Glyph = global::Aplicación_de_Taller.Properties.Resources.users;
            this.barLinkContainerItemEmpleados.Id = 30;
            this.barLinkContainerItemEmpleados.Name = "barLinkContainerItemEmpleados";
            this.barLinkContainerItemEmpleados.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPage
            // 
            this.ribbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupSolicitudes,
            this.ribbonPageGroupPreferencias,
            this.ribbonPageGroupAyudaEnLinea,
            this.ribbonPageGroupRegistro,
            this.ribbonPageGroupAdministracion});
            this.ribbonPage.Name = "ribbonPage";
            this.ribbonPage.Text = "Menú";
            // 
            // ribbonPageGroupSolicitudes
            // 
            this.ribbonPageGroupSolicitudes.AllowTextClipping = false;
            this.ribbonPageGroupSolicitudes.ItemLinks.Add(this.barButtonItemVerSolicitudes);
            this.ribbonPageGroupSolicitudes.ItemLinks.Add(this.barButtonItemSolicitar);
            this.ribbonPageGroupSolicitudes.Name = "ribbonPageGroupSolicitudes";
            this.ribbonPageGroupSolicitudes.ShowCaptionButton = false;
            this.ribbonPageGroupSolicitudes.Text = "Solicitudes";
            // 
            // ribbonPageGroupPreferencias
            // 
            this.ribbonPageGroupPreferencias.AllowTextClipping = false;
            this.ribbonPageGroupPreferencias.ItemLinks.Add(this.barButtonItemMiPerfil);
            this.ribbonPageGroupPreferencias.ItemLinks.Add(this.barListItemIdioma);
            this.ribbonPageGroupPreferencias.ItemLinks.Add(this.barButtonItemOpciones);
            this.ribbonPageGroupPreferencias.Name = "ribbonPageGroupPreferencias";
            this.ribbonPageGroupPreferencias.ShowCaptionButton = false;
            this.ribbonPageGroupPreferencias.Text = "Preferencias";
            // 
            // ribbonPageGroupAyudaEnLinea
            // 
            this.ribbonPageGroupAyudaEnLinea.AllowTextClipping = false;
            this.ribbonPageGroupAyudaEnLinea.ItemLinks.Add(this.barButtonItemConectar);
            this.ribbonPageGroupAyudaEnLinea.ItemLinks.Add(this.barButtonItemMostrarChat);
            this.ribbonPageGroupAyudaEnLinea.ItemLinks.Add(this.barButtonItemDesconectar);
            this.ribbonPageGroupAyudaEnLinea.Name = "ribbonPageGroupAyudaEnLinea";
            this.ribbonPageGroupAyudaEnLinea.ShowCaptionButton = false;
            this.ribbonPageGroupAyudaEnLinea.Text = "Ayuda en línea";
            // 
            // ribbonPageGroupRegistro
            // 
            this.ribbonPageGroupRegistro.AllowTextClipping = false;
            this.ribbonPageGroupRegistro.ItemLinks.Add(this.barButtonItemVer);
            this.ribbonPageGroupRegistro.ItemLinks.Add(this.barButtonItemLimpiar);
            this.ribbonPageGroupRegistro.ItemLinks.Add(this.barButtonItemEnviar);
            this.ribbonPageGroupRegistro.Name = "ribbonPageGroupRegistro";
            this.ribbonPageGroupRegistro.ShowCaptionButton = false;
            this.ribbonPageGroupRegistro.Text = "Registro de aplicación";
            // 
            // ribbonPageGroupAdministracion
            // 
            this.ribbonPageGroupAdministracion.AllowTextClipping = false;
            this.ribbonPageGroupAdministracion.ItemLinks.Add(this.barButtonItemDatos);
            this.ribbonPageGroupAdministracion.ItemLinks.Add(this.barLinkContainerItemEmpleados);
            this.ribbonPageGroupAdministracion.ItemLinks.Add(this.barButtonItemVerEmpleados);
            this.ribbonPageGroupAdministracion.ItemLinks.Add(this.barButtonItemAnadirEmpleado);
            this.ribbonPageGroupAdministracion.ItemLinks.Add(this.barButtonItemAnadirAdministrador);
            this.ribbonPageGroupAdministracion.Name = "ribbonPageGroupAdministracion";
            this.ribbonPageGroupAdministracion.ShowCaptionButton = false;
            this.ribbonPageGroupAdministracion.Text = "Administración";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 466);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1090, 24);
            // 
            // ribbonPageSolicitudesDesguace
            // 
            this.ribbonPageSolicitudesDesguace.AllowTextClipping = false;
            this.ribbonPageSolicitudesDesguace.Name = "ribbonPageSolicitudesDesguace";
            this.ribbonPageSolicitudesDesguace.ShowCaptionButton = false;
            this.ribbonPageSolicitudesDesguace.Text = "Solicitudes";
            // 
            // barButtonItemVerSolicitudesDesguace
            // 
            this.barButtonItemVerSolicitudesDesguace.Caption = "Ver solicitudes";
            this.barButtonItemVerSolicitudesDesguace.Glyph = global::Aplicación_de_Taller.Properties.Resources.document_32;
            this.barButtonItemVerSolicitudesDesguace.Id = 22;
            this.barButtonItemVerSolicitudesDesguace.Name = "barButtonItemVerSolicitudesDesguace";
            this.barButtonItemVerSolicitudesDesguace.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 490);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.Controls.Add(this.panelContenido);
            this.Name = "FormBase";
            this.Text = "Aplicación de taller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBase_FormClosing);
            this.Load += new System.EventHandler(this.FormBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenido;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAdministracion;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupPreferencias;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSolicitudes;
        private DevExpress.XtraBars.BarButtonItem barButtonItemVerSolicitudes;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSolicitar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemVerEmpleados;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAnadirEmpleado;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAnadirAdministrador;
        private DevExpress.XtraBars.BarListItem barListItemIdioma;
        private DevExpress.XtraBars.BarButtonItem barButtonItemOpciones;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDatos;
        private DevExpress.XtraBars.BarButtonItem barButtonItemMiPerfil;
        private DevExpress.XtraBars.BarButtonItem barButtonItemConectar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDesconectar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemVer;
        private DevExpress.XtraBars.BarButtonItem barButtonItemLimpiar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemEnviar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAyudaEnLinea;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupRegistro;
        private DevExpress.XtraBars.BarButtonItem barButtonItemMostrarChat;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageSolicitudesDesguace;
        private DevExpress.XtraBars.BarButtonItem barButtonItemVerSolicitudesDesguace;
        private DevExpress.XtraBars.BarLinkContainerItem barLinkContainerItemEmpleados;
    }
}