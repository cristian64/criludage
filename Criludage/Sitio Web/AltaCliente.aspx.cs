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
            bool valido = true;

            /*Falta validacion*/

            if (!(TextBoxUsuario.Text != "" && TextBoxPassword.Text != ""
                && TextBoxNombre.Text != "" && TextBoxNif.Text != ""
                && TextBoxEmail.Text != "" && TextBoxTelefono.Text != ""
                && TextBoxDireccion.Text != "" && TextBoxPassword.Text == TextBoxPasswordConfirmar.Text))
                valido = false;


            if(valido == true)
            {
                SGC.ENCliente cliente = new SGC.ENCliente();
                cliente.Usuario = TextBoxUsuario.Text;
                cliente.Contrasena = TextBoxPassword.Text;
                cliente.Nombre = TextBoxNombre.Text;
                cliente.Nif = TextBoxNif.Text;
                cliente.CorreoElectronico = TextBoxEmail.Text;
                cliente.Telefono = TextBoxTelefono.Text;
                cliente.Direccion = TextBoxDireccion.Text;
                cliente.InformacionAdicional = TextBoxInfo.Text;

                int id = glob.InterfazRemota.RegistroCliente(cliente);

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