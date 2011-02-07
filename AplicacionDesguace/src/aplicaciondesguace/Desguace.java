/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package aplicaciondesguace;

import org.tempuri.ENDesguace;

/**
 *
 * @author DAMIAN-MACBOOK
 */
public class Desguace extends ENDesguace{

    public Desguace()
    {
        setId(0);
        setUsuario("");
        setContrasena("");
        setNombre("");
        setCorreoElectronico("");
        setDireccion("");
        setNif("");
        setInformacionAdicional("");
        setTelefono("");

    }

    public Desguace(ENDesguace d){

        setId(d.getId());
        setUsuario(d.getUsuario());
        setContrasena(d.getContrasena());
        setNombre(d.getNombre());
        setCorreoElectronico(d.getCorreoElectronico());
        setDireccion(d.getDireccion());
        setNif(d.getNif());
        setInformacionAdicional(d.getInformacionAdicional());
        setTelefono(d.getTelefono());

    }

    public ENDesguace getENDesguace(){

        ENDesguace d = new ENDesguace();

        d.setId(getId());
        d.setUsuario(getUsuario());
        d.setContrasena(getContrasena());
        d.setNombre(getNombre());
        d.setCorreoElectronico(getCorreoElectronico());
        d.setDireccion(getDireccion());
        d.setNif(getNif());
        d.setInformacionAdicional(getInformacionAdicional());
        d.setTelefono(getTelefono());

        return d;
    }



}
