using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sitio_Web
{
    public partial class SolicitarPieza : System.Web.UI.Page
    {
        Global glob = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SesionIniciada"] == null || (bool)Session["SesionIniciada"] == false)
                Response.Redirect("Default.aspx");

            ListItem li;
            foreach (SGC.ENEstadosPieza item in Enum.GetValues(typeof(SGC.ENEstadosPieza)))
            {
                li = new ListItem();
                li.Value = item.ToString();
                li.Text = item.ToString();
                DropDownListEstado.Items.Add(li);
            }
        }

        protected void ValidacionFecha(object source, ServerValidateEventArgs value)
        {
            if (value.Value == null || DateTime.Parse(value.Value) <= DateTime.Now)
            {
                value.IsValid = false;
            }
            else value.IsValid = true;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            Page.Validate("grupo1");

            if (Page.IsValid == true)
            {
                SGC.ENSolicitud solicitud = new SGC.ENSolicitud();

                solicitud.IdCliente = (int)Session["Id"];
                solicitud.Descripcion = TextBoxDescripcion.Text;
                solicitud.NegociadoAutomatico = (RadioButtonListNegociado.SelectedIndex == 1);
                try
                {
                    solicitud.Estado = (SGC.ENEstadosPieza)Enum.Parse(typeof(SGC.ENEstadosPieza), DropDownListEstado.SelectedItem.ToString());
                }
                catch (Exception)
                {
                    solicitud.Estado = SGC.ENEstadosPieza.USADA;
                }
                solicitud.Fecha = DateTime.Now;
                solicitud.FechaEntrega = DateEditEntrega.Date;
                solicitud.FechaRespuesta = DateEditRespuesta.Date;
                solicitud.PrecioMax = float.Parse(TextBoxPrecio.Text);

                
                try
                {
                    solicitud.Id = glob.InterfazRemota.SolicitarPieza(solicitud, (string)Session["User"], (string)Session["Pass"]);
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=javascript>alert("+ex.Message+");</script>");
                }
                if (solicitud.Id > 0)
                {
                    //todo OK
                    Response.Redirect("ConsultarSolicitudes.aspx");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Error al enviar la solicitud, revisa los campos');</script>");
                }
            }

        }
    }
}