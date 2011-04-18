
package org.tempuri;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for anonymous complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType>
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="ObtenerClienteResult" type="{http://tempuri.org/}ENCliente" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "obtenerClienteResult"
})
@XmlRootElement(name = "ObtenerClienteResponse")
public class ObtenerClienteResponse {

    @XmlElement(name = "ObtenerClienteResult")
    protected ENCliente obtenerClienteResult;

    /**
     * Gets the value of the obtenerClienteResult property.
     * 
     * @return
     *     possible object is
     *     {@link ENCliente }
     *     
     */
    public ENCliente getObtenerClienteResult() {
        return obtenerClienteResult;
    }

    /**
     * Sets the value of the obtenerClienteResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link ENCliente }
     *     
     */
    public void setObtenerClienteResult(ENCliente value) {
        this.obtenerClienteResult = value;
    }

}
