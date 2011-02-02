using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Sitio_Web
{
    /// <summary>
    /// Descripción breve de ImgHandler
    /// </summary>
    public class ImgHandler : IHttpHandler, IRequiresSessionState
    {
        Global glob = new Global();

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["SesionIniciada"] == null || (bool)context.Session["SesionIniciada"] == false)
                context.Response.WriteFile(@"img/sinimagen.png");
            else if (context.Request.QueryString.Count > 0 && context.Request.QueryString["id"].Length > 0)
            {
                int idPropuesta = int.Parse(context.Request.QueryString["id"]);

                SGC.ENPropuesta propuesta = (SGC.ENPropuesta)glob.InterfazRemota.ObtenerPropuestaPorId(idPropuesta, context.Session["User"].ToString(), context.Session["Pass"].ToString());


                if (propuesta != null && propuesta.Foto != null)
                {
                    context.Response.BinaryWrite(propuesta.Foto);
                }
                else
                {
                    context.Response.WriteFile(@"img/sinimagen.png");
                }
                
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}