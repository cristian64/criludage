
package org.tempuri;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
import javax.jws.WebService;
import javax.xml.bind.annotation.XmlSeeAlso;
import javax.xml.ws.RequestWrapper;
import javax.xml.ws.ResponseWrapper;


/**
 * This class was generated by the JAX-WS RI.
 * JAX-WS RI 2.2-hudson-752-
 * Generated source version: 2.2
 * 
 */
@WebService(name = "InterfazRemotaSoap", targetNamespace = "http://tempuri.org/")
@XmlSeeAlso({
    ObjectFactory.class
})
public interface InterfazRemotaSoap {


    /**
     * 
     */
    @WebMethod(operationName = "Inicializar", action = "http://tempuri.org/Inicializar")
    @RequestWrapper(localName = "Inicializar", targetNamespace = "http://tempuri.org/", className = "org.tempuri.Inicializar")
    @ResponseWrapper(localName = "InicializarResponse", targetNamespace = "http://tempuri.org/", className = "org.tempuri.InicializarResponse")
    public void inicializar();

    /**
     * 
     * @param usuario
     * @param contrasena
     * @param solicitud
     * @return
     *     returns int
     */
    @WebMethod(operationName = "SolicitarPieza", action = "http://tempuri.org/SolicitarPieza")
    @WebResult(name = "SolicitarPiezaResult", targetNamespace = "http://tempuri.org/")
    @RequestWrapper(localName = "SolicitarPieza", targetNamespace = "http://tempuri.org/", className = "org.tempuri.SolicitarPieza")
    @ResponseWrapper(localName = "SolicitarPiezaResponse", targetNamespace = "http://tempuri.org/", className = "org.tempuri.SolicitarPiezaResponse")
    public int solicitarPieza(
        @WebParam(name = "solicitud", targetNamespace = "http://tempuri.org/")
        ENSolicitud solicitud,
        @WebParam(name = "usuario", targetNamespace = "http://tempuri.org/")
        String usuario,
        @WebParam(name = "contrasena", targetNamespace = "http://tempuri.org/")
        String contrasena);

