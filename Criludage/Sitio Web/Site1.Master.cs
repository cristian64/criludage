using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sitio_Web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SesionIniciada"]!=null && (bool)Session["SesionIniciada"] == true)
            {
                this.FindControl("NoIniciada").Visible = false;
                this.FindControl("Iniciada").Visible = true;
            }
            else
            {
                this.FindControl("NoIniciada").Visible = true;
                this.FindControl("Iniciada").Visible = false;
            }
        }
    }
}