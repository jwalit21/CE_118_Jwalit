using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Basic_login_application
{
    public partial class login_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msg.Text = " ";
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if(username.Text == "jwalit1" && password.Text == "1234")
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                msg.Text = "Incorrect credentials !";
                msg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}