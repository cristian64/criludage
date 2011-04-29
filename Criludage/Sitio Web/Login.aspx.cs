using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sitio_Web
{
    public partial class Login : System.Web.UI.Page
    {
        Global glob = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            bool valido = true;

            /*Hacer validacion*/

            if (valido)
            {
                SGC.ENCliente cliente = null;
                
                try
                {
                    cliente = glob.InterfazRemota.ObtenerClientePorUsuario(TextBoxUsuario.Text, TextBoxUsuario.Text, Biblioteca_Común.Sha1.ComputeHash(TextBoxPassword.Text));
                }
                catch (Exception)
                {
                    Response.Write("<script language=javascript>alert('Ha habido un error al procesar la solicitud, vuelve a intentarlo');</script>");
                    return;
                }
                
                if (cliente != null)
                {
                    Session["Id"] = cliente.Id.ToString();
                    Session["User"] = cliente.Usuario;
                    Session["Pass"] = cliente.Contrasena;   //Poco seguro aunque se guarda el hash
                    Session["SesionIniciada"] = true;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Error al acceder, revise los campos');</script>");
                }
            }
        }

    }
}