﻿using System;
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
        SGC.ENPropuesta propuesta;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0 && Request.QueryString["id"].Length > 0)
            {
                int idPropuesta = int.Parse(Request.QueryString["id"]);

                propuesta = (SGC.ENPropuesta)glob.InterfazRemota.ObtenerPropuestaPorId(idPropuesta, Session["User"].ToString(), Session["Pass"].ToString());

                if (propuesta != null)
                {
                    Foto.ImageUrl = "ImgHandler.ashx?id=" + propuesta.Id.ToString();
                    TextBoxDescripcion.Text = propuesta.Descripcion;
                    TextBoxEstado.Text = propuesta.Estado.ToString();
                    TextBoxPrecio.Text = propuesta.Precio.ToString();
                    DateEditEntrega.Date = propuesta.FechaEntrega;
                    SGC.ENDesguace desguace = glob.InterfazRemota.ObtenerDesguace(propuesta.IdDesguace, (string)Session["User"], (string)Session["Pass"]);
                    if (desguace != null)
                    {
                        TextBoxNombre.Text = desguace.Nombre;
                        TextBoxNif.Text = desguace.Nif;
                        TextBoxDireccion.Text = desguace.Direccion;
                        TextBoxCorreoElectronico.Text = desguace.CorreoElectronico;
                        TextBoxTelefono.Text = desguace.Telefono;
                        TextBoxInfo.Text = desguace.InformacionAdicional;
                    }

                    if (propuesta.Confirmada == true)
                    {
                        buttonConfirmar.Visible = false;
                    }
                }
            }
        }


        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if(propuesta != null)
            {
                if (glob.InterfazRemota.ConfirmarPropuesta(propuesta, Session["User"].ToString(), Session["Pass"].ToString()))
                    Response.Redirect("Solicitud.aspx?id="+propuesta.IdSolicitud);
                else
                    Response.Write("<script language=javascript>alert('Error al confirmar la propuesta');</script>");
            }
        }
    }
}