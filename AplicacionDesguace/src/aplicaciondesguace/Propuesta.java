/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package aplicaciondesguace;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.GregorianCalendar;
import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;
import javax.xml.datatype.XMLGregorianCalendar;
import org.tempuri.ENEstadosPieza;
import org.tempuri.ENPropuesta;

/**
 *
 * @author DAMIAN-MACBOOK
 */
public class Propuesta extends ENPropuesta{

    private GregorianCalendar miFechaEntrega;
    private int idSolicitud;
    private int idEmpleado;
    private int idDesguace;
    private String informacionAdicional;
    private Connection conexion=null;


    public Propuesta(){

        setId(0);
        setDescripcion("");
        setPrecio(0.0f);
        setEstado(ENEstadosPieza.USADA);
        setMiFechaEntrega(new GregorianCalendar());
        setIdDesguace(0);
        setIdSolicitud(0);

        informacionAdicional = "";
        idEmpleado = 0;

        miFechaEntrega.add(GregorianCalendar.DAY_OF_YEAR, 7);

    }

    public Propuesta(ResultSet rs){


        try{
            setId(rs.getInt("id"));
            setDescripcion(rs.getString("descripcion"));
            setPrecio(rs.getFloat("precioMax"));
            if(rs.getString("estado").equals("USADA")){
                setEstado(ENEstadosPieza.USADA);
            }
            if(rs.getString("estado").equals("NO_FUNCIONA")){
                setEstado(ENEstadosPieza.NO_FUNCIONA);
            }
            if(rs.getString("estado").equals("NUEVA")){
                setEstado(ENEstadosPieza.NUEVA);
            }
            setMiFechaEntrega(getGregorianCalendar(rs.getString("fechaEntrega") + " " + rs.getString("horaEntrega")," "));
            informacionAdicional = rs.getString("informacionAdicional");

        }
        catch(SQLException e){
            System.err.println(e);
        }
    }

     private GregorianCalendar getGregorianCalendar(String s,String sep){

        String fecha = s.split(sep)[0];
        String hora = s.split(sep)[1].split("\\.")[0];

        int ano = new Integer(fecha.split("-")[0]);
        int mes = new Integer(fecha.split("-")[1]);
        int dia = new Integer(fecha.split("-")[2]);

        int hor = new Integer(hora.split(":")[0]);
        int min = new Integer(hora.split(":")[1]);
        int seg = new Integer(hora.split(":")[2]);

        //System.out.println(dia + "." + mes + "." + ano + " " + hor + ":" + min + ":" + seg);

        GregorianCalendar g = new GregorianCalendar(ano, mes, dia);
        g.set(GregorianCalendar.DAY_OF_MONTH, dia);
        g.set(GregorianCalendar.MONTH, mes);
        g.set(GregorianCalendar.YEAR,ano);
        if(hor>12){
            g.set(GregorianCalendar.PM,1);
        }
        g.set(GregorianCalendar.HOUR_OF_DAY, hor);
        g.set(GregorianCalendar.MINUTE, min);
        g.set(GregorianCalendar.SECOND, seg);



        //System.out.println(ImprimirFecha(g));

        return g;
    }

    public ENPropuesta getENPropuesta(){

        ENPropuesta p = new ENPropuesta();

        p.setId(getId());
        p.setDescripcion(getDescripcion());
        p.setPrecio(getPrecio());
        p.setEstado(getEstado());
        p.setFechaEntrega(GCToXMLGC(miFechaEntrega));
        p.setIdDesguace(getIdDesguace());
        p.setIdSolicitud(getIdSolicitud());

        return p;
    }

    public XMLGregorianCalendar GCToXMLGC(GregorianCalendar g) {

        XMLGregorianCalendar f=null;
        try {

            f = DatatypeFactory.newInstance().newXMLGregorianCalendar(getMiFechaEntrega());

        } catch (DatatypeConfigurationException e) {

        }
        return f;
    }

    public GregorianCalendar getMiFechaEntrega() {
        return miFechaEntrega;
    }

    public void setMiFechaEntrega(GregorianCalendar f) {
        this.miFechaEntrega = f;
    }

    public int getIdEmpleado() {
        return idEmpleado;
    }

    public void setIdEmpleado(int idEmpleado) {
        this.idEmpleado = idEmpleado;
    }

    public String getInformacionAdicional() {
        return informacionAdicional;
    }

    public void setInformacionAdicional(String informacionAdicional) {
        this.informacionAdicional = informacionAdicional;
    }

    public String ImprimirFecha(GregorianCalendar f) {

        return f.get(GregorianCalendar.YEAR) + "." +
                f.get(GregorianCalendar.MONTH) + "." +
                f.get(GregorianCalendar.DAY_OF_MONTH) + " " +
                f.get(GregorianCalendar.HOUR_OF_DAY) + ":" +
                f.get(GregorianCalendar.MINUTE) + ":" +
                f.get(GregorianCalendar.SECOND);
    }

    public boolean guardar(){

        crearConexion();
        return ejecutarSQL("INSERT INTO propuestas (id, idSolicitud,idDesguace,descripcion,fechaEntrega,horaEntrega,precioMax,estado,informacionAdicional) VALUES  (" + getId() + "," + getIdSolicitud() + "," + getIdDesguace() + ",'" + getDescripcion() + "','" + ImprimirFecha(getMiFechaEntrega()).split(" ")[0] + "','" + ImprimirFecha(getMiFechaEntrega()).split(" ")[1] + "'," + getPrecio() + ",'" + getEstado().toString() + "','" + getInformacionAdicional() + "');");
    }


    public ArrayList<Propuesta> obtenerPropuestasPorSolicitud(int sol){

        crearConexion();

        ArrayList<Propuesta> propuestas = new ArrayList<Propuesta>();

        try{
            ResultSet rs = consultaSQL("select * from propuestas where idSolicitud=" + sol);

            while(rs.next()){
                propuestas.add(new Propuesta(rs));
            }
        }
        catch(SQLException e){

        }

        return propuestas;
    }

    public boolean crearConexion() {
        try {
            Class.forName("com.mysql.jdbc.Driver");
            conexion = DriverManager.getConnection("jdbc:mysql://localhost:3306/desguace", "root", "");
        } catch (SQLException ex) {
            ex.printStackTrace();
            return false;
        } catch (ClassNotFoundException ex) {
            ex.printStackTrace();
            return false;
        }

        return true;
    }

    public boolean ejecutarSQL(String sql) {
        try {
            Statement sentencia = conexion.createStatement();
            sentencia.executeUpdate(sql);
        } catch (SQLException ex) {
            ex.printStackTrace();
            return false;
        }

        return true;
    }

    public ResultSet consultaSQL(String sql){

        try {
            Statement s = conexion.createStatement();
            return  s.executeQuery (sql);
        } catch (SQLException ex) {
            ex.printStackTrace();
        }
        return null;
    }


}
