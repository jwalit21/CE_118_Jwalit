using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab6_2_Product_Application
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["msg"] != null)
            {
                msg.Text = Server.UrlDecode(Request.QueryString["msg"].ToString());
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                using (connection)
                {
                    string command = "Select * from User1";
                    SqlCommand cmd = new SqlCommand(command, connection);
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (username.Text == rdr["userid"].ToString() && password.Text == rdr["password"].ToString())
                        {
                            if (Session["userid"] == null || Session["password"] == null)
                            {
                                Session["userid"] = username.Text;
                                Session["password"] = password.Text;
                            }
                            rdr.Close();
                            connection.Close();
                            Response.Redirect("Product.aspx");
                        }
                    }
                    msg.Text = "Incorrect credentials !";
                    msg.ForeColor = System.Drawing.Color.Red;
                    rdr.Close();
                    connection.Close();
                }
            }
            catch (Exception err)
            {
                msg.Visible = true;
                msg.Text = "Error reading Database : ";
                msg.Text += err.Message;
                msg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}