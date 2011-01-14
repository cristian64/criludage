using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sitio_Web
{
    public partial class AltaCliente : System.Web.UI.Page
    {
        Global glob = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            SGC.ENCliente cliente = new SGC.ENCliente();

        }
    }
}