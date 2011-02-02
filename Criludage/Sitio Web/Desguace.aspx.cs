using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sitio_Web
{
    public partial class Desguace : System.Web.UI.Page
    {
        Global glob = new Global();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SesionIniciada"] == null || (bool)Session["SesionIniciada"] == false)
                Response.Redirect("Default.aspx");

            if (Context.Request.QueryString.Count > 0 && Context.Request.QueryString["id"].Length > 0)
            {
                int id = int.Parse(Context.Request.QueryString["id"]);

                SGC.ENDesguace desguace = glob.InterfazRemota.ObtenerDesguace(id, (string)Session["User"], (string)Session["Pass"]);

                if(desguace != null)
                {
                    TextBoxNombre.Text = desguace.Nombre;
                    TextBoxNif.Text = desguace.Nif;
                    TextBoxDireccion.Text = desguace.Direccion;
                    TextBoxCorreoElectronico.Text = desguace.CorreoElectronico;
                    TextBoxTelefono.Text = desguace.Telefono;
                    TextBoxInfo.Text = desguace.InformacionAdicional;

                }
            }

        }
    }
}