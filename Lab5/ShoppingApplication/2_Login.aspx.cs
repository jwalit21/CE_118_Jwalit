using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shoppingApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["msg"]!=null)
            {
                msg.Text = Server.UrlDecode(Request.QueryString["msg"].ToString());
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (username.Text == "jwalit1" && password.Text == "1234")
            {
                if(Session["username"]==null || Session["password"]==null)
                {
                    Session["username"] = username.Text;
                    Session["password"] = password.Text;
                    Session["name"] = name.Text;
                    
                    Dictionary<string, int> purchased = new Dictionary<string, int>();
                    Session["purchased"] = purchased;
                }
                Response.Redirect("2_Home.aspx");
            }   
            else
            {
                msg.Text = "Incorrect credentials !";
                msg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}