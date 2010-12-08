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
            this.barButtonItemPendientes = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemFinalizadas = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSolicitar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemVerEmpleados = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAnadirEmpleado = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAnadirAdministrador = new DevExpress.XtraBars.BarButtonItem();
            this.barListItemIdioma = new DevExpress.XtraBars.BarListItem();
            this.barButtonItemOpciones = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDatos = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemEditarPerfil = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageSolicitudes = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupVerSolicitudes = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupNuevaSolicitud = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageEmpleados = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupVerEmpleados = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupAnadirEmpleados = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageConfiguracion = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupUsuario = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupAplicacion = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupServidor = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPageAyuda = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupAyudaEnLinea = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemConectar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDesconectar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupRegistro = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemVer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLimpiar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemEnviar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMostrarChat = new DevExpress.XtraBars.BarButtonItem();
            this.alertControl = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContenido.Location = new System.Drawing.Point(0, 144);
            this.panelContenido.Margin = new System.Windows.Forms.Padding(0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(715, 205);
            this.panelContenido.TabIndex = 0;
            // 
            // ribbonControl
            // 
            this.ribbonControl.ApplicationButtonText = null;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemPendientes,
            this.barButtonItemFinalizadas,
            this.barButtonItemSolicitar,
            this.barButtonItemVerEmpleados,
            this.barButtonItemAnadirEmpleado,
            this.barButtonItemAnadirAdministrador,
            this.barListItemIdioma,
            this.barButtonItemOpciones,
            this.barButtonItemDatos,
            this.barButtonItemEditarPerfil,
            this.barButtonItemConectar,
            this.barButtonItemDesconectar,
            this.barButtonItemVer,
            this.barButtonItemLimpiar,
            this.barButtonItemEnviar,
            this.barButtonItemMostrarChat});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 22;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageSolicitudes,
            this.ribbonPageEmpleados,
            this.ribbonPageConfiguracion,
            this.ribbonPageAyuda});
            this.ribbonControl.SelectedPage = this.ribbonPageSolicitudes;
            this.ribbonControl.Size = new System.Drawing.Size(715, 141);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            // 
            // barButtonItemPendientes
            // 
            this.barButtonItemPendientes.Caption = "Pendientes";
            this.barButtonItemPendientes.Id = 0;
            this.barButtonItemPendientes.Name = "barButtonItemPendientes";
            this.barButtonItemPendientes.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemPendientes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemPendientes_ItemClick);
            // 
            // barButtonItemFinalizadas
            // 
            this.barButtonItemFinalizadas.Caption = "Finalizadas";
            this.barButtonItemFinalizadas.Id = 1;
            this.barButtonItemFinalizadas.Name = "barButtonItemFinalizadas";
            this.barButtonItemFinalizadas.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemFinalizadas.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemFinalizadas_ItemClick);
            // 
            // barButtonItemSolicitar
            // 
            this.barButtonItemSolicitar.Caption = "Solicitar pieza";
            this.barButtonItemSolicitar.Id = 2;
            this.barButtonItemSolicitar.Name = "barButtonItemSolicitar";
            this.barButtonItemSolicitar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemSolicitar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSolicitar_ItemClick);
            // 
            // barButtonItemVerEmpleados
            // 
            this.barButtonItemVerEmpleados.Caption = "Ver empleados";
            this.barButtonItemVerEmpleados.Id = 3;
            this.barButtonItemVerEmpleados.Name = "barButtonItemVerEmpleados";
            this.barButtonItemVerEmpleados.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemAnadirEmpleado
            // 
            this.barButtonItemAnadirEmpleado.Caption = "Añadir empleado";
            this.barButtonItemAnadirEmpleado.Id = 4;
            this.barButtonItemAnadirEmpleado.Name = "barButtonItemAnadirEmpleado";
            this.barButtonItemAnadirEmpleado.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemAnadirAdministrador
            // 
            this.barButtonItemAnadirAdministrador.Caption = "Añadir administrador";
            this.barButtonItemAnadirAdministrador.Id = 5;
            this.barButtonItemAnadirAdministrador.Name = "barButtonItemAnadirAdministrador";
            this.barButtonItemAnadirAdministrador.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barListItemIdioma
            // 
            this.barListItemIdioma.Caption = "Idioma";
            this.barListItemIdioma.Id = 6;
            this.barListItemIdioma.Name = "barListItemIdioma";
            this.barListItemIdioma.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemOpciones
            // 
            this.barButtonItemOpciones.Caption = "Opciones";
            this.barButtonItemOpciones.Id = 7;
            this.barButtonItemOpciones.Name = "barButtonItemOpciones";
            this.barButtonItemOpciones.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemDatos
            // 
            this.barButtonItemDatos.Caption = "Datos de conexión";
            this.barButtonItemDatos.Id = 9;
            this.barButtonItemDatos.Name = "barButtonItemDatos";
            this.barButtonItemDatos.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemEditarPerfil
            // 
            this.barButtonItemEditarPerfil.Caption = "Editar perfil";
            this.barButtonItemEditarPerfil.Id = 11;
            this.barButtonItemEditarPerfil.Name = "barButtonItemEditarPerfil";
            this.barButtonItemEditarPerfil.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPageSolicitudes
            // 
            this.ribbonPageSolicitudes.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupVerSolicitudes,
            this.ribbonPageGroupNuevaSolicitud});
            this.ribbonPageSolicitudes.Name = "ribbonPageSolicitudes";
            this.ribbonPageSolicitudes.Text = "Solicitudes";
            // 
            // ribbonPageGroupVerSolicitudes
            // 
            this.ribbonPageGroupVerSolicitudes.AllowTextClipping = false;
            this.ribbonPageGroupVerSolicitudes.ItemLinks.Add(this.barButtonItemPendientes);
            this.ribbonPageGroupVerSolicitudes.ItemLinks.Add(this.barButtonItemFinalizadas);
            this.ribbonPageGroupVerSolicitudes.Name = "ribbonPageGroupVerSolicitudes";
            this.ribbonPageGroupVerSolicitudes.ShowCaptionButton = false;
            this.ribbonPageGroupVerSolicitudes.Text = "Ver";
            // 
            // ribbonPageGroupNuevaSolicitud
            // 
            this.ribbonPageGroupNuevaSolicitud.AllowTextClipping = false;
            this.ribbonPageGroupNuevaSolicitud.ItemLinks.Add(this.barButtonItemSolicitar);
            this.ribbonPageGroupNuevaSolicitud.Name = "ribbonPageGroupNuevaSolicitud";
            this.ribbonPageGroupNuevaSolicitud.ShowCaptionButton = false;
            this.ribbonPageGroupNuevaSolicitud.Text = "Nueva";
            // 
            // ribbonPageEmpleados
            // 
            this.ribbonPageEmpleados.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupVerEmpleados,
            this.ribbonPageGroupAnadirEmpleados});
            this.ribbonPageEmpleados.Name = "ribbonPageEmpleados";
            this.ribbonPageEmpleados.Text = "Empleados";
            // 
            // ribbonPageGroupVerEmpleados
            // 
            this.ribbonPageGroupVerEmpleados.AllowTextClipping = false;
            this.ribbonPageGroupVerEmpleados.ItemLinks.Add(this.barButtonItemVerEmpleados);
            this.ribbonPageGroupVerEmpleados.Name = "ribbonPageGroupVerEmpleados";
            this.ribbonPageGroupVerEmpleados.ShowCaptionButton = false;
            this.ribbonPageGroupVerEmpleados.Text = "Ver";
            // 
            // ribbonPageGroupAnadirEmpleados
            // 
            this.ribbonPageGroupAnadirEmpleados.AllowTextClipping = false;
            this.ribbonPageGroupAnadirEmpleados.ItemLinks.Add(this.barButtonItemAnadirEmpleado);
            this.ribbonPageGroupAnadirEmpleados.ItemLinks.Add(this.barButtonItemAnadirAdministrador);
            this.ribbonPageGroupAnadirEmpleados.Name = "ribbonPageGroupAnadirEmpleados";
            this.ribbonPageGroupAnadirEmpleados.ShowCaptionButton = false;
            this.ribbonPageGroupAnadirEmpleados.Text = "Añadir";
            // 
            // ribbonPageConfiguracion
            // 
            this.ribbonPageConfiguracion.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupUsuario,
            this.ribbonPageGroupAplicacion,
            this.ribbonPageGroupServidor});
            this.ribbonPageConfiguracion.Name = "ribbonPageConfiguracion";
            this.ribbonPageConfiguracion.Text = "Configuración";
            // 
            // ribbonPageGroupUsuario
            // 
            this.ribbonPageGroupUsuario.AllowTextClipping = false;
            this.ribbonPageGroupUsuario.ItemLinks.Add(this.barButtonItemEditarPerfil);
            this.ribbonPageGroupUsuario.Name = "ribbonPageGroupUsuario";
            this.ribbonPageGroupUsuario.ShowCaptionButton = false;
            this.ribbonPageGroupUsuario.Text = "Usuario";
            // 
            // ribbonPageGroupAplicacion
            // 
            this.ribbonPageGroupAplicacion.AllowTextClipping = false;
            this.ribbonPageGroupAplicacion.ItemLinks.Add(this.barListItemIdioma);
            this.ribbonPageGroupAplicacion.ItemLinks.Add(this.barButtonItemOpciones);
            this.ribbonPageGroupAplicacion.Name = "ribbonPageGroupAplicacion";
            this.ribbonPageGroupAplicacion.ShowCaptionButton = false;
            this.ribbonPageGroupAplicacion.Text = "Aplicación";
            // 
            // ribbonPageGroupServidor
            // 
            this.ribbonPageGroupServidor.AllowTextClipping = false;
            this.ribbonPageGroupServidor.ItemLinks.Add(this.barButtonItemDatos);
            this.ribbonPageGroupServidor.Name = "ribbonPageGroupServidor";
            this.ribbonPageGroupServidor.ShowCaptionButton = false;
            this.ribbonPageGroupServidor.Text = "Servidor";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 352);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(715, 24);
            // 
            // ribbonPageAyuda
            // 
            this.ribbonPageAyuda.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupAyudaEnLinea,
            this.ribbonPageGroupRegistro});
            this.ribbonPageAyuda.Name = "ribbonPageAyuda";
            this.ribbonPageAyuda.Text = "Ayuda";
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
            // barButtonItemConectar
            // 
            this.barButtonItemConectar.Caption = "Conectar";
            this.barButtonItemConectar.Id = 12;
            this.barButtonItemConectar.Name = "barButtonItemConectar";
            this.barButtonItemConectar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemDesconectar
            // 
            this.barButtonItemDesconectar.Caption = "Desconectar";
            this.barButtonItemDesconectar.Id = 13;
            this.barButtonItemDesconectar.Name = "barButtonItemDesconectar";
            this.barButtonItemDesconectar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
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
            // barButtonItemVer
            // 
            this.barButtonItemVer.Caption = "Ver registro";
            this.barButtonItemVer.Id = 14;
            this.barButtonItemVer.Name = "barButtonItemVer";
            this.barButtonItemVer.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemLimpiar
            // 
            this.barButtonItemLimpiar.Caption = "Limpiar registro";
            this.barButtonItemLimpiar.Id = 15;
            this.barButtonItemLimpiar.Name = "barButtonItemLimpiar";
            this.barButtonItemLimpiar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemEnviar
            // 
            this.barButtonItemEnviar.Caption = "Enviar al servidor";
            this.barButtonItemEnviar.Id = 16;
            this.barButtonItemEnviar.Name = "barButtonItemEnviar";
            this.barButtonItemEnviar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemMostrarChat
            // 
            this.barButtonItemMostrarChat.Caption = "Mostrar ventana de chat";
            this.barButtonItemMostrarChat.Id = 21;
            this.barButtonItemMostrarChat.Name = "barButtonItemMostrarChat";
            this.barButtonItemMostrarChat.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 376);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.Controls.Add(this.panelContenido);
            this.Name = "FormBase";
            this.Text = "Aplicación de taller";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenido;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageSolicitudes;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupNuevaSolicitud;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageEmpleados;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupVerEmpleados;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAnadirEmpleados;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageConfiguracion;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupUsuario;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupServidor;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupVerSolicitudes;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAplicacion;
        private DevExpress.XtraBars.BarButtonItem barButtonItemPendientes;
        private DevExpress.XtraBars.BarButtonItem barButtonItemFinalizadas;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSolicitar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemVerEmpleados;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAnadirEmpleado;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAnadirAdministrador;
        private DevExpress.XtraBars.BarListItem barListItemIdioma;
        private DevExpress.XtraBars.BarButtonItem barButtonItemOpciones;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDatos;
        private DevExpress.XtraBars.BarButtonItem barButtonItemEditarPerfil;
        private DevExpress.XtraBars.BarButtonItem barButtonItemConectar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDesconectar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemVer;
        private DevExpress.XtraBars.BarButtonItem barButtonItemLimpiar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemEnviar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageAyuda;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAyudaEnLinea;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupRegistro;
        private DevExpress.XtraBars.BarButtonItem barButtonItemMostrarChat;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl;
    }
}