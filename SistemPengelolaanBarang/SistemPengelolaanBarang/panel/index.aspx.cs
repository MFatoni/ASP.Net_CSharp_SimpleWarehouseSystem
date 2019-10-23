using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemPengelolaanBarang.panel
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["username"] != "Administrator")
            {
                Response.Redirect("../index.aspx");
            }
        }
        protected void btnlogout(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../index.aspx");
        }
    }
}