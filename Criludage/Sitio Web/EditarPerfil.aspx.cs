using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sitio_Web
{
    public partial class EditarPerfil : System.Web.UI.Page
    {
        Global glob = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SesionIniciada"] == null || (bool)Session["SesionIniciada"] == false)
                Response.Redirect("Default.aspx");

            SGC.ENCliente cliente = glob.InterfazRemota.ObtenerCliente(int.Parse((string)Session["Id"]), (string)Session["User"], (string)Session["Pass"]);
            TextBoxUsuario.Text = cliente.Usuario;
            TextBoxNombre.Text = cliente.Nombre;
            TextBoxNif.Text = cliente.Nif;
            TextBoxEmail.Text = cliente.CorreoElectronico;
            TextBoxTelefono.Text = cliente.Telefono;
            TextBoxDireccion.Text = cliente.Direccion;
        }
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            Page.Validate("grupo1");

            if (Page.IsValid == true)
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

                if(glob.InterfazRemota.ActualizarCliente(cliente, (string)Session["User"], (string)Session["Pass"]))
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Error al editar el perfil, revise los campos');</script>");
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('Error al editar el perfil, revise los campos');</script>");
            }
        }

    }
}