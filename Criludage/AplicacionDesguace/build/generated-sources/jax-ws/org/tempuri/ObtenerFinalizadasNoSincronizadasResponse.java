
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
 *         &lt;element name="ObtenerFinalizadasNoSincronizadasResult" type="{http://tempuri.org/}ArrayOfAnyType" minOccurs="0"/>
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
    "obtenerFinalizadasNoSincronizadasResult"
})
@XmlRootElement(name = "ObtenerFinalizadasNoSincronizadasResponse")
public class ObtenerFinalizadasNoSincronizadasResponse {

    @XmlElement(name = "ObtenerFinalizadasNoSincronizadasResult")
    protected ArrayOfAnyType obtenerFinalizadasNoSincronizadasResult;

    /**
     * Gets the value of the obtenerFinalizadasNoSincronizadasResult property.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfAnyType }
     *     
     */
    public ArrayOfAnyType getObtenerFinalizadasNoSincronizadasResult() {
        return obtenerFinalizadasNoSincronizadasResult;
    }

    /**
     * Sets the value of the obtenerFinalizadasNoSincronizadasResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfAnyType }
     *     
     */
    public void setObtenerFinalizadasNoSincronizadasResult(ArrayOfAnyType value) {
        this.obtenerFinalizadasNoSincronizadasResult = value;
    }

}
