using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cookieWebapplication
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["credentials"]== null)
            {
                username_label.Text = "Hello Guest";
            }
            else
            {
                HttpCookie cookies = Request.Cookies["credentials"];
                username_label.Text = "Hello " + cookies["username"];
            }
        }

        protected void know_credentials_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["credentials"] == null)
            {
                success.Text = "Guest don't have credentials";
            }
            else
            {
                HttpCookie cookies = Request.Cookies["credentials"];
                success.Text = "Your credentials " + cookies["name"];
                username.Text = "Your username is : " + cookies["username"];
                password.Text = "Your password is : " + cookies["password"];
                name.Text = "Your nname is : " + cookies["name"];
            }
        }

        protected void forget_credentials_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["credentials"] == null)
            {
                success.Text = "Guest don't have credentials...";
            }
            else
            {
                Response.Cookies["credentials"].Expires = DateTime.Now.AddDays(-1);
                success.Text = "Credentials forgottened";
                username.Text = "";
                password.Text = "";
                name.Text = "";
                username_label.Text = "Hello Guest";
            }
        }
    }
}