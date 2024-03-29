
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
 *         &lt;element name="ObtenerDesguacePorUsuarioResult" type="{http://tempuri.org/}ENDesguace" minOccurs="0"/>
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
    "obtenerDesguacePorUsuarioResult"
})
@XmlRootElement(name = "ObtenerDesguacePorUsuarioResponse")
public class ObtenerDesguacePorUsuarioResponse {

    @XmlElement(name = "ObtenerDesguacePorUsuarioResult")
    protected ENDesguace obtenerDesguacePorUsuarioResult;

    /**
     * Gets the value of the obtenerDesguacePorUsuarioResult property.
     * 
     * @return
     *     possible object is
     *     {@link ENDesguace }
     *     
     */
    public ENDesguace getObtenerDesguacePorUsuarioResult() {
        return obtenerDesguacePorUsuarioResult;
    }

    /**
     * Sets the value of the obtenerDesguacePorUsuarioResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link ENDesguace }
     *     
     */
    public void setObtenerDesguacePorUsuarioResult(ENDesguace value) {
        this.obtenerDesguacePorUsuarioResult = value;
    }

}
