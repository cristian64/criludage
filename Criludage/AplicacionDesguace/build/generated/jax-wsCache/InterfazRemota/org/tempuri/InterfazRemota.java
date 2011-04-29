
package org.tempuri;

import java.net.MalformedURLException;
import java.net.URL;
import java.util.logging.Logger;
import javax.xml.namespace.QName;
import javax.xml.ws.Service;
import javax.xml.ws.WebEndpoint;
import javax.xml.ws.WebServiceClient;
import javax.xml.ws.WebServiceFeature;


/**
 * This class was generated by the JAX-WS RI.
 * JAX-WS RI 2.1.4-b01-
 * Generated source version: 2.1
 * 
 */
@WebServiceClient(name = "InterfazRemota", targetNamespace = "http://tempuri.org/", wsdlLocation = "http://192.168.2.5:8081/InterfazRemota.asmx?WSDL")
public class InterfazRemota
    extends Service
{

    private final static URL INTERFAZREMOTA_WSDL_LOCATION;
    private final static Logger logger = Logger.getLogger(org.tempuri.InterfazRemota.class.getName());

    static {
        URL url = null;
        try {
            URL baseUrl;
            baseUrl = org.tempuri.InterfazRemota.class.getResource(".");
            url = new URL(baseUrl, "http://192.168.2.5:8081/InterfazRemota.asmx?WSDL");
        } catch (MalformedURLException e) {
            logger.warning("Failed to create URL for the wsdl Location: 'http://192.168.2.5:8081/InterfazRemota.asmx?WSDL', retrying as a local file");
            logger.warning(e.getMessage());
        }
        INTERFAZREMOTA_WSDL_LOCATION = url;
    }

    public InterfazRemota(URL wsdlLocation, QName serviceName) {
        super(wsdlLocation, serviceName);
    }

    public InterfazRemota() {
        super(INTERFAZREMOTA_WSDL_LOCATION, new QName("http://tempuri.org/", "InterfazRemota"));
    }

    /**
     * 
     * @return
     *     returns InterfazRemotaSoap
     */
    @WebEndpoint(name = "InterfazRemotaSoap")
    public InterfazRemotaSoap getInterfazRemotaSoap() {
        return super.getPort(new QName("http://tempuri.org/", "InterfazRemotaSoap"), InterfazRemotaSoap.class);
    }

    /**
     * 
     * @param features
     *     A list of {@link javax.xml.ws.WebServiceFeature} to configure on the proxy.  Supported features not in the <code>features</code> parameter will have their default values.
     * @return
     *     returns InterfazRemotaSoap
     */
    @WebEndpoint(name = "InterfazRemotaSoap")
    public InterfazRemotaSoap getInterfazRemotaSoap(WebServiceFeature... features) {
        return super.getPort(new QName("http://tempuri.org/", "InterfazRemotaSoap"), InterfazRemotaSoap.class, features);
    }

    /**
     * 
     * @return
     *     returns InterfazRemotaSoap
     */
    @WebEndpoint(name = "InterfazRemotaSoap12")
    public InterfazRemotaSoap getInterfazRemotaSoap12() {
        return super.getPort(new QName("http://tempuri.org/", "InterfazRemotaSoap12"), InterfazRemotaSoap.class);
    }

    /**
     * 
     * @param features
     *     A list of {@link javax.xml.ws.WebServiceFeature} to configure on the proxy.  Supported features not in the <code>features</code> parameter will have their default values.
     * @return
     *     returns InterfazRemotaSoap
     */
    @WebEndpoint(name = "InterfazRemotaSoap12")
    public InterfazRemotaSoap getInterfazRemotaSoap12(WebServiceFeature... features) {
        return super.getPort(new QName("http://tempuri.org/", "InterfazRemotaSoap12"), InterfazRemotaSoap.class, features);
    }

}