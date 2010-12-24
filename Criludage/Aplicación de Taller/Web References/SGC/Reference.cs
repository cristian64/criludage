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

namespace Aplicación_de_Taller.SGC {
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(object[]))]
    public partial class InterfazRemota : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback solicitarPiezaOperationCompleted;
        
        private System.Threading.SendOrPostCallback proponerPiezaOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public InterfazRemota() {
            this.Url = global::Aplicación_de_Taller.Properties.Settings.Default.Aplicación_de_Taller_SGC_InterfazRemota;
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
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/solicitarPieza", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool solicitarPieza(Solicitud solicitud, string usuario, string contrasena) {
            object[] results = this.Invoke("solicitarPieza", new object[] {
                        solicitud,
                        usuario,
                        contrasena});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void solicitarPiezaAsync(Solicitud solicitud, string usuario, string contrasena) {
            this.solicitarPiezaAsync(solicitud, usuario, contrasena, null);
        }
        
        /// <remarks/>
        public void solicitarPiezaAsync(Solicitud solicitud, string usuario, string contrasena, object userState) {
            if ((this.solicitarPiezaOperationCompleted == null)) {
                this.solicitarPiezaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnsolicitarPiezaOperationCompleted);
            }
            this.InvokeAsync("solicitarPieza", new object[] {
                        solicitud,
                        usuario,
                        contrasena}, this.solicitarPiezaOperationCompleted, userState);
        }
        
        private void OnsolicitarPiezaOperationCompleted(object arg) {
            if ((this.solicitarPiezaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.solicitarPiezaCompleted(this, new solicitarPiezaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/proponerPieza", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool proponerPieza(Propuesta propuesta, Solicitud solicitud, string usuario, string contrasena) {
            object[] results = this.Invoke("proponerPieza", new object[] {
                        propuesta,
                        solicitud,
                        usuario,
                        contrasena});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void proponerPiezaAsync(Propuesta propuesta, Solicitud solicitud, string usuario, string contrasena) {
            this.proponerPiezaAsync(propuesta, solicitud, usuario, contrasena, null);
        }
        
        /// <remarks/>
        public void proponerPiezaAsync(Propuesta propuesta, Solicitud solicitud, string usuario, string contrasena, object userState) {
            if ((this.proponerPiezaOperationCompleted == null)) {
                this.proponerPiezaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnproponerPiezaOperationCompleted);
            }
            this.InvokeAsync("proponerPieza", new object[] {
                        propuesta,
                        solicitud,
                        usuario,
                        contrasena}, this.proponerPiezaOperationCompleted, userState);
        }
        
        private void OnproponerPiezaOperationCompleted(object arg) {
            if ((this.proponerPiezaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.proponerPiezaCompleted(this, new proponerPiezaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public partial class Solicitud {
        
        private int idField;
        
        private string descripcionField;
        
        private System.DateTime fechaField;
        
        private bool negociadoAutomaticoField;
        
        private System.DateTime fechaEntregaField;
        
        private EstadosPieza estadoField;
        
        private float precioMaxField;
        
        private Cliente clienteField;
        
        private object[] propuestasField;
        
        private Propuesta propuestaAceptadaField;
        
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
        public System.DateTime FechaEntrega {
            get {
                return this.fechaEntregaField;
            }
            set {
                this.fechaEntregaField = value;
            }
        }
        
        /// <comentarios/>
        public EstadosPieza Estado {
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
        public Cliente Cliente {
            get {
                return this.clienteField;
            }
            set {
                this.clienteField = value;
            }
        }
        
        /// <comentarios/>
        public object[] Propuestas {
            get {
                return this.propuestasField;
            }
            set {
                this.propuestasField = value;
            }
        }
        
        /// <comentarios/>
        public Propuesta PropuestaAceptada {
            get {
                return this.propuestaAceptadaField;
            }
            set {
                this.propuestaAceptadaField = value;
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum EstadosPieza {
        
        /// <comentarios/>
        NUEVA,
        
        /// <comentarios/>
        POCO_USADA,
        
        /// <comentarios/>
        USADA,
        
        /// <comentarios/>
        MUY_USADA,
        
        /// <comentarios/>
        NO_FUNCIONA,
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Cliente {
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Desguace {
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Propuesta {
        
        private int idField;
        
        private string descripcionField;
        
        private byte[] fotoField;
        
        private System.DateTime fechaEntregaField;
        
        private EstadosPieza estadoField;
        
        private int precioField;
        
        private bool aceptadaField;
        
        private Desguace desguaceField;
        
        private Solicitud solicitudField;
        
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
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] Foto {
            get {
                return this.fotoField;
            }
            set {
                this.fotoField = value;
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
        public EstadosPieza Estado {
            get {
                return this.estadoField;
            }
            set {
                this.estadoField = value;
            }
        }
        
        /// <comentarios/>
        public int Precio {
            get {
                return this.precioField;
            }
            set {
                this.precioField = value;
            }
        }
        
        /// <comentarios/>
        public bool Aceptada {
            get {
                return this.aceptadaField;
            }
            set {
                this.aceptadaField = value;
            }
        }
        
        /// <comentarios/>
        public Desguace Desguace {
            get {
                return this.desguaceField;
            }
            set {
                this.desguaceField = value;
            }
        }
        
        /// <comentarios/>
        public Solicitud Solicitud {
            get {
                return this.solicitudField;
            }
            set {
                this.solicitudField = value;
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
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
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
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591