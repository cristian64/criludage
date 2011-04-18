
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
 *         &lt;element name="ObtenerPropuestasConfirmadasResult" type="{http://tempuri.org/}ArrayOfAnyType" minOccurs="0"/>
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
    "obtenerPropuestasConfirmadasResult"
})
@XmlRootElement(name = "ObtenerPropuestasConfirmadasResponse")
public class ObtenerPropuestasConfirmadasResponse {

    @XmlElement(name = "ObtenerPropuestasConfirmadasResult")
    protected ArrayOfAnyType obtenerPropuestasConfirmadasResult;

    /**
     * Gets the value of the obtenerPropuestasConfirmadasResult property.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfAnyType }
     *     
     */
    public ArrayOfAnyType getObtenerPropuestasConfirmadasResult() {
        return obtenerPropuestasConfirmadasResult;
    }

    /**
     * Sets the value of the obtenerPropuestasConfirmadasResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfAnyType }
     *     
     */
    public void setObtenerPropuestasConfirmadasResult(ArrayOfAnyType value) {
        this.obtenerPropuestasConfirmadasResult = value;
    }

}
