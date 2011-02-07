/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package aplicaciondesguace;

import java.io.FileOutputStream;
import java.io.IOException;
import org.jdom.Document;
import org.jdom.Element;
import org.jdom.JDOMException;
import org.jdom.input.SAXBuilder;
import org.jdom.output.Format;
import org.jdom.output.XMLOutputter;

/**
 *
 * @author DAMIAN-MACBOOK
 */
public class Configuracion {

    private String ActiveMQ;
    private String WebService;
    private String bdHost;
    private String bdUser;
    private String bdPassword;
    private int idDesguace;
    private String usuarioDesguace;
    private String passwordDesguace;

    public Configuracion(){

        ActiveMQ="tcp://localhost:61616";
        WebService="http://localhost:1132/InterfazRemota.asmx";
        bdHost="localhost:3306/desguace";
        bdUser="root";
        bdPassword="";
        idDesguace=0;
        usuarioDesguace="";
        passwordDesguace="";

    }

    public String getActiveMQ() {
        return ActiveMQ;
    }

    public void setActiveMQ(String ActiveMQ) {
        this.ActiveMQ = ActiveMQ;
    }

    public String getWebService() {
        return WebService;
    }

    public void setWebService(String WebService) {
        this.WebService = WebService;
    }

    public String getBdHost() {
        return bdHost;
    }

    public void setBdHost(String bdHost) {
        this.bdHost = bdHost;
    }

    public String getBdPassword() {
        return bdPassword;
    }

    public void setBdPassword(String bdPassword) {
        this.bdPassword = bdPassword;
    }

    public String getBdUser() {
        return bdUser;
    }

    public void setBdUser(String bdUser) {
        this.bdUser = bdUser;
    }

    public int getIdDesguace() {
        return idDesguace;
    }

    public void setIdDesguace(int idDesguace) {
        this.idDesguace = idDesguace;
    }

    public String getPasswordDesguace() {
        return passwordDesguace;
    }

    public void setPasswordDesguace(String passwordDesguace) {
        this.passwordDesguace = passwordDesguace;
    }

    public String getUsuarioDesguace() {
        return usuarioDesguace;
    }

    public void setUsuarioDesguace(String usuarioDesguace) {
        this.usuarioDesguace = usuarioDesguace;
    }

    public boolean leerConfiguracion(String fichero){

        try{

            SAXBuilder builder=new SAXBuilder(false);
            Document doc=builder.build(fichero);
            Element raiz=doc.getRootElement();

            ActiveMQ = raiz.getChild("ActiveMQ").getValue();
            WebService = raiz.getChild("WebService").getValue();
            bdHost = raiz.getChild("bdHost").getValue();
            bdUser = raiz.getChild("bdUser").getValue();
            bdPassword = raiz.getChild("bdPassword").getValue();
            usuarioDesguace = raiz.getChild("usuarioDesguace").getValue();
            passwordDesguace = raiz.getChild("passwordDesguace").getValue();
            if(!raiz.getChild("idDesguace").getValue().equals(""))idDesguace = new Integer(raiz.getChild("idDesguace").getValue());

            return true;
        }
        catch(IOException e1){
            return false;
        }
        catch(JDOMException e2){
            return false;
        }
    }

    public void guardarConfiguracion(String fichero){

        Document doc = new Document(new Element("configuracion"));
        Element e = null;
        Element raiz = doc.getRootElement();

        e = new Element("ActiveMQ");
        e.setText(ActiveMQ);
        raiz.addContent(e);

        e = new Element("WebService");
        e.setText(WebService);
        raiz.addContent(e);

        e = new Element("bdHost");
        e.setText(bdHost);
        raiz.addContent(e);

        e = new Element("bdUser");
        e.setText(bdUser);
        raiz.addContent(e);

        e = new Element("bdPassword");
        e.setText(bdPassword);
        raiz.addContent(e);

        e = new Element("idDesguace");
        e.setText("" + idDesguace);
        raiz.addContent(e);

        e = new Element("usuarioDesguace");
        e.setText(usuarioDesguace);
        raiz.addContent(e);

        e = new Element("passwordDesguace");
        e.setText(passwordDesguace);
        raiz.addContent(e);

        try{
          XMLOutputter out=new XMLOutputter(Format.getPrettyFormat());
          FileOutputStream file=new FileOutputStream(fichero);
          out.output(doc,file);
          file.flush();
          file.close();
          //out.output(doc,System.out);
        }
        catch(Exception ex){
            ex.printStackTrace();
        }



    }

}
