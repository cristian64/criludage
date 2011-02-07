
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
 *         &lt;element name="RegistroClienteResult" type="{http://www.w3.org/2001/XMLSchema}int"/>
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
    "registroClienteResult"
})
@XmlRootElement(name = "RegistroClienteResponse")
public class RegistroClienteResponse {

    @XmlElement(name = "RegistroClienteResult")
    protected int registroClienteResult;

    /**
     * Gets the value of the registroClienteResult property.
     * 
     */
    public int getRegistroClienteResult() {
        return registroClienteResult;
    }

    /**
     * Sets the value of the registroClienteResult property.
     * 
     */
    public void setRegistroClienteResult(int value) {
        this.registroClienteResult = value;
    }

}
