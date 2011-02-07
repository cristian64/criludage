
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
 *         &lt;element name="ActualizarDesguaceResult" type="{http://www.w3.org/2001/XMLSchema}boolean"/>
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
    "actualizarDesguaceResult"
})
@XmlRootElement(name = "ActualizarDesguaceResponse")
public class ActualizarDesguaceResponse {

    @XmlElement(name = "ActualizarDesguaceResult")
    protected boolean actualizarDesguaceResult;

    /**
     * Gets the value of the actualizarDesguaceResult property.
     * 
     */
    public boolean isActualizarDesguaceResult() {
        return actualizarDesguaceResult;
    }

    /**
     * Sets the value of the actualizarDesguaceResult property.
     * 
     */
    public void setActualizarDesguaceResult(boolean value) {
        this.actualizarDesguaceResult = value;
    }

}
