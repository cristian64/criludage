
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
 *         &lt;element name="ProponerPiezaResult" type="{http://www.w3.org/2001/XMLSchema}int"/>
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
    "proponerPiezaResult"
})
@XmlRootElement(name = "ProponerPiezaResponse")
public class ProponerPiezaResponse {

    @XmlElement(name = "ProponerPiezaResult")
    protected int proponerPiezaResult;

    /**
     * Gets the value of the proponerPiezaResult property.
     * 
     */
    public int getProponerPiezaResult() {
        return proponerPiezaResult;
    }

    /**
     * Sets the value of the proponerPiezaResult property.
     * 
     */
    public void setProponerPiezaResult(int value) {
        this.proponerPiezaResult = value;
    }

}
