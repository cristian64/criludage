
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
 *         &lt;element name="RegistroDesguaceResult" type="{http://www.w3.org/2001/XMLSchema}int"/>
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
    "registroDesguaceResult"
})
@XmlRootElement(name = "RegistroDesguaceResponse")
public class RegistroDesguaceResponse {

    @XmlElement(name = "RegistroDesguaceResult")
    protected int registroDesguaceResult;

    /**
     * Gets the value of the registroDesguaceResult property.
     * 
     */
    public int getRegistroDesguaceResult() {
        return registroDesguaceResult;
    }

    /**
     * Sets the value of the registroDesguaceResult property.
     * 
     */
    public void setRegistroDesguaceResult(int value) {
        this.registroDesguaceResult = value;
    }

}
