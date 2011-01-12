namespace Aplicación_de_Escritorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBase));
            DevExpress.XtraBars.Alerter.AlertButton alertButton1 = new DevExpress.XtraBars.Alerter.AlertButton();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu();
            this.barButtonItemRealizarCopia = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCargarCopia = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMinimizarBandeja = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAcercaDe = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCerrarSesion = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSalir = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemVerSolicitudes = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSolicitar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemVerEmpleados = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAnadirEmpleado = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAnadirAdministrador = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemConfiguracion = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPerfil = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemConectar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDesconectar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemVer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLimpiar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemElegirFuente = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemChat = new DevExpress.XtraBars.BarButtonItem();
            this.barLinkContainerItemEmpleados = new DevExpress.XtraBars.BarLinkContainerItem();
            this.barButtonItemAnterior = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSiguiente = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemEmpleadoLabel = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemEmpleado = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItemCerrar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemConsultarAhora = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemElegirColor = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupSolicitudes = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupPreferencias = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupAyudaEnLinea = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupRegistro = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.alertControl = new DevExpress.XtraBars.Alerter.AlertControl();
            this.ribbonPageSolicitudesDesguace = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemVerSolicitudesDesguace = new DevExpress.XtraBars.BarButtonItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon();
            this.contextMenuStripNotifyIcon = new System.Windows.Forms.ContextMenuStrip();
            this.toolStripMenuItemAbrirAplicacion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.alertControlSolicitudes = new DevExpress.XtraBars.Alerter.AlertControl();
            this.timerSolicitudesFinalizadas = new System.Windows.Forms.Timer();
            this.timerConsumirSolicitudes = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            this.contextMenuStripNotifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContenido.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelContenido.Location = new System.Drawing.Point(0, 146);
            this.panelContenido.Margin = new System.Windows.Forms.Padding(0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Padding = new System.Windows.Forms.Padding(10);
            this.panelContenido.Size = new System.Drawing.Size(828, 550);
            this.panelContenido.TabIndex = 0;
            // 
            // ribbonControl
            // 
            this.ribbonControl.ApplicationButtonDropDownControl = this.applicationMenu;
            this.ribbonControl.ApplicationButtonText = null;
            this.ribbonControl.ApplicationIcon = global::Aplicación_de_Escritorio.Properties.Resources.desplegable;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemVerSolicitudes,
            this.barButtonItemSolicitar,
            this.barButtonItemVerEmpleados,
            this.barButtonItemAnadirEmpleado,
            this.barButtonItemAnadirAdministrador,
            this.barButtonItemConfiguracion,
            this.barButtonItemPerfil,
            this.barButtonItemConectar,
            this.barButtonItemDesconectar,
            this.barButtonItemVer,
            this.barButtonItemLimpiar,
            this.barButtonItemElegirFuente,
            this.barButtonItemChat,
            this.barLinkContainerItemEmpleados,
            this.barButtonItemAnterior,
            this.barButtonItemSiguiente,
            this.barButtonItemRealizarCopia,
            this.barButtonItemCargarCopia,
            this.barButtonItemMinimizarBandeja,
            this.barButtonItemSalir,
            this.barButtonItemAcercaDe,
            this.barStaticItemEmpleadoLabel,
            this.barStaticItemEmpleado,
            this.barButtonItemCerrar,
            this.barButtonItemCerrarSesion,
            this.barButtonItemConsultarAhora,
            this.barButtonItemElegirColor});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 52;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.PageHeaderItemLinks.Add(this.barButtonItemCerrar);
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage});
            this.ribbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
            this.ribbonControl.SelectedPage = this.ribbonPage;
            this.ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(828, 143);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.Toolbar.ItemLinks.Add(this.barButtonItemAnterior);
            this.ribbonControl.Toolbar.ItemLinks.Add(this.barButtonItemSiguiente);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // applicationMenu
            // 
            this.applicationMenu.BottomPaneControlContainer = null;
            this.applicationMenu.ItemLinks.Add(this.barButtonItemRealizarCopia);
            this.applicationMenu.ItemLinks.Add(this.barButtonItemCargarCopia);
            this.applicationMenu.ItemLinks.Add(this.barButtonItemMinimizarBandeja);
            this.applicationMenu.ItemLinks.Add(this.barButtonItemAcercaDe);
            this.applicationMenu.ItemLinks.Add(this.barButtonItemCerrarSesion);
            this.applicationMenu.ItemLinks.Add(this.barButtonItemSalir);
            this.applicationMenu.Name = "applicationMenu";
            this.applicationMenu.Ribbon = this.ribbonControl;
            this.applicationMenu.RightPaneControlContainer = null;
            // 
            // barButtonItemRealizarCopia
            // 
            this.barButtonItemRealizarCopia.Caption = "Realizar copia de seguridad";
            this.barButtonItemRealizarCopia.Description = "Ficheros de configuración y base de datos";
            this.barButtonItemRealizarCopia.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.guardar;
            this.barButtonItemRealizarCopia.Id = 38;
            this.barButtonItemRealizarCopia.Name = "barButtonItemRealizarCopia";
            // 
            // barButtonItemCargarCopia
            // 
            this.barButtonItemCargarCopia.Caption = "Cargar copia de seguridad";
            this.barButtonItemCargarCopia.Description = "Requiere reiniciar la aplicación";
            this.barButtonItemCargarCopia.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.folder_32;
            this.barButtonItemCargarCopia.Id = 39;
            this.barButtonItemCargarCopia.Name = "barButtonItemCargarCopia";
            this.barButtonItemCargarCopia.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemMinimizarBandeja
            // 
            this.barButtonItemMinimizarBandeja.Caption = "Minimizar en la bandeja del sistema";
            this.barButtonItemMinimizarBandeja.Description = "El servicio sigue en funcionamiento";
            this.barButtonItemMinimizarBandeja.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.minimizar;
            this.barButtonItemMinimizarBandeja.Id = 40;
            this.barButtonItemMinimizarBandeja.Name = "barButtonItemMinimizarBandeja";
            this.barButtonItemMinimizarBandeja.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemMinimizarBandeja.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemMinimizarBandeja_ItemClick);
            // 
            // barButtonItemAcercaDe
            // 
            this.barButtonItemAcercaDe.Caption = "Acerca de Criludage";
            this.barButtonItemAcercaDe.Description = "Información sobre la aplicación y los desarrolladores";
            this.barButtonItemAcercaDe.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.panda;
            this.barButtonItemAcercaDe.Id = 42;
            this.barButtonItemAcercaDe.Name = "barButtonItemAcercaDe";
            this.barButtonItemAcercaDe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAcercaDe_ItemClick);
            // 
            // barButtonItemCerrarSesion
            // 
            this.barButtonItemCerrarSesion.Caption = "Cerrar sesión";
            this.barButtonItemCerrarSesion.Description = "Vuelve a la ventana de inicio de sesión";
            this.barButtonItemCerrarSesion.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.sesion;
            this.barButtonItemCerrarSesion.Id = 47;
            this.barButtonItemCerrarSesion.Name = "barButtonItemCerrarSesion";
            this.barButtonItemCerrarSesion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCerrarSesion_ItemClick);
            // 
            // barButtonItemSalir
            // 
            this.barButtonItemSalir.Caption = "Salir";
            this.barButtonItemSalir.Description = "Finaliza la sesión y desconecta del servicio";
            this.barButtonItemSalir.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.salir;
            this.barButtonItemSalir.Id = 41;
            this.barButtonItemSalir.Name = "barButtonItemSalir";
            this.barButtonItemSalir.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemSalir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSalir_ItemClick);
            // 
            // barButtonItemVerSolicitudes
            // 
            this.barButtonItemVerSolicitudes.Caption = "Ver solicitudes";
            this.barButtonItemVerSolicitudes.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.document_32;
            this.barButtonItemVerSolicitudes.Id = 0;
            this.barButtonItemVerSolicitudes.Name = "barButtonItemVerSolicitudes";
            this.barButtonItemVerSolicitudes.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemVerSolicitudes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemVerSolicitudes_ItemClick);
            // 
            // barButtonItemSolicitar
            // 
            this.barButtonItemSolicitar.Caption = "Solicitar pieza";
            this.barButtonItemSolicitar.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.document_add_32;
            this.barButtonItemSolicitar.Id = 2;
            this.barButtonItemSolicitar.Name = "barButtonItemSolicitar";
            this.barButtonItemSolicitar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemSolicitar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSolicitar_ItemClick);
            // 
            // barButtonItemVerEmpleados
            // 
            this.barButtonItemVerEmpleados.Caption = "Ver empleados";
            this.barButtonItemVerEmpleados.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.verempleados;
            this.barButtonItemVerEmpleados.Id = 3;
            this.barButtonItemVerEmpleados.Name = "barButtonItemVerEmpleados";
            this.barButtonItemVerEmpleados.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemVerEmpleados.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemVerEmpleados_ItemClick);
            // 
            // barButtonItemAnadirEmpleado
            // 
            this.barButtonItemAnadirEmpleado.Caption = "Añadir empleado";
            this.barButtonItemAnadirEmpleado.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.anadiruser;
            this.barButtonItemAnadirEmpleado.Id = 4;
            this.barButtonItemAnadirEmpleado.Name = "barButtonItemAnadirEmpleado";
            this.barButtonItemAnadirEmpleado.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemAnadirEmpleado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAnadirEmpleado_ItemClick);
            // 
            // barButtonItemAnadirAdministrador
            // 
            this.barButtonItemAnadirAdministrador.Caption = "Añadir administrador";
            this.barButtonItemAnadirAdministrador.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.anadiradmin;
            this.barButtonItemAnadirAdministrador.Id = 5;
            this.barButtonItemAnadirAdministrador.Name = "barButtonItemAnadirAdministrador";
            this.barButtonItemAnadirAdministrador.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemAnadirAdministrador.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAnadirAdministrador_ItemClick);
            // 
            // barButtonItemConfiguracion
            // 
            this.barButtonItemConfiguracion.Caption = "Configuración";
            this.barButtonItemConfiguracion.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.options;
            this.barButtonItemConfiguracion.Id = 7;
            this.barButtonItemConfiguracion.Name = "barButtonItemConfiguracion";
            this.barButtonItemConfiguracion.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemConfiguracion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemConfiguracion_ItemClick);
            // 
            // barButtonItemPerfil
            // 
            this.barButtonItemPerfil.Caption = "Mi perfil";
            this.barButtonItemPerfil.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.editaruser;
            this.barButtonItemPerfil.Id = 11;
            this.barButtonItemPerfil.Name = "barButtonItemPerfil";
            this.barButtonItemPerfil.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemPerfil.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemPerfil_ItemClick);
            // 
            // barButtonItemConectar
            // 
            this.barButtonItemConectar.Caption = "Conectar";
            this.barButtonItemConectar.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.green_button;
            this.barButtonItemConectar.Id = 12;
            this.barButtonItemConectar.Name = "barButtonItemConectar";
            this.barButtonItemConectar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemDesconectar
            // 
            this.barButtonItemDesconectar.Caption = "Desconectar";
            this.barButtonItemDesconectar.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.red_button;
            this.barButtonItemDesconectar.Id = 13;
            this.barButtonItemDesconectar.Name = "barButtonItemDesconectar";
            this.barButtonItemDesconectar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemVer
            // 
            this.barButtonItemVer.Caption = "Ver registro";
            this.barButtonItemVer.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.clipboard;
            this.barButtonItemVer.Id = 14;
            this.barButtonItemVer.Name = "barButtonItemVer";
            this.barButtonItemVer.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemVer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemVer_ItemClick);
            // 
            // barButtonItemLimpiar
            // 
            this.barButtonItemLimpiar.Caption = "Limpiar registro";
            this.barButtonItemLimpiar.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.limpiar;
            this.barButtonItemLimpiar.Id = 15;
            this.barButtonItemLimpiar.Name = "barButtonItemLimpiar";
            this.barButtonItemLimpiar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemLimpiar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemLimpiar_ItemClick);
            // 
            // barButtonItemElegirFuente
            // 
            this.barButtonItemElegirFuente.Caption = "Fuente";
            this.barButtonItemElegirFuente.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.fuente;
            this.barButtonItemElegirFuente.Id = 16;
            this.barButtonItemElegirFuente.Name = "barButtonItemElegirFuente";
            this.barButtonItemElegirFuente.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemElegirFuente.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemElegirFuente_ItemClick);
            // 
            // barButtonItemChat
            // 
            this.barButtonItemChat.Caption = "Chat";
            this.barButtonItemChat.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.mostrarchat;
            this.barButtonItemChat.Id = 21;
            this.barButtonItemChat.Name = "barButtonItemChat";
            this.barButtonItemChat.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemChat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemChat_ItemClick);
            // 
            // barLinkContainerItemEmpleados
            // 
            this.barLinkContainerItemEmpleados.Caption = "Empleados";
            this.barLinkContainerItemEmpleados.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.users;
            this.barLinkContainerItemEmpleados.Id = 30;
            this.barLinkContainerItemEmpleados.Name = "barLinkContainerItemEmpleados";
            this.barLinkContainerItemEmpleados.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemAnterior
            // 
            this.barButtonItemAnterior.Caption = "Ir a la página anterior";
            this.barButtonItemAnterior.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.anterior;
            this.barButtonItemAnterior.Hint = "Ir a la página anterior";
            this.barButtonItemAnterior.Id = 35;
            this.barButtonItemAnterior.Name = "barButtonItemAnterior";
            this.barButtonItemAnterior.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAnterior_ItemClick);
            // 
            // barButtonItemSiguiente
            // 
            this.barButtonItemSiguiente.Caption = "Ir a la página siguiente";
            this.barButtonItemSiguiente.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.siguiente;
            this.barButtonItemSiguiente.Hint = "Ir a la página siguiente";
            this.barButtonItemSiguiente.Id = 36;
            this.barButtonItemSiguiente.Name = "barButtonItemSiguiente";
            this.barButtonItemSiguiente.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSiguiente_ItemClick);
            // 
            // barStaticItemEmpleadoLabel
            // 
            this.barStaticItemEmpleadoLabel.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItemEmpleadoLabel.Caption = "Empleado:";
            this.barStaticItemEmpleadoLabel.Id = 43;
            this.barStaticItemEmpleadoLabel.Name = "barStaticItemEmpleadoLabel";
            this.barStaticItemEmpleadoLabel.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItemEmpleado
            // 
            this.barStaticItemEmpleado.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItemEmpleado.Caption = "<empleado>";
            this.barStaticItemEmpleado.Id = 45;
            this.barStaticItemEmpleado.Name = "barStaticItemEmpleado";
            this.barStaticItemEmpleado.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItemCerrar
            // 
            this.barButtonItemCerrar.Caption = "Cerrar la página actual";
            this.barButtonItemCerrar.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.close;
            this.barButtonItemCerrar.Hint = "Cerrar la página actual";
            this.barButtonItemCerrar.Id = 46;
            this.barButtonItemCerrar.Name = "barButtonItemCerrar";
            this.barButtonItemCerrar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCerrar_ItemClick);
            // 
            // barButtonItemConsultarAhora
            // 
            this.barButtonItemConsultarAhora.Caption = "Refrescar ahora";
            this.barButtonItemConsultarAhora.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.refresh;
            this.barButtonItemConsultarAhora.Id = 50;
            this.barButtonItemConsultarAhora.Name = "barButtonItemConsultarAhora";
            this.barButtonItemConsultarAhora.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemConsultarAhora.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemConsultarAhora_ItemClick);
            // 
            // barButtonItemElegirColor
            // 
            this.barButtonItemElegirColor.Caption = "Color";
            this.barButtonItemElegirColor.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.color;
            this.barButtonItemElegirColor.Id = 51;
            this.barButtonItemElegirColor.Name = "barButtonItemElegirColor";
            this.barButtonItemElegirColor.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemElegirColor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemElegirColor_ItemClick);
            // 
            // ribbonPage
            // 
            this.ribbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupSolicitudes,
            this.ribbonPageGroupPreferencias,
            this.ribbonPageGroupAyudaEnLinea,
            this.ribbonPageGroupRegistro});
            this.ribbonPage.Name = "ribbonPage";
            this.ribbonPage.Text = "Menú";
            // 
            // ribbonPageGroupSolicitudes
            // 
            this.ribbonPageGroupSolicitudes.AllowTextClipping = false;
            this.ribbonPageGroupSolicitudes.ItemLinks.Add(this.barButtonItemVerSolicitudes);
            this.ribbonPageGroupSolicitudes.ItemLinks.Add(this.barButtonItemSolicitar);
            this.ribbonPageGroupSolicitudes.ItemLinks.Add(this.barButtonItemConsultarAhora);
            this.ribbonPageGroupSolicitudes.Name = "ribbonPageGroupSolicitudes";
            this.ribbonPageGroupSolicitudes.ShowCaptionButton = false;
            this.ribbonPageGroupSolicitudes.Text = "Solicitudes";
            // 
            // ribbonPageGroupPreferencias
            // 
            this.ribbonPageGroupPreferencias.AllowTextClipping = false;
            this.ribbonPageGroupPreferencias.ItemLinks.Add(this.barButtonItemPerfil);
            this.ribbonPageGroupPreferencias.ItemLinks.Add(this.barLinkContainerItemEmpleados);
            this.ribbonPageGroupPreferencias.ItemLinks.Add(this.barButtonItemVerEmpleados);
            this.ribbonPageGroupPreferencias.ItemLinks.Add(this.barButtonItemAnadirEmpleado);
            this.ribbonPageGroupPreferencias.ItemLinks.Add(this.barButtonItemAnadirAdministrador);
            this.ribbonPageGroupPreferencias.ItemLinks.Add(this.barButtonItemConfiguracion);
            this.ribbonPageGroupPreferencias.Name = "ribbonPageGroupPreferencias";
            this.ribbonPageGroupPreferencias.ShowCaptionButton = false;
            this.ribbonPageGroupPreferencias.Text = "Preferencias";
            // 
            // ribbonPageGroupAyudaEnLinea
            // 
            this.ribbonPageGroupAyudaEnLinea.AllowTextClipping = false;
            this.ribbonPageGroupAyudaEnLinea.ItemLinks.Add(this.barButtonItemChat);
            this.ribbonPageGroupAyudaEnLinea.ItemLinks.Add(this.barButtonItemConectar);
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
            this.ribbonPageGroupRegistro.ItemLinks.Add(this.barButtonItemElegirFuente);
            this.ribbonPageGroupRegistro.ItemLinks.Add(this.barButtonItemElegirColor);
            this.ribbonPageGroupRegistro.Name = "ribbonPageGroupRegistro";
            this.ribbonPageGroupRegistro.ShowCaptionButton = false;
            this.ribbonPageGroupRegistro.Text = "Registro de aplicación";
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemEmpleadoLabel);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemEmpleado);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 694);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(828, 25);
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
            this.barButtonItemVerSolicitudesDesguace.Glyph = global::Aplicación_de_Escritorio.Properties.Resources.document_32;
            this.barButtonItemVerSolicitudesDesguace.Id = 22;
            this.barButtonItemVerSolicitudesDesguace.Name = "barButtonItemVerSolicitudesDesguace";
            this.barButtonItemVerSolicitudesDesguace.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStripNotifyIcon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Aplicación de Escritorio - Criludage";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStripNotifyIcon
            // 
            this.contextMenuStripNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAbrirAplicacion,
            this.toolStripMenuItemCerrarSesion,
            this.toolStripMenuItemSalir});
            this.contextMenuStripNotifyIcon.Name = "contextMenuStripNotifyIcon";
            this.contextMenuStripNotifyIcon.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStripNotifyIcon.Size = new System.Drawing.Size(158, 70);
            this.contextMenuStripNotifyIcon.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripNotifyIcon_Opening);
            // 
            // toolStripMenuItemAbrirAplicacion
            // 
            this.toolStripMenuItemAbrirAplicacion.Image = global::Aplicación_de_Escritorio.Properties.Resources.maximizar;
            this.toolStripMenuItemAbrirAplicacion.Name = "toolStripMenuItemAbrirAplicacion";
            this.toolStripMenuItemAbrirAplicacion.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItemAbrirAplicacion.Text = "Abrir aplicación";
            this.toolStripMenuItemAbrirAplicacion.Click += new System.EventHandler(this.toolStripMenuItemAbrirAplicacion_Click);
            // 
            // toolStripMenuItemCerrarSesion
            // 
            this.toolStripMenuItemCerrarSesion.Image = global::Aplicación_de_Escritorio.Properties.Resources.sesion16;
            this.toolStripMenuItemCerrarSesion.Name = "toolStripMenuItemCerrarSesion";
            this.toolStripMenuItemCerrarSesion.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItemCerrarSesion.Text = "Cerrar sesión";
            this.toolStripMenuItemCerrarSesion.Click += new System.EventHandler(this.toolStripMenuItemCerrarSesion_Click);
            // 
            // toolStripMenuItemSalir
            // 
            this.toolStripMenuItemSalir.Image = global::Aplicación_de_Escritorio.Properties.Resources.salir16;
            this.toolStripMenuItemSalir.Name = "toolStripMenuItemSalir";
            this.toolStripMenuItemSalir.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItemSalir.Text = "Salir";
            this.toolStripMenuItemSalir.Click += new System.EventHandler(this.toolStripMenuItemSalir_Click);
            // 
            // alertControlSolicitudes
            // 
            this.alertControlSolicitudes.AppearanceCaption.ForeColor = System.Drawing.Color.Black;
            this.alertControlSolicitudes.AppearanceCaption.Options.UseForeColor = true;
            this.alertControlSolicitudes.AppearanceHotTrackedText.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.alertControlSolicitudes.AppearanceHotTrackedText.ForeColor = System.Drawing.Color.Black;
            this.alertControlSolicitudes.AppearanceHotTrackedText.Options.UseFont = true;
            this.alertControlSolicitudes.AppearanceHotTrackedText.Options.UseForeColor = true;
            this.alertControlSolicitudes.AutoFormDelay = 900000;
            alertButton1.Hint = "Ver solicitud";
            alertButton1.Image = global::Aplicación_de_Escritorio.Properties.Resources.document_16;
            alertButton1.Name = "alertButtonVerSolicitud";
            this.alertControlSolicitudes.Buttons.Add(alertButton1);
            this.alertControlSolicitudes.ButtonClick += new DevExpress.XtraBars.Alerter.AlertButtonClickEventHandler(this.alertControlSolicitudes_ButtonClick);
            // 
            // timerSolicitudesFinalizadas
            // 
            this.timerSolicitudesFinalizadas.Interval = 5000;
            this.timerSolicitudesFinalizadas.Tick += new System.EventHandler(this.timerSolicitudesFinalizadas_Tick);
            // 
            // timerConsumirSolicitudes
            // 
            this.timerConsumirSolicitudes.Interval = 5000;
            this.timerConsumirSolicitudes.Tick += new System.EventHandler(this.timerConsumirSolicitudes_Tick);
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 719);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.Controls.Add(this.panelContenido);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBase";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Aplicación de Escritorio - Criludage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBase_FormClosing);
            this.Load += new System.EventHandler(this.FormBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            this.contextMenuStripNotifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenido;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupPreferencias;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSolicitudes;
        private DevExpress.XtraBars.BarButtonItem barButtonItemVerSolicitudes;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSolicitar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemVerEmpleados;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAnadirEmpleado;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAnadirAdministrador;
        private DevExpress.XtraBars.BarButtonItem barButtonItemConfiguracion;
        private DevExpress.XtraBars.BarButtonItem barButtonItemPerfil;
        private DevExpress.XtraBars.BarButtonItem barButtonItemConectar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDesconectar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemVer;
        private DevExpress.XtraBars.BarButtonItem barButtonItemLimpiar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemElegirFuente;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAyudaEnLinea;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupRegistro;
        private DevExpress.XtraBars.BarButtonItem barButtonItemChat;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageSolicitudesDesguace;
        private DevExpress.XtraBars.BarButtonItem barButtonItemVerSolicitudesDesguace;
        private DevExpress.XtraBars.BarLinkContainerItem barLinkContainerItemEmpleados;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAnterior;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSiguiente;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu;
        private DevExpress.XtraBars.BarButtonItem barButtonItemRealizarCopia;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCargarCopia;
        private DevExpress.XtraBars.BarButtonItem barButtonItemMinimizarBandeja;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSalir;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAcercaDe;
        private DevExpress.XtraBars.BarStaticItem barStaticItemEmpleadoLabel;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraBars.BarStaticItem barStaticItemEmpleado;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCerrar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCerrarSesion;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSalir;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbrirAplicacion;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCerrarSesion;
        private DevExpress.XtraBars.Alerter.AlertControl alertControlSolicitudes;
        private DevExpress.XtraBars.BarButtonItem barButtonItemConsultarAhora;
        private System.Windows.Forms.Timer timerSolicitudesFinalizadas;
        private System.Windows.Forms.Timer timerConsumirSolicitudes;
        private DevExpress.XtraBars.BarButtonItem barButtonItemElegirColor;
    }
}