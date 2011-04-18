/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package aplicaciondesguace;

import java.sql.Statement;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 *
 * @author DAMIAN-MACBOOK
 */
public class Empleado {

    private int id;
    private String usuario;
    private String contrasena;
    private String nombre;
    private String nif;
    private String correoElectronico;
    private boolean administrador;
    private java.sql.Connection conexion;

    public Empleado() {

        id = -1;
        usuario = "";
        contrasena = "";
        nombre = "";
        correoElectronico = "";
        nif = "";
        administrador = false;

    }

    public Empleado(ResultSet rs) {

        try {
            id = rs.getInt("id");
            usuario = rs.getString("usuario");
            contrasena = rs.getString("contrasena");
            nombre = rs.getString("nombre");
            correoElectronico = rs.getString("correoElectronico");
            nif = rs.getString("nif");

            if (rs.getInt("administrador") == 0) {
                administrador = false;
            } else {
                administrador = true;
            }

        } catch (SQLException e) {
        }

    }

    public boolean isAdministrador() {
        return administrador;
    }

    public String getContrasena() {
        return contrasena;
    }

    public String getCorreoElectronico() {
        return correoElectronico;
    }

    public int getId() {
        return id;
    }

    public String getNif() {
        return nif;
    }

    public String getNombre() {
        return nombre;
    }

    public String getUsuario() {
        return usuario;
    }

    public void setAdministrador(boolean administrador) {
        this.administrador = administrador;
    }

    public void setContrasena(String contrasena) {
        this.contrasena = contrasena;
    }

    public void setCorreoElectronico(String correoElectronico) {
        this.correoElectronico = correoElectronico;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setNif(String nif) {
        this.nif = nif;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public void setUsuario(String usuario) {
        this.usuario = usuario;
    }

    public boolean guardar(String con) {

        crearConexion(con);
        int admin = 0;
        if (isAdministrador()) {
            admin = 1;
        }
        return ejecutarSQL("insert into empleados (id,usuario, contrasena, nombre,nif,correoElectronico, administrador) values (null,'" + usuario + "', '" + contrasena + "', '" + nombre + "', '" + nif + "', '" + correoElectronico + "', " + admin + ");");
    }

    public boolean borrar(String con) {

        crearConexion(con);

        return ejecutarSQL("delete from empleados where id=" + getId());
    }

    public Empleado getEmpleadoPorUsuario(String con, String s) {

        Empleado e = null;
        crearConexion(con);
        ResultSet rs = consultaSQL("select * from empleados where usuario='" + s + "'");
        try {
            while (rs.next()) {
                e = new Empleado(rs);
            }
        } catch (SQLException ex) {
        }
        return e;
    }

    public ArrayList<Empleado> obtenerTodos(String con) {

        ArrayList<Empleado> e = new ArrayList<Empleado>();
        crearConexion(con);
        ResultSet rs = consultaSQL("select * from empleados");
        try {
            while (rs.next()) {
                e.add(new Empleado(rs));
            }
        } catch (SQLException ex) {
        }
        return e;
    }

    public int numEmpleados(String con) {

        int n = 0;
        crearConexion(con);
        ResultSet rs = consultaSQL("select * from empleados");
        try {
            while (rs.next()) {
                n++;
            }
        } catch (SQLException e) {
        }

        return n;
    }

    public void guardarDatosEmpleado(String con) {

        crearConexion(con);
        int admin = 0;
        if (isAdministrador()) {
            admin = 1;
        }
        ejecutarSQL("update empleados set nombre='" + getNombre() + "', nif='" + getNif() + "', correoElectronico='" + getCorreoElectronico() + "', administrador=" + admin + " where usuario='" + getUsuario() + "';");


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

    public ResultSet consultaSQL(String sql) {

        try {
            Statement s = conexion.createStatement();
            return s.executeQuery(sql);
        } catch (SQLException ex) {
            ex.printStackTrace();
        }
        return null;
    }
}
