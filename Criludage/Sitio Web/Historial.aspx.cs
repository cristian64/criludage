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
    public partial class Historial : System.Web.UI.Page
    {
        private DataTable dataTable;
        Global glob = new Global();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SesionIniciada"] == null || (bool)Session["SesionIniciada"] == false)
                Response.Redirect("Default.aspx");

            dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Descripcion", typeof(String));
            dataTable.Columns.Add("FechaEntrega", typeof(DateTime));
            dataTable.Columns.Add("Estado", typeof(String));
            dataTable.Columns.Add("Precio", typeof(decimal));

            object[] listaObj = glob.InterfazRemota.ObtenerPropuestasConfirmadas(Session["User"].ToString(), Session["Pass"].ToString());

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


            GridViewPropuestas.DataSource = dataTable;
            GridViewPropuestas.DataBind();

        }


    }
}