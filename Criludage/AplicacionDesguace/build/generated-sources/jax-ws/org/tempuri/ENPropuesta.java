
package org.tempuri;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlSchemaType;
import javax.xml.bind.annotation.XmlType;
import javax.xml.datatype.XMLGregorianCalendar;


/**
 * <p>Java class for ENPropuesta complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ENPropuesta">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="Id" type="{http://www.w3.org/2001/XMLSchema}int"/>
 *         &lt;element name="Descripcion" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="FechaEntrega" type="{http://www.w3.org/2001/XMLSchema}dateTime"/>
 *         &lt;element name="Estado" type="{http://tempuri.org/}ENEstadosPieza"/>
 *         &lt;element name="Precio" type="{http://www.w3.org/2001/XMLSchema}float"/>
 *         &lt;element name="Foto" type="{http://www.w3.org/2001/XMLSchema}base64Binary" minOccurs="0"/>
 *         &lt;element name="Confirmada" type="{http://www.w3.org/2001/XMLSchema}boolean"/>
 *         &lt;element name="IdDesguace" type="{http://www.w3.org/2001/XMLSchema}int"/>
 *         &lt;element name="IdSolicitud" type="{http://www.w3.org/2001/XMLSchema}int"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ENPropuesta", propOrder = {
    "id",
    "descripcion",
    "fechaEntrega",
    "estado",
    "precio",
    "foto",
    "confirmada",
    "idDesguace",
    "idSolicitud"
})
public class ENPropuesta {

    @XmlElement(name = "Id")
    protected int id;
    @XmlElement(name = "Descripcion")
    protected String descripcion;
    @XmlElement(name = "FechaEntrega", required = true)
    @XmlSchemaType(name = "dateTime")
    protected XMLGregorianCalendar fechaEntrega;
    @XmlElement(name = "Estado", required = true)
    protected ENEstadosPieza estado;
    @XmlElement(name = "Precio")
    protected float precio;
    @XmlElement(name = "Foto")
    protected byte[] foto;
    @XmlElement(name = "Confirmada")
    protected boolean confirmada;
    @XmlElement(name = "IdDesguace")
    protected int idDesguace;
    @XmlElement(name = "IdSolicitud")
    protected int idSolicitud;

    /**
     * Gets the value of the id property.
     * 
     */
    public int getId() {
        return id;
    }

    /**
     * Sets the value of the id property.
     * 
     */
    public void setId(int value) {
        this.id = value;
    }

    /**
     * Gets the value of the descripcion property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getDescripcion() {
        return descripcion;
    }

    /**
     * Sets the value of the descripcion property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDescripcion(String value) {
        this.descripcion = value;
    }

    /**
     * Gets the value of the fechaEntrega property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public XMLGregorianCalendar getFechaEntrega() {
        return fechaEntrega;
    }

    /**
     * Sets the value of the fechaEntrega property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setFechaEntrega(XMLGregorianCalendar value) {
        this.fechaEntrega = value;
    }

    /**
     * Gets the value of the estado property.
     * 
     * @return
     *     possible object is
     *     {@link ENEstadosPieza }
     *     
     */
    public ENEstadosPieza getEstado() {
        return estado;
    }

    /**
     * Sets the value of the estado property.
     * 
     * @param value
     *     allowed object is
     *     {@link ENEstadosPieza }
     *     
     */
    public void setEstado(ENEstadosPieza value) {
        this.estado = value;
    }

    /**
     * Gets the value of the precio property.
     * 
     */
    public float getPrecio() {
        return precio;
    }

    /**
     * Sets the value of the precio property.
     * 
     */
    public void setPrecio(float value) {
        this.precio = value;
    }

    /**
     * Gets the value of the foto property.
     * 
     * @return
     *     possible object is
     *     byte[]
     */
    public byte[] getFoto() {
        return foto;
    }

    /**
     * Sets the value of the foto property.
     * 
     * @param value
     *     allowed object is
     *     byte[]
     */
    public void setFoto(byte[] value) {
        this.foto = ((byte[]) value);
    }

    /**
     * Gets the value of the confirmada property.
     * 
     */
    public boolean isConfirmada() {
        return confirmada;
    }

    /**
     * Sets the value of the confirmada property.
     * 
     */
    public void setConfirmada(boolean value) {
        this.confirmada = value;
    }

    /**
     * Gets the value of the idDesguace property.
     * 
     */
    public int getIdDesguace() {
        return idDesguace;
    }

    /**
     * Sets the value of the idDesguace property.
     * 
     */
    public void setIdDesguace(int value) {
        this.idDesguace = value;
    }

    /**
     * Gets the value of the idSolicitud property.
     * 
     */
    public int getIdSolicitud() {
        return idSolicitud;
    }

    /**
     * Sets the value of the idSolicitud property.
     * 
     */
    public void setIdSolicitud(int value) {
        this.idSolicitud = value;
    }

}
