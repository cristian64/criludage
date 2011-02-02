using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Collections;

namespace Sitio_Web
{
    public partial class Solicitud : System.Web.UI.Page
    {
        private DataTable dataTable;
        Global glob = new Global();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SesionIniciada"] == null || (bool)Session["SesionIniciada"] == false)
                Response.Redirect("Default.aspx");

            if (Context.Request.QueryString.Count > 0 && Context.Request.QueryString["id"].Length > 0)
            {
                bool finalizada = false;
                int id = int.Parse(Context.Request.QueryString["id"]);
                SGC.ENSolicitud solicitud = glob.InterfazRemota.ObtenerSolicitudPorId(id, (string)Session["User"], (string)Session["Pass"]);

                TextBoxDescripcion.Text = solicitud.Descripcion;
                RadioButtonListNegociado.SelectedIndex = solicitud.NegociadoAutomatico ? 1 : 0;

                TextBoxEstado.Text = solicitud.Estado.ToString();
                TextBoxPrecio.Text = solicitud.PrecioMax.ToString();

                DateEditFecha.Date = solicitud.Fecha;
                DateEditEntrega.Date = solicitud.FechaEntrega;
                DateEditRespuesta.Date = solicitud.FechaRespuesta;

                if (solicitud.FechaRespuesta < DateTime.Now)
                {
                    TextBoxEstadoSolicitud.Text = "Finalizada";
                    finalizada = true;
                }
                else
                {
                    TextBoxEstadoSolicitud.Text = "Pendiente";
                }

                dataTable = new DataTable();
                dataTable.Columns.Add("ID", typeof(int));
                dataTable.Columns.Add("Descripcion", typeof(String));
                dataTable.Columns.Add("FechaEntrega", typeof(DateTime));
                dataTable.Columns.Add("Estado", typeof(String));
                dataTable.Columns.Add("Precio", typeof(decimal));


                if (finalizada == true)
                {
                    //Tabla de propuestas
                    object[] listaObj = glob.InterfazRemota.ObtenerPropuestas(solicitud,
                        (string)Session["User"], (string)Session["Pass"]);


                    SGC.ENPropuesta propuesta;

                    foreach (object obj in listaObj)
                    {
                        propuesta = (SGC.ENPropuesta)obj;
                        dataTable.Rows.Add(
                            new object[] {
                            propuesta.Id,
                            propuesta.Descripcion,
                            propuesta.FechaEntrega,
                            propuesta.Estado,
                            propuesta.Precio
                        }
                        );

                    }
                }
                else
                {
                    bloquePropuestas.Visible = false;
                }

                GridViewPropuestas.DataSource = dataTable;
                GridViewPropuestas.DataBind();
            }




        }
    }
}