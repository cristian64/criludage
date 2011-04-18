
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
 *         &lt;element name="ObtenerPropuestaPorIdResult" type="{http://tempuri.org/}ENPropuesta" minOccurs="0"/>
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
    "obtenerPropuestaPorIdResult"
})
@XmlRootElement(name = "ObtenerPropuestaPorIdResponse")
public class ObtenerPropuestaPorIdResponse {

    @XmlElement(name = "ObtenerPropuestaPorIdResult")
    protected ENPropuesta obtenerPropuestaPorIdResult;

    /**
     * Gets the value of the obtenerPropuestaPorIdResult property.
     * 
     * @return
     *     possible object is
     *     {@link ENPropuesta }
     *     
     */
    public ENPropuesta getObtenerPropuestaPorIdResult() {
        return obtenerPropuestaPorIdResult;
    }

    /**
     * Sets the value of the obtenerPropuestaPorIdResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link ENPropuesta }
     *     
     */
    public void setObtenerPropuestaPorIdResult(ENPropuesta value) {
        this.obtenerPropuestaPorIdResult = value;
    }

}
