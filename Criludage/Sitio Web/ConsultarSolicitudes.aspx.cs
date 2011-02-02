﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Collections;

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


            object[] listaSolicitudes = glob.InterfazRemota.ObtenerSolicitudesPorUsuario((string)Session["User"], (string)Session["Pass"]);
            
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


    }
}