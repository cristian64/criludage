
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
 *         &lt;element name="ActualizarClienteResult" type="{http://www.w3.org/2001/XMLSchema}boolean"/>
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
    "actualizarClienteResult"
})
@XmlRootElement(name = "ActualizarClienteResponse")
public class ActualizarClienteResponse {

    @XmlElement(name = "ActualizarClienteResult")
    protected boolean actualizarClienteResult;

    /**
     * Gets the value of the actualizarClienteResult property.
     * 
     */
    public boolean isActualizarClienteResult() {
        return actualizarClienteResult;
    }

    /**
     * Sets the value of the actualizarClienteResult property.
     * 
     */
    public void setActualizarClienteResult(boolean value) {
        this.actualizarClienteResult = value;
    }

}
