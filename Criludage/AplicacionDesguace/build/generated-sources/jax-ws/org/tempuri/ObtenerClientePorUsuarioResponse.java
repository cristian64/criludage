
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
 *         &lt;element name="ObtenerClientePorUsuarioResult" type="{http://tempuri.org/}ENCliente" minOccurs="0"/>
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
    "obtenerClientePorUsuarioResult"
})
@XmlRootElement(name = "ObtenerClientePorUsuarioResponse")
public class ObtenerClientePorUsuarioResponse {

    @XmlElement(name = "ObtenerClientePorUsuarioResult")
    protected ENCliente obtenerClientePorUsuarioResult;

    /**
     * Gets the value of the obtenerClientePorUsuarioResult property.
     * 
     * @return
     *     possible object is
     *     {@link ENCliente }
     *     
     */
    public ENCliente getObtenerClientePorUsuarioResult() {
        return obtenerClientePorUsuarioResult;
    }

    /**
     * Sets the value of the obtenerClientePorUsuarioResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link ENCliente }
     *     
     */
    public void setObtenerClientePorUsuarioResult(ENCliente value) {
        this.obtenerClientePorUsuarioResult = value;
    }

}
