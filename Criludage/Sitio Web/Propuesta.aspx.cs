using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sitio_Web
{
    public partial class Propuesta : System.Web.UI.Page
    {
        Global glob = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0 && Request.QueryString["id"].Length > 0)
            {
                int idPropuesta = int.Parse(Request.QueryString["id"]);

                SGC.ENPropuesta propuesta = (SGC.ENPropuesta)glob.InterfazRemota.ObtenerPropuestaPorId(idPropuesta, (string)Session["User"], (string)Session["Pass"]);

                Foto.ImageUrl = "ImgHandler.ashx?id=" + propuesta.Id.ToString();
                TextBoxDescripcion.Text = propuesta.Descripcion;
                DropDownListEstado.SelectedValue = propuesta.Estado.ToString();
                TextBoxPrecio.Text = propuesta.Precio.ToString();
                DateEditEntrega.Date = propuesta.FechaEntrega;
            }
        }
    }
}