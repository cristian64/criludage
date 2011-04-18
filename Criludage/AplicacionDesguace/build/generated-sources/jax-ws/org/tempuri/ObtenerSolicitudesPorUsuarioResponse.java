
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
 *         &lt;element name="ObtenerSolicitudesPorUsuarioResult" type="{http://tempuri.org/}ArrayOfAnyType" minOccurs="0"/>
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
    "obtenerSolicitudesPorUsuarioResult"
})
@XmlRootElement(name = "ObtenerSolicitudesPorUsuarioResponse")
public class ObtenerSolicitudesPorUsuarioResponse {

    @XmlElement(name = "ObtenerSolicitudesPorUsuarioResult")
    protected ArrayOfAnyType obtenerSolicitudesPorUsuarioResult;

    /**
     * Gets the value of the obtenerSolicitudesPorUsuarioResult property.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfAnyType }
     *     
     */
    public ArrayOfAnyType getObtenerSolicitudesPorUsuarioResult() {
        return obtenerSolicitudesPorUsuarioResult;
    }

    /**
     * Sets the value of the obtenerSolicitudesPorUsuarioResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfAnyType }
     *     
     */
    public void setObtenerSolicitudesPorUsuarioResult(ArrayOfAnyType value) {
        this.obtenerSolicitudesPorUsuarioResult = value;
    }

}
