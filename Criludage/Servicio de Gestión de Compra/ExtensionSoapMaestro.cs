using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using System.IO;
using System.Net;

namespace Servicio_de_Gestión_de_Compra
{
    public class ExtensionMaestro : SoapExtension
    {

        public override object GetInitializer(LogicalMethodInfo methodInfo,
                    SoapExtensionAttribute attribute)
        {
            return attribute;
        }


        public override object GetInitializer(Type t)
        {
            return typeof(ExtensionMaestro);
        }

        public override void Initialize(object initializer)
        {
            ExtensionMaestroAtributo attribute =
                (ExtensionMaestroAtributo)initializer;

            return;
        }

        public override void ProcessMessage(SoapMessage message)
        {

            switch (message.Stage)
            {
                case SoapMessageStage.BeforeDeserialize:
                    if (AltaDisponibilidad.SoyMaestro())
                        throw new Exception();
                    break;
                case SoapMessageStage.AfterDeserialize:
                    if (AltaDisponibilidad.SoyMaestro())
                        throw new Exception();
                    break;
            }
        }

    }

    [AttributeUsage(AttributeTargets.Method)]
    public class ExtensionMaestroAtributo : SoapExtensionAttribute
    {

        private int priority;

        // Override the base class properties
        public override Type ExtensionType
        {
            get { return typeof(ExtensionMaestro); }
        }

        public override int Priority
        {
            get
            {
                return priority;
            }
            set
            {
                priority = value;
            }
        }
    }
}