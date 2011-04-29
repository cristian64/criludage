using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sitio_Web
{
    public partial class AltaCliente : System.Web.UI.Page
    {
        Global glob = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            Page.Validate("grupo1");


            if(Page.IsValid == true)
            {
                SGC.ENCliente cliente = new SGC.ENCliente();
                cliente.Usuario = TextBoxUsuario.Text;
                cliente.Contrasena = Biblioteca_Común.Sha1.ComputeHash(TextBoxPassword.Text);
                cliente.Nombre = TextBoxNombre.Text;
                cliente.Nif = TextBoxNif.Text;
                cliente.CorreoElectronico = TextBoxEmail.Text;
                cliente.Telefono = TextBoxTelefono.Text;
                cliente.Direccion = TextBoxDireccion.Text;
                cliente.InformacionAdicional = TextBoxInfo.Text;

                int id = -1;
                try
                {
                    id = glob.InterfazRemota.RegistroCliente(cliente);
                }
                catch (System.Net.WebException)
                {
                    string dir = glob.InterfazUDDI.PuntoAccesoServicio("Criludage");
                    glob.InterfazRemota.Url = dir;
                    Response.Write("<script language=javascript>alert('Ha habido un error al procesar la solicitud, vuelve a intentarlo');</script>");
                    return;
                }
                catch (Exception)
                {
                    Response.Write("<script language=javascript>alert('Ha habido un error al procesar la solicitud, vuelve a intentarlo');</script>");
                    return;
                }

                if (id > 0)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Error al dar de alta, revise los campos');</script>");
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('Error al dar de alta, revise los campos');</script>");
            }




        }
    }
}