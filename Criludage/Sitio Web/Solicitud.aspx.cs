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
                SGC.ENSolicitud solicitud = null;
                
                try
                {
                    solicitud = glob.InterfazRemota.ObtenerSolicitudPorId(id, (string)Session["User"], (string)Session["Pass"]);
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
                    TextBoxEstadoSolicitud.Style.Add(HtmlTextWriterStyle.Color, "red");
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
                dataTable.Columns.Add("Confirmada", typeof(Boolean));

                if (finalizada == true)
                {
                    //Tabla de propuestas
                    object[] listaObj = null;

                    try
                    {
                        listaObj = glob.InterfazRemota.ObtenerPropuestas(solicitud,
                        (string)Session["User"], (string)Session["Pass"]);
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
                            propuesta.Precio,
                            propuesta.Confirmada
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


        protected void GridViewPropuestas_HtmlRowPreprared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != GridViewRowType.Data) return;

            bool valor = bool.Parse(e.GetValue("Confirmada").ToString());
            if (valor == true)
            {
                e.Row.BackColor = System.Drawing.Color.Beige;
            }

        }

    }
}