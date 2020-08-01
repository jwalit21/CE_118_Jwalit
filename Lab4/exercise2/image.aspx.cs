using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Basic_login_application
{
    public partial class image : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Image1.Visible == true)
            {
                Image1.Visible = false;
                Button1.Text = "Show image";
            }
            else
            {
                Image1.Visible = true;
                Button1.Text = "Hide image";
            }
        }
    }
}