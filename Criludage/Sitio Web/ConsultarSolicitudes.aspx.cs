using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Collections;
using DevExpress.Web.ASPxGridView;

namespace Sitio_Web
{
    public partial class ConsultarSolicitudes : System.Web.UI.Page
    {
        Global glob = new Global();
        private DataTable dataTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SesionIniciada"] == null || (bool)Session["SesionIniciada"] == false)
                Response.Redirect("Default.aspx");


            dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Descripcion", typeof(String));
            dataTable.Columns.Add("Fecha", typeof(DateTime));
            dataTable.Columns.Add("FechaResp", typeof(DateTime));
            dataTable.Columns.Add("Negociado", typeof(bool));
            dataTable.Columns.Add("Estado", typeof(String));
            dataTable.Columns.Add("PrecioMax", typeof(decimal));
            dataTable.Columns.Add("FechaEntrega", typeof(DateTime));

            object[] listaSolicitudes = null;
            try
            {
                listaSolicitudes = glob.InterfazRemota.ObtenerSolicitudesPorUsuario((string)Session["User"], (string)Session["Pass"]);
            }
            catch (Exception)
            {
                Response.Write("<script language=javascript>alert('Ha habido un error al procesar la solicitud, vuelve a intentarlo');</script>");
                return;
            }
        
            foreach (object o in listaSolicitudes)
            {
                SGC.ENSolicitud solicitud = (SGC.ENSolicitud)o;
                dataTable.Rows.Add(
                        new object[] {
                            solicitud.Id,
                            solicitud.Descripcion,
                            solicitud.Fecha,
                            solicitud.FechaRespuesta,
                            solicitud.NegociadoAutomatico,
                            solicitud.Estado,
                            solicitud.PrecioMax,
                            solicitud.FechaEntrega
                        }
                );
            }

            GridViewSolicitudes.DataSource = dataTable;
            GridViewSolicitudes.DataBind();

        }


        protected void GridViewSolicitudes_HtmlRowPreprared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != GridViewRowType.Data) return;

            DateTime fechaRespuesta = DateTime.Parse(e.GetValue("FechaEntrega").ToString());
            if (fechaRespuesta > DateTime.Now)
            {
                e.Row.BackColor = System.Drawing.Color.Beige;
            }
            
        }

    }
}