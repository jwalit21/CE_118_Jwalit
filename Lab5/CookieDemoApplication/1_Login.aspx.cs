using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cookieWebapplication
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msg.Visible = false;
            
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (username.Text == "jwalit1" && password.Text == "1234")
            {
                if(Request.Cookies["credentials"] == null)
                {
                    HttpCookie cookie = new HttpCookie("credentials");
                    cookie["username"] = username.Text;
                    cookie["password"] = password.Text;
                    cookie["name"] = name.Text;
                    Response.Cookies.Add(cookie);
                }
                Response.Redirect("1_Home.aspx");
            }
            else
            {
                msg.Visible = true;
                msg.Text = "Incorrect credentials !";
                msg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}