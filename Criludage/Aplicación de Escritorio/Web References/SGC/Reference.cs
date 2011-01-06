﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.1
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.1.
// 
#pragma warning disable 1591

namespace Aplicación_de_Escritorio.SGC {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="InterfazRemotaSoap", Namespace="http://tempuri.org/")]
    public partial class InterfazRemota : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback solicitarPiezaOperationCompleted;
        
        private System.Threading.SendOrPostCallback proponerPiezaOperationCompleted;
        
        private System.Threading.SendOrPostCallback ObtenerClienteOperationCompleted;
        
        private System.Threading.SendOrPostCallback ObtenerDesguaceOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public InterfazRemota() {
            this.Url = global::Aplicación_de_Escritorio.Properties.Settings.Default.Aplicación_de_Escritorio_SGC_InterfazRemota;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event solicitarPiezaCompletedEventHandler solicitarPiezaCompleted;
        
        /// <remarks/>
        public event proponerPiezaCompletedEventHandler proponerPiezaCompleted;
        
        /// <remarks/>
        public event ObtenerClienteCompletedEventHandler ObtenerClienteCompleted;
        
        /// <remarks/>
        public event ObtenerDesguaceCompletedEventHandler ObtenerDesguaceCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/solicitarPieza", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int solicitarPieza(ENSolicitud solicitud) {
            object[] results = this.Invoke("solicitarPieza", new object[] {
                        solicitud});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void solicitarPiezaAsync(ENSolicitud solicitud) {
            this.solicitarPiezaAsync(solicitud, null);
        }
        
        /// <remarks/>
        public void solicitarPiezaAsync(ENSolicitud solicitud, object userState) {
            if ((this.solicitarPiezaOperationCompleted == null)) {
                this.solicitarPiezaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnsolicitarPiezaOperationCompleted);
            }
            this.InvokeAsync("solicitarPieza", new object[] {
                        solicitud}, this.solicitarPiezaOperationCompleted, userState);
        }
        
        private void OnsolicitarPiezaOperationCompleted(object arg) {
            if ((this.solicitarPiezaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.solicitarPiezaCompleted(this, new solicitarPiezaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/proponerPieza", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int proponerPieza(ENPropuesta propuesta) {
            object[] results = this.Invoke("proponerPieza", new object[] {
                        propuesta});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void proponerPiezaAsync(ENPropuesta propuesta) {
            this.proponerPiezaAsync(propuesta, null);
        }
        
        /// <remarks/>
        public void proponerPiezaAsync(ENPropuesta propuesta, object userState) {
            if ((this.proponerPiezaOperationCompleted == null)) {
                this.proponerPiezaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnproponerPiezaOperationCompleted);
            }
            this.InvokeAsync("proponerPieza", new object[] {
                        propuesta}, this.proponerPiezaOperationCompleted, userState);
        }
        
        private void OnproponerPiezaOperationCompleted(object arg) {
            if ((this.proponerPiezaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.proponerPiezaCompleted(this, new proponerPiezaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ObtenerCliente", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ENCliente ObtenerCliente(int id) {
            object[] results = this.Invoke("ObtenerCliente", new object[] {
                        id});
            return ((ENCliente)(results[0]));
        }
        
        /// <remarks/>
        public void ObtenerClienteAsync(int id) {
            this.ObtenerClienteAsync(id, null);
        }
        
        /// <remarks/>
        public void ObtenerClienteAsync(int id, object userState) {
            if ((this.ObtenerClienteOperationCompleted == null)) {
                this.ObtenerClienteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnObtenerClienteOperationCompleted);
            }
            this.InvokeAsync("ObtenerCliente", new object[] {
                        id}, this.ObtenerClienteOperationCompleted, userState);
        }
        
        private void OnObtenerClienteOperationCompleted(object arg) {
            if ((this.ObtenerClienteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ObtenerClienteCompleted(this, new ObtenerClienteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ObtenerDesguace", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ENDesguace ObtenerDesguace(int id) {
            object[] results = this.Invoke("ObtenerDesguace", new object[] {
                        id});
            return ((ENDesguace)(results[0]));
        }
        
        /// <remarks/>
        public void ObtenerDesguaceAsync(int id) {
            this.ObtenerDesguaceAsync(id, null);
        }
        
        /// <remarks/>
        public void ObtenerDesguaceAsync(int id, object userState) {
            if ((this.ObtenerDesguaceOperationCompleted == null)) {
                this.ObtenerDesguaceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnObtenerDesguaceOperationCompleted);
            }
            this.InvokeAsync("ObtenerDesguace", new object[] {
                        id}, this.ObtenerDesguaceOperationCompleted, userState);
        }
        
        private void OnObtenerDesguaceOperationCompleted(object arg) {
            if ((this.ObtenerDesguaceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ObtenerDesguaceCompleted(this, new ObtenerDesguaceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ENSolicitud {
        
        private int idField;
        
        private string descripcionField;
        
        private System.DateTime fechaField;
        
        private bool negociadoAutomaticoField;
        
        private System.DateTime fechaRespuestaField;
        
        private System.DateTime fechaEntregaField;
        
        private ENEstadosPieza estadoField;
        
        private float precioMaxField;
        
        private int idClienteField;
        
        /// <comentarios/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <comentarios/>
        public string Descripcion {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
            }
        }
        
        /// <comentarios/>
        public System.DateTime Fecha {
            get {
                return this.fechaField;
            }
            set {
                this.fechaField = value;
            }
        }
        
        /// <comentarios/>
        public bool NegociadoAutomatico {
            get {
                return this.negociadoAutomaticoField;
            }
            set {
                this.negociadoAutomaticoField = value;
            }
        }
        
        /// <comentarios/>
        public System.DateTime FechaRespuesta {
            get {
                return this.fechaRespuestaField;
            }
            set {
                this.fechaRespuestaField = value;
            }
        }
        
        /// <comentarios/>
        public System.DateTime FechaEntrega {
            get {
                return this.fechaEntregaField;
            }
            set {
                this.fechaEntregaField = value;
            }
        }
        
        /// <comentarios/>
        public ENEstadosPieza Estado {
            get {
                return this.estadoField;
            }
            set {
                this.estadoField = value;
            }
        }
        
        /// <comentarios/>
        public float PrecioMax {
            get {
                return this.precioMaxField;
            }
            set {
                this.precioMaxField = value;
            }
        }
        
        /// <comentarios/>
        public int IdCliente {
            get {
                return this.idClienteField;
            }
            set {
                this.idClienteField = value;
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum ENEstadosPieza {
        
        /// <comentarios/>
        USADA,
        
        /// <comentarios/>
        NUEVA,
        
        /// <comentarios/>
        NO_FUNCIONA,
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ENDesguace {
        
        private int idField;
        
        private string usuarioField;
        
        private string contrasenaField;
        
        private string nombreField;
        
        private string nifField;
        
        private string correoElectronicoField;
        
        private string telefonoField;
        
        private string direccionField;
        
        private string informacionAdicionalField;
        
        /// <comentarios/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <comentarios/>
        public string Usuario {
            get {
                return this.usuarioField;
            }
            set {
                this.usuarioField = value;
            }
        }
        
        /// <comentarios/>
        public string Contrasena {
            get {
                return this.contrasenaField;
            }
            set {
                this.contrasenaField = value;
            }
        }
        
        /// <comentarios/>
        public string Nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
            }
        }
        
        /// <comentarios/>
        public string Nif {
            get {
                return this.nifField;
            }
            set {
                this.nifField = value;
            }
        }
        
        /// <comentarios/>
        public string CorreoElectronico {
            get {
                return this.correoElectronicoField;
            }
            set {
                this.correoElectronicoField = value;
            }
        }
        
        /// <comentarios/>
        public string Telefono {
            get {
                return this.telefonoField;
            }
            set {
                this.telefonoField = value;
            }
        }
        
        /// <comentarios/>
        public string Direccion {
            get {
                return this.direccionField;
            }
            set {
                this.direccionField = value;
            }
        }
        
        /// <comentarios/>
        public string InformacionAdicional {
            get {
                return this.informacionAdicionalField;
            }
            set {
                this.informacionAdicionalField = value;
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ENCliente {
        
        private int idField;
        
        private string usuarioField;
        
        private string contrasenaField;
        
        private string nombreField;
        
        private string nifField;
        
        private string correoElectronicoField;
        
        private string telefonoField;
        
        private string direccionField;
        
        private string informacionAdicionalField;
        
        /// <comentarios/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <comentarios/>
        public string Usuario {
            get {
                return this.usuarioField;
            }
            set {
                this.usuarioField = value;
            }
        }
        
        /// <comentarios/>
        public string Contrasena {
            get {
                return this.contrasenaField;
            }
            set {
                this.contrasenaField = value;
            }
        }
        
        /// <comentarios/>
        public string Nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
            }
        }
        
        /// <comentarios/>
        public string Nif {
            get {
                return this.nifField;
            }
            set {
                this.nifField = value;
            }
        }
        
        /// <comentarios/>
        public string CorreoElectronico {
            get {
                return this.correoElectronicoField;
            }
            set {
                this.correoElectronicoField = value;
            }
        }
        
        /// <comentarios/>
        public string Telefono {
            get {
                return this.telefonoField;
            }
            set {
                this.telefonoField = value;
            }
        }
        
        /// <comentarios/>
        public string Direccion {
            get {
                return this.direccionField;
            }
            set {
                this.direccionField = value;
            }
        }
        
        /// <comentarios/>
        public string InformacionAdicional {
            get {
                return this.informacionAdicionalField;
            }
            set {
                this.informacionAdicionalField = value;
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ENPropuesta {
        
        private int idField;
        
        private string descripcionField;
        
        private System.DateTime fechaEntregaField;
        
        private ENEstadosPieza estadoField;
        
        private float precioField;
        
        private int idDesguaceField;
        
        private int idSolicitudField;
        
        /// <comentarios/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <comentarios/>
        public string Descripcion {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
            }
        }
        
        /// <comentarios/>
        public System.DateTime FechaEntrega {
            get {
                return this.fechaEntregaField;
            }
            set {
                this.fechaEntregaField = value;
            }
        }
        
        /// <comentarios/>
        public ENEstadosPieza Estado {
            get {
                return this.estadoField;
            }
            set {
                this.estadoField = value;
            }
        }
        
        /// <comentarios/>
        public float Precio {
            get {
                return this.precioField;
            }
            set {
                this.precioField = value;
            }
        }
        
        /// <comentarios/>
        public int IdDesguace {
            get {
                return this.idDesguaceField;
            }
            set {
                this.idDesguaceField = value;
            }
        }
        
        /// <comentarios/>
        public int IdSolicitud {
            get {
                return this.idSolicitudField;
            }
            set {
                this.idSolicitudField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void solicitarPiezaCompletedEventHandler(object sender, solicitarPiezaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class solicitarPiezaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal solicitarPiezaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void proponerPiezaCompletedEventHandler(object sender, proponerPiezaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class proponerPiezaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal proponerPiezaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void ObtenerClienteCompletedEventHandler(object sender, ObtenerClienteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ObtenerClienteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ObtenerClienteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ENCliente Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ENCliente)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void ObtenerDesguaceCompletedEventHandler(object sender, ObtenerDesguaceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ObtenerDesguaceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ObtenerDesguaceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ENDesguace Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ENDesguace)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591