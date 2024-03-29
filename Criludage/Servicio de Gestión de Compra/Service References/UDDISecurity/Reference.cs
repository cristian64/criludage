﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.225
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicio_de_Gestión_de_Compra.UDDISecurity {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:uddi-org:v3_service", ConfigurationName="UDDISecurity.UDDI_Security_PortType")]
    public interface UDDI_Security_PortType {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que la operación discard_authToken no es RPC ni está encapsulada en un documento.
        [System.ServiceModel.OperationContractAttribute(Action="discard_authToken", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Servicio_de_Gestión_de_Compra.UDDISecurity.discard_authTokenResponse discard_authToken(Servicio_de_Gestión_de_Compra.UDDISecurity.discard_authToken1 request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que la operación get_authToken no es RPC ni está encapsulada en un documento.
        [System.ServiceModel.OperationContractAttribute(Action="get_authToken", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Servicio_de_Gestión_de_Compra.UDDISecurity.get_authTokenResponse get_authToken(Servicio_de_Gestión_de_Compra.UDDISecurity.get_authToken1 request);
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:uddi-org:api_v3")]
    public partial class discard_authToken : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string authInfoField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string authInfo {
            get {
                return this.authInfoField;
            }
            set {
                this.authInfoField = value;
                this.RaisePropertyChanged("authInfo");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:uddi-org:api_v3")]
    public partial class authToken : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string authInfoField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string authInfo {
            get {
                return this.authInfoField;
            }
            set {
                this.authInfoField = value;
                this.RaisePropertyChanged("authInfo");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:uddi-org:api_v3")]
    public partial class get_authToken : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string userIDField;
        
        private string credField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string userID {
            get {
                return this.userIDField;
            }
            set {
                this.userIDField = value;
                this.RaisePropertyChanged("userID");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string cred {
            get {
                return this.credField;
            }
            set {
                this.credField = value;
                this.RaisePropertyChanged("cred");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class discard_authToken1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:uddi-org:api_v3", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public Servicio_de_Gestión_de_Compra.UDDISecurity.discard_authToken discard_authToken;
        
        public discard_authToken1() {
        }
        
        public discard_authToken1(Servicio_de_Gestión_de_Compra.UDDISecurity.discard_authToken discard_authToken) {
            this.discard_authToken = discard_authToken;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class discard_authTokenResponse {
        
        public discard_authTokenResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class get_authToken1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:uddi-org:api_v3", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public Servicio_de_Gestión_de_Compra.UDDISecurity.get_authToken get_authToken;
        
        public get_authToken1() {
        }
        
        public get_authToken1(Servicio_de_Gestión_de_Compra.UDDISecurity.get_authToken get_authToken) {
            this.get_authToken = get_authToken;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class get_authTokenResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:uddi-org:api_v3", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public Servicio_de_Gestión_de_Compra.UDDISecurity.authToken authToken;
        
        public get_authTokenResponse() {
        }
        
        public get_authTokenResponse(Servicio_de_Gestión_de_Compra.UDDISecurity.authToken authToken) {
            this.authToken = authToken;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface UDDI_Security_PortTypeChannel : Servicio_de_Gestión_de_Compra.UDDISecurity.UDDI_Security_PortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UDDI_Security_PortTypeClient : System.ServiceModel.ClientBase<Servicio_de_Gestión_de_Compra.UDDISecurity.UDDI_Security_PortType>, Servicio_de_Gestión_de_Compra.UDDISecurity.UDDI_Security_PortType {
        
        public UDDI_Security_PortTypeClient() {
        }
        
        public UDDI_Security_PortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UDDI_Security_PortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UDDI_Security_PortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UDDI_Security_PortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Servicio_de_Gestión_de_Compra.UDDISecurity.discard_authTokenResponse Servicio_de_Gestión_de_Compra.UDDISecurity.UDDI_Security_PortType.discard_authToken(Servicio_de_Gestión_de_Compra.UDDISecurity.discard_authToken1 request) {
            return base.Channel.discard_authToken(request);
        }
        
        public void discard_authToken(Servicio_de_Gestión_de_Compra.UDDISecurity.discard_authToken discard_authToken1) {
            Servicio_de_Gestión_de_Compra.UDDISecurity.discard_authToken1 inValue = new Servicio_de_Gestión_de_Compra.UDDISecurity.discard_authToken1();
            inValue.discard_authToken = discard_authToken1;
            Servicio_de_Gestión_de_Compra.UDDISecurity.discard_authTokenResponse retVal = ((Servicio_de_Gestión_de_Compra.UDDISecurity.UDDI_Security_PortType)(this)).discard_authToken(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Servicio_de_Gestión_de_Compra.UDDISecurity.get_authTokenResponse Servicio_de_Gestión_de_Compra.UDDISecurity.UDDI_Security_PortType.get_authToken(Servicio_de_Gestión_de_Compra.UDDISecurity.get_authToken1 request) {
            return base.Channel.get_authToken(request);
        }
        
        public Servicio_de_Gestión_de_Compra.UDDISecurity.authToken get_authToken(Servicio_de_Gestión_de_Compra.UDDISecurity.get_authToken get_authToken1) {
            Servicio_de_Gestión_de_Compra.UDDISecurity.get_authToken1 inValue = new Servicio_de_Gestión_de_Compra.UDDISecurity.get_authToken1();
            inValue.get_authToken = get_authToken1;
            Servicio_de_Gestión_de_Compra.UDDISecurity.get_authTokenResponse retVal = ((Servicio_de_Gestión_de_Compra.UDDISecurity.UDDI_Security_PortType)(this)).get_authToken(inValue);
            return retVal.authToken;
        }
    }
}
