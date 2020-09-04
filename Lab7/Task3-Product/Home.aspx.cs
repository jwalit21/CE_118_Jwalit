using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab72_Product_CRUD
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int pid = Int32.Parse(proid.Text);
            string url = "Product.aspx?";
            url += "id=" + Server.UrlEncode(pid.ToString());
            Response.Redirect(url);
        }
    }
}