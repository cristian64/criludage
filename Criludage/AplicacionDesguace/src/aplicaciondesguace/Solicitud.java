/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package aplicaciondesguace;

import java.io.StringReader;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.GregorianCalendar;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import org.tempuri.ENEstadosPieza;
import org.tempuri.ENSolicitud;
import org.w3c.dom.Document;
import org.xml.sax.InputSource;

/**
 *
 * @author DAMIAN-MACBOOK
 */
public class Solicitud extends ENSolicitud {

    private GregorianCalendar miFecha;
    private GregorianCalendar miFechaEntrega;
    private GregorianCalendar miFechaRespuesta;
    private String informacionAdicional;
    private int idEmpleado;
    private Connection conexion;

    public Solicitud() {

        setId(0);
        setIdCliente(0);
        setDescripcion("");
        setNegociadoAutomatico(false);
        setPrecioMax(0.0f);
        setEstado(ENEstadosPieza.USADA);
        setMiFecha(new GregorianCalendar());
        setMiFechaEntrega(new GregorianCalendar());
        setMiFechaRespuesta(new GregorianCalendar());
        idEmpleado = 0;
        informacionAdicional = "";

        miFechaEntrega.add(GregorianCalendar.DAY_OF_YEAR, 7);
        miFechaRespuesta.add(GregorianCalendar.MINUTE, 10);


    }
    
    public Solicitud(ResultSet rs){

        try{
            setId(rs.getInt("id"));
            setIdCliente(rs.getInt("idCliente"));
            setDescripcion(rs.getString("descripcion"));
            int negociado = rs.getInt("negociadoAutomatico");
            if(negociado == 0){
                setNegociadoAutomatico(false);
            }
            else{
                setNegociadoAutomatico(true);
            }
            setPrecioMax(rs.getFloat("precioMax"));
            if(rs.getString("estado").equals("USADA")){
                setEstado(ENEstadosPieza.USADA);
            }
            if(rs.getString("estado").equals("NO_FUNCIONA")){
                setEstado(ENEstadosPieza.NO_FUNCIONA);
            }
            if(rs.getString("estado").equals("NUEVA")){
                setEstado(ENEstadosPieza.NUEVA);
            }
            setMiFecha(getGregorianCalendar(rs.getString("fecha")," "));
            setMiFechaEntrega(getGregorianCalendar(rs.getString("fechaEntrega")," "));
            setMiFechaRespuesta(getGregorianCalendar(rs.getString("fechaRespuesta")," "));
            idEmpleado = rs.getInt("idEmpleado");
            informacionAdicional = rs.getString("informacionAdicional");

        }
        catch(SQLException e){

        }
    }

    public Solicitud(ENSolicitud s) {

        setId(s.getId());
        setIdCliente(s.getIdCliente());
        setDescripcion(s.getDescripcion());
        setNegociadoAutomatico(s.isNegociadoAutomatico());
        setPrecioMax(s.getPrecioMax());
        setEstado(s.getEstado());
        setMiFecha(s.getFecha().toGregorianCalendar());
        setMiFechaEntrega(s.getFechaEntrega().toGregorianCalendar());
        setMiFechaRespuesta(s.getFechaRespuesta().toGregorianCalendar());

        idEmpleado = 0;
        informacionAdicional = "";

    }

    public Solicitud(String xml) {

        //System.out.println(xml);

        try {
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            DocumentBuilder db = dbf.newDocumentBuilder();
            InputSource is = new InputSource();
            is.setCharacterStream(new StringReader(xml));

            Document doc = db.parse(is);

            if(doc != null){

                setId(new Integer(doc.getElementsByTagName("Id").item(0).getTextContent()));

                setIdCliente(new Integer(doc.getElementsByTagName("IdCliente").item(0).getTextContent()));

                setDescripcion(doc.getElementsByTagName("Descripcion").item(0).getTextContent());

                int neg = 1;
                if(doc.getElementsByTagName("NegociadoAutomatico").item(0).getTextContent().equals("false")){
                    neg = 0;
                }
                if(neg == 0){
                    setNegociadoAutomatico(false);
                }
                else{
                    setNegociadoAutomatico(true);
                }

                setPrecioMax(new Float(doc.getElementsByTagName("PrecioMax").item(0).getTextContent()));

                if(doc.getElementsByTagName("Estado").item(0).getTextContent().equals("USADA")){
                    setEstado(ENEstadosPieza.USADA);
                }
                if(doc.getElementsByTagName("Estado").item(0).getTextContent().equals("NO_FUNCIONA")){
                    setEstado(ENEstadosPieza.NO_FUNCIONA);
                }
                if(doc.getElementsByTagName("Estado").item(0).getTextContent().equals("NUEVA")){
                    setEstado(ENEstadosPieza.NUEVA);
                }

                miFecha = getGregorianCalendarFromXML(doc.getElementsByTagName("Fecha").item(0).getTextContent(),"T");

                miFechaEntrega = getGregorianCalendarFromXML(doc.getElementsByTagName("FechaEntrega").item(0).getTextContent(),"T");

                miFechaRespuesta = getGregorianCalendarFromXML(doc.getElementsByTagName("FechaRespuesta").item(0).getTextContent(),"T");

                idEmpleado = 0;
                informacionAdicional = getInformacionAdicional();

                //System.out.println("--- Fecha: " +  ImprimirFecha(miFecha));
                //System.out.println("--- Fecha de Respuesta: " +  ImprimirFecha(miFechaRespuesta));
                //System.out.println("--- Fecha de Entrega: " +  ImprimirFecha(miFechaEntrega));

            }

        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    private GregorianCalendar getGregorianCalendar(String s,String sep){

        //System.out.println(s);

        String fecha = s.split(sep)[0];
        String hora = s.split(sep)[1];

        int ano = new Integer(fecha.split("\\.")[2]);
        int mes = new Integer(fecha.split("\\.")[1]);
        int dia = new Integer(fecha.split("\\.")[0]);

        int hor = new Integer(hora.split(":")[0]);
        int min = new Integer(hora.split(":")[1]);
        int seg = new Integer(hora.split(":")[2]);

        //System.out.println(dia + "." + mes + "." + ano + " " + hor + ":" + min + ":" + seg);

        GregorianCalendar g = new GregorianCalendar(ano, mes, dia);
        g.set(GregorianCalendar.DAY_OF_MONTH, dia);
        g.set(GregorianCalendar.MONTH, mes-1);
        g.set(GregorianCalendar.YEAR,ano);
        g.set(GregorianCalendar.HOUR_OF_DAY, hor);
        g.set(GregorianCalendar.MINUTE, min);
        g.set(GregorianCalendar.SECOND, seg);



        //System.out.println(ImprimirFecha(g));

        return g;
    }

    private GregorianCalendar getGregorianCalendarFromXML(String s,String sep){

        //System.out.println(s);

        String fecha = s.split(sep)[0];
        String hora = s.split(sep)[1].split("\\.")[0].split("\\+")[0];

        int ano = new Integer(fecha.split("-")[0]);
        int mes = new Integer(fecha.split("-")[1]);
        int dia = new Integer(fecha.split("-")[2]);

        int hor = new Integer(hora.split(":")[0]);
        int min = new Integer(hora.split(":")[1]);
        int seg = new Integer(hora.split(":")[2]);

        //System.out.println(dia + "." + mes + "." + ano + " " + hor + ":" + min + ":" + seg);

        GregorianCalendar g = new GregorianCalendar(ano, mes, dia);
        g.set(GregorianCalendar.DAY_OF_MONTH, dia);
        g.set(GregorianCalendar.MONTH, mes-1);
        g.set(GregorianCalendar.YEAR,ano);
        g.set(GregorianCalendar.HOUR_OF_DAY, hor);
        g.set(GregorianCalendar.MINUTE, min);
        g.set(GregorianCalendar.SECOND, seg);



        //System.out.println(ImprimirFecha(g));

        return g;
    }

    public String toString(){

        String s="";

        s += "Id: " + getId() + "\n";
        s += "IdCliente: " + getIdCliente() + "\n";
        s += "Descripcion: " + getDescripcion() + "\n";
        s += "Negociado automatico: " + isNegociadoAutomatico() + "\n";
        s += "Precio maximo: " + getPrecioMax() + "\n";
        s += "Estado: " + getEstado().toString() + "\n";
        s += "Fecha: " + ImprimirFecha(getMiFecha()) + "\n";
        s += "Fecha Entrega: " + ImprimirFecha(getMiFechaEntrega()) + "\n";
        s += "Fecha Respuesta: " + ImprimirFecha(getMiFechaRespuesta()) + "\n";
        s += "Informacion adicional: " + getInformacionAdicional() + "\n";
        s += "IdEmpleado: " + getIdEmpleado() + "\n";

        return s;
    }
    /*
     * setMiFecha(getFecha().toGregorianCalendar());
    setMiFechaEntrega(getFechaEntrega().toGregorianCalendar());
    setMiFechaRespuesta(getFechaRespuesta().toGregorianCalendar());
     *
     */
    public String ImprimirFecha(GregorianCalendar f) {

        DecimalFormat format = new DecimalFormat("00");

        return format.format(f.get(GregorianCalendar.DAY_OF_MONTH)) + "." +
                format.format(f.get(GregorianCalendar.MONTH)+1) + "." +
                format.format(f.get(GregorianCalendar.YEAR)) + " " +
                format.format(f.get(GregorianCalendar.HOUR_OF_DAY)) + ":" +
                format.format(f.get(GregorianCalendar.MINUTE)) + ":" +
                format.format(f.get(GregorianCalendar.SECOND));
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

    public GregorianCalendar getMiFecha() {
        return miFecha;
    }

    public void setMiFecha(GregorianCalendar miFecha) {
        this.miFecha = miFecha;
    }

    public GregorianCalendar getMiFechaEntrega() {
        return miFechaEntrega;
    }

    public void setMiFechaEntrega(GregorianCalendar miFechaEntrega) {
        this.miFechaEntrega = miFechaEntrega;
    }

    public GregorianCalendar getMiFechaRespuesta() {
        return miFechaRespuesta;
    }

    public void setMiFechaRespuesta(GregorianCalendar miFechaRespuesta) {
        this.miFechaRespuesta = miFechaRespuesta;
    }

    public ArrayList<Solicitud> obtenerTodas(String con){

        crearConexion(con);
        
        ArrayList<Solicitud> solicitudes = new ArrayList<Solicitud>();

        GregorianCalendar g = new GregorianCalendar();
        String fecha = g.get(GregorianCalendar.YEAR) + "." + g.get(GregorianCalendar.MONTH) + "." + g.get(GregorianCalendar.DAY_OF_MONTH);
        String hora = g.get(GregorianCalendar.HOUR_OF_DAY) + ":" + g.get(GregorianCalendar.MINUTE) + ":" + g.get(GregorianCalendar.SECOND);
        
        try{
            ResultSet rs = consultaSQL("select * from solicitudes order by id desc");

            while(rs.next()){
                solicitudes.add(new Solicitud(rs));
            }
        }
        catch(SQLException e){
            
        }
        return solicitudes;
    }
    
    public boolean guardar(String con){

        crearConexion(con);
        int negociado = 0;
        if(isNegociadoAutomatico()){
            negociado=1;
        }
        return ejecutarSQL("INSERT INTO solicitudes (id,idCliente,descripcion,fecha,fechaEntrega,fechaRespuesta,precioMax,negociadoAutomatico,estado,informacionAdicional,idEmpleado)VALUES  ("+ getId() + "," + getIdCliente() + ",'" + getDescripcion() + "','" + ImprimirFecha(getMiFecha()) + "','" + ImprimirFecha(getMiFechaEntrega()) + "','" + ImprimirFecha(getMiFechaRespuesta()) + "'," + getPrecioMax() + "," + negociado + ",'" + getEstado().toString() + "','" + getInformacionAdicional() + "'," + getIdEmpleado() + ")");

    }



    public boolean crearConexion(String con) {
        try {
            Class.forName("org.sqlite.JDBC");
            conexion = DriverManager.getConnection(con);
            //Class.forName("com.mysql.jdbc.Driver");
            //conexion = DriverManager.getConnection("jdbc:mysql://localhost:3306/desguace", "root", "");
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