    /**
     * 
     * @param usuario
     * @param propuesta
     * @param contrasena
     * @return
     *     returns int
     */
    @WebMethod(operationName = "ProponerPieza", action = "http://tempuri.org/ProponerPieza")
    @WebResult(name = "ProponerPiezaResult", targetNamespace = "http://tempuri.org/")
    @RequestWrapper(localName = "ProponerPieza", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ProponerPieza")
    @ResponseWrapper(localName = "ProponerPiezaResponse", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ProponerPiezaResponse")
    public int proponerPieza(
        @WebParam(name = "propuesta", targetNamespace = "http://tempuri.org/")
        ENPropuesta propuesta,
        @WebParam(name = "usuario", targetNamespace = "http://tempuri.org/")
        String usuario,
        @WebParam(name = "contrasena", targetNamespace = "http://tempuri.org/")
        String contrasena);

    /**
     * 
     * @param id
     * @param usuario
     * @param contrasena
     * @return
     *     returns org.tempuri.ENCliente
     */
    @WebMethod(operationName = "ObtenerCliente", action = "http://tempuri.org/ObtenerCliente")
    @WebResult(name = "ObtenerClienteResult", targetNamespace = "http://tempuri.org/")
    @RequestWrapper(localName = "ObtenerCliente", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ObtenerCliente")
    @ResponseWrapper(localName = "ObtenerClienteResponse", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ObtenerClienteResponse")
    public ENCliente obtenerCliente(
        @WebParam(name = "id", targetNamespace = "http://tempuri.org/")
        int id,
        @WebParam(name = "usuario", targetNamespace = "http://tempuri.org/")
        String usuario,
        @WebParam(name = "contrasena", targetNamespace = "http://tempuri.org/")
        String contrasena);

    /**
     * 
     * @param usuario
     * @param cliente
     * @param contrasena
     * @return
     *     returns org.tempuri.ENCliente
     */
    @WebMethod(operationName = "ObtenerClientePorUsuario", action = "http://tempuri.org/ObtenerClientePorUsuario")
    @WebResult(name = "ObtenerClientePorUsuarioResult", targetNamespace = "http://tempuri.org/")
    @RequestWrapper(localName = "ObtenerClientePorUsuario", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ObtenerClientePorUsuario")
    @ResponseWrapper(localName = "ObtenerClientePorUsuarioResponse", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ObtenerClientePorUsuarioResponse")
    public ENCliente obtenerClientePorUsuario(
        @WebParam(name = "cliente", targetNamespace = "http://tempuri.org/")
        String cliente,
        @WebParam(name = "usuario", targetNamespace = "http://tempuri.org/")
        String usuario,
        @WebParam(name = "contrasena", targetNamespace = "http://tempuri.org/")
        String contrasena);

    /**
     * 
     * @param id
     * @param usuario
     * @param contrasena
     * @return
     *     returns org.tempuri.ENDesguace
     */
    @WebMethod(operationName = "ObtenerDesguace", action = "http://tempuri.org/ObtenerDesguace")
    @WebResult(name = "ObtenerDesguaceResult", targetNamespace = "http://tempuri.org/")
    @RequestWrapper(localName = "ObtenerDesguace", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ObtenerDesguace")
    @ResponseWrapper(localName = "ObtenerDesguaceResponse", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ObtenerDesguaceResponse")
    public ENDesguace obtenerDesguace(
        @WebParam(name = "id", targetNamespace = "http://tempuri.org/")
        int id,
        @WebParam(name = "usuario", targetNamespace = "http://tempuri.org/")
        String usuario,
        @WebParam(name = "contrasena", targetNamespace = "http://tempuri.org/")
        String contrasena);

    /**
     * 
     * @param usuario
     * @param contrasena
     * @param desguace
     * @return
     *     returns org.tempuri.ENDesguace
     */
    @WebMethod(operationName = "ObtenerDesguacePorUsuario", action = "http://tempuri.org/ObtenerDesguacePorUsuario")
    @WebResult(name = "ObtenerDesguacePorUsuarioResult", targetNamespace = "http://tempuri.org/")
    @RequestWrapper(localName = "ObtenerDesguacePorUsuario", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ObtenerDesguacePorUsuario")
    @ResponseWrapper(localName = "ObtenerDesguacePorUsuarioResponse", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ObtenerDesguacePorUsuarioResponse")
    public ENDesguace obtenerDesguacePorUsuario(
        @WebParam(name = "desguace", targetNamespace = "http://tempuri.org/")
        String desguace,
        @WebParam(name = "usuario", targetNamespace = "http://tempuri.org/")
        String usuario,
        @WebParam(name = "contrasena", targetNamespace = "http://tempuri.org/")
        String contrasena);

    /**
     * 
     * @param usuario
     * @param cliente
     * @param contrasena
     * @return
     *     returns boolean
     */
    @WebMethod(operationName = "ActualizarCliente", action = "http://tempuri.org/ActualizarCliente")
    @WebResult(name = "ActualizarClienteResult", targetNamespace = "http://tempuri.org/")
    @RequestWrapper(localName = "ActualizarCliente", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ActualizarCliente")
    @ResponseWrapper(localName = "ActualizarClienteResponse", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ActualizarClienteResponse")
    public boolean actualizarCliente(
        @WebParam(name = "cliente", targetNamespace = "http://tempuri.org/")
        ENCliente cliente,
        @WebParam(name = "usuario", targetNamespace = "http://tempuri.org/")
        String usuario,
        @WebParam(name = "contrasena", targetNamespace = "http://tempuri.org/")
        String contrasena);

    /**
     * 
     * @param usuario
     * @param contrasena
     * @param desguace
     * @return
     *     returns boolean
     */
    @WebMethod(operationName = "ActualizarDesguace", action = "http://tempuri.org/ActualizarDesguace")
    @WebResult(name = "ActualizarDesguaceResult", targetNamespace = "http://tempuri.org/")
    @RequestWrapper(localName = "ActualizarDesguace", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ActualizarDesguace")
    @ResponseWrapper(localName = "ActualizarDesguaceResponse", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ActualizarDesguaceResponse")
    public boolean actualizarDesguace(
        @WebParam(name = "desguace", targetNamespace = "http://tempuri.org/")
        ENDesguace desguace,
        @WebParam(name = "usuario", targetNamespace = "http://tempuri.org/")
        String usuario,
        @WebParam(name = "contrasena", targetNamespace = "http://tempuri.org/")
        String contrasena);

    /**
     * 
     * @param cliente
     * @return
     *     returns int
     */
    @WebMethod(operationName = "RegistroCliente", action = "http://tempuri.org/RegistroCliente")
    @WebResult(name = "RegistroClienteResult", targetNamespace = "http://tempuri.org/")
    @RequestWrapper(localName = "RegistroCliente", targetNamespace = "http://tempuri.org/", className = "org.tempuri.RegistroCliente")
    @ResponseWrapper(localName = "RegistroClienteResponse", targetNamespace = "http://tempuri.org/", className = "org.tempuri.RegistroClienteResponse")
    public int registroCliente(
        @WebParam(name = "cliente", targetNamespace = "http://tempuri.org/")
        ENCliente cliente);

    /**
     * 
     * @param desguace
     * @return
     *     returns int
     */
    @WebMethod(operationName = "RegistroDesguace", action = "http://tempuri.org/RegistroDesguace")
    @WebResult(name = "RegistroDesguaceResult", targetNamespace = "http://tempuri.org/")
    @RequestWrapper(localName = "RegistroDesguace", targetNamespace = "http://tempuri.org/", className = "org.tempuri.RegistroDesguace")
    @ResponseWrapper(localName = "RegistroDesguaceResponse", targetNamespace = "http://tempuri.org/", className = "org.tempuri.RegistroDesguaceResponse")
    public int registroDesguace(
        @WebParam(name = "desguace", targetNamespace = "http://tempuri.org/")
        ENDesguace desguace);

    /**
     * 
     * @param usuario
     * @param contrasena
     * @param solicitud
     * @return
     *     returns org.tempuri.ArrayOfAnyType
     */
    @WebMethod(operationName = "ObtenerPropuestas", action = "http://tempuri.org/ObtenerPropuestas")
    @WebResult(name = "ObtenerPropuestasResult", targetNamespace = "http://tempuri.org/")
    @RequestWrapper(localName = "ObtenerPropuestas", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ObtenerPropuestas")
    @ResponseWrapper(localName = "ObtenerPropuestasResponse", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ObtenerPropuestasResponse")
    public ArrayOfAnyType obtenerPropuestas(
        @WebParam(name = "solicitud", targetNamespace = "http://tempuri.org/")
        ENSolicitud solicitud,
        @WebParam(name = "usuario", targetNamespace = "http://tempuri.org/")
        String usuario,
        @WebParam(name = "contrasena", targetNamespace = "http://tempuri.org/")
        String contrasena);

    /**
     * 
     * @param usuario
     * @param contrasena
     * @return
     *     returns org.tempuri.ArrayOfAnyType
     */
    @WebMethod(operationName = "ObtenerFinalizadasNoSincronizadas", action = "http://tempuri.org/ObtenerFinalizadasNoSincronizadas")
    @WebResult(name = "ObtenerFinalizadasNoSincronizadasResult", targetNamespace = "http://tempuri.org/")
    @RequestWrapper(localName = "ObtenerFinalizadasNoSincronizadas", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ObtenerFinalizadasNoSincronizadas")
    @ResponseWrapper(localName = "ObtenerFinalizadasNoSincronizadasResponse", targetNamespace = "http://tempuri.org/", className = "org.tempuri.ObtenerFinalizadasNoSincronizadasResponse")
    public ArrayOfAnyType obtenerFinalizadasNoSincronizadas(
        @WebParam(name = "usuario", targetNamespace = "http://tempuri.org/")
        String usuario,
        @WebParam(name = "contrasena", targetNamespace = "http://tempuri.org/")
        String contrasena);

}