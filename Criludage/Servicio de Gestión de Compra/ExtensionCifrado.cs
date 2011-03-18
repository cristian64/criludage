using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;


namespace Servicio_de_Gestión_de_Compra
{

    public class ExtensionCifrado : System.Web.Services.Protocols.SoapExtension
    {
        Stream oldStream;
        Stream newStream;

        public override object GetInitializer(LogicalMethodInfo methodInfo,
                    SoapExtensionAttribute attribute)
        {
            return attribute;
        }

        // Get the Type
        public override object GetInitializer(Type t)
        {
            return typeof(ExtensionCifrado);
        }

        // Get the CompressionExtensionAttribute
        public override void Initialize(object initializer)
        {
            ExtensionCifradoAtributo attribute =
              (ExtensionCifradoAtributo)initializer;

            return;
        }

        // Process the SOAP Message
        public override void ProcessMessage(SoapMessage message)
        {
            // Check for the various SOAP Message Stages 
            switch (message.Stage)
            {

                case SoapMessageStage.BeforeSerialize:
                    break;

                case SoapMessageStage.AfterSerialize:
                    // ZIP the contents of the SOAP Body after it has
                    // been serialized
                    Encrypt();
                    break;

                case SoapMessageStage.BeforeDeserialize:
                    // Unzip the contents of the SOAP Body before it is
                    // deserialized
                    Decrypt();
                    break;

                case SoapMessageStage.AfterDeserialize:
                    break;

                default:
                    throw new Exception("invalid stage");
            }
        }

        // Gives us the ability to get hold of the RAW SOAP message
        public override Stream ChainStream(Stream stream)
        {
            oldStream = stream;
            newStream = new MemoryStream();
            return newStream;
        }

        // Utility method to copy streams
        void Copy(Stream from, Stream to)
        {
            TextReader reader = new StreamReader(from);
            TextWriter writer = new StreamWriter(to);
            writer.WriteLine(reader.ReadToEnd());
            writer.Flush();
        }


        // Encrypt the SOAP Body
        private void Encrypt()
        {
            newStream.Position = 0;
            // Encrypt the SOAP Body
            newStream = Encrypt(newStream);
            // Copy the streams
            Copy(newStream, oldStream);
        }

        // Decrypt the SOAP Body
        private void Decrypt()
        {
            MemoryStream stream = new MemoryStream();

            TextReader reader = new StreamReader(oldStream);
            TextWriter writer = new StreamWriter(stream);
            writer.WriteLine(reader.ReadToEnd());
            writer.Flush();

            // Decrypt the SOAP Body
            stream = Decrypt(stream);

            // Copy the streams
            Copy(stream, newStream);

            newStream.Position = 0;
        }

        public MemoryStream Encrypt(Stream streamToEncrypt)
        {
            streamToEncrypt.Position = 0;
            // Load a XML Reader
            XmlTextReader reader = new XmlTextReader(streamToEncrypt);
            XmlDocument dom = new XmlDocument();
            dom.Load(reader);
            // Load a NamespaceManager to enable XPath selection
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(dom.NameTable);
            nsmgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            XmlNode node = dom.SelectSingleNode("//soap:Body", nsmgr);
            // Select the contents within the method defined in the SOAP body
            node = node.FirstChild.FirstChild;
            // Check if there are any nodes selected
            while (node != null)
            {
                /*if (node.InnerXml.Length > 0)
                {
                    // Zip the data
                    byte[] outData = Encrypt(node.InnerXml);
                    // Convert it to Base64 for transfer over the internet
                    node.InnerXml = Convert.ToBase64String(outData);
                }*/
                // Move to the next parameter
                node = node.NextSibling;
            }
            MemoryStream ms = new MemoryStream();
            // Save the updated data
            dom.Save(ms);
            ms.Position = 0;

            return ms;

        }

        public MemoryStream Decrypt(Stream streamToEncrypt)
        {
            streamToEncrypt.Position = 0;
            // Load a XmlReader
            XmlTextReader reader = new XmlTextReader(streamToEncrypt);
            XmlDocument dom = new XmlDocument();
            dom.Load(reader);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(dom.NameTable);
            nsmgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            // Select the SOAP Body node 
            XmlNode node = dom.SelectSingleNode("//soap:Body", nsmgr);
            node = node.FirstChild.FirstChild;

            // Check if node exists
            while (node != null)
            {
                /*if (node.InnerXml.Length > 0)
                {
                    // Send the node's contents to be unziped
                    byte[] outData = Decrypt(node.InnerXml);
                    string sTmp = Encoding.UTF8.GetString(outData);
                    node.InnerXml = sTmp;
                }*/
                // Move to the next parameter
                node = node.NextSibling;
            }

            MemoryStream ms = new MemoryStream();

            dom.Save(ms);
            ms.Position = 0;

            return ms;

        }

        private void SalidaDebug()
        {
            long pos1 = oldStream.Position, pos2 = newStream.Position;
            String salida;
            StreamReader reader1 = new StreamReader(oldStream);
            StreamReader reader2 = new StreamReader(oldStream);

            salida=reader1.ReadToEnd();
            salida += "\n\n\n";
            salida += reader2.ReadToEnd();

            Registro.WriteLine("otro", "", "ExtensionCifrado: " + salida);

            oldStream.Position = pos1;
            newStream.Position = pos2;
        }



    }


    [AttributeUsage(AttributeTargets.Method)]
    public class ExtensionCifradoAtributo : SoapExtensionAttribute
    {

        private int priority;

        // Override the base class properties
        public override Type ExtensionType
        {
            get { return typeof(ExtensionCifrado); }
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