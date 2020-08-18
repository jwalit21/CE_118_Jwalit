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
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userid"] == null || Session["password"] == null)
            {
                Response.Redirect("Login.aspx?msg=" + Server.UrlEncode("Please Login"));
            }
            else
            {
                user.Text = (string)Session["userid"];
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                using (connection)
                {
                    string command = "Select Order1.userid,Order1.oid,Product.pid,Product.pname,Product.price from Product,Order1,OrderProduct where OrderProduct.oid=@orderid and OrderProduct.pid=Product.pid and Order1.oid=@orderid";
                    SqlCommand cmd = new SqlCommand(command, connection);
                    cmd.Parameters.AddWithValue("@orderid", Int32.Parse(Session["orderid"].ToString()));
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                    rdr.Close();
                    msg.Text = "Your Placed Order";
                    msg.ForeColor = System.Drawing.Color.Green;
                    connection.Close();

                    command = "Select SUM(Product.price) as price from Product,Order1,OrderProduct where OrderProduct.oid=@orderid and OrderProduct.pid=Product.pid and Order1.oid=@orderid";
                    cmd = new SqlCommand(command, connection);
                    cmd.Parameters.AddWithValue("@orderid", Int32.Parse(Session["orderid"].ToString()));
                    connection.Open();
                    rdr = cmd.ExecuteReader();
                    int total_price = 0;
                    while(rdr.Read())
                    {
                        total_price = Int32.Parse(rdr["price"].ToString());
                    }
                    price.Text = "Your placed Order total value is " + total_price.ToString();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx?msg=" + Server.UrlEncode("Logged out successfully, Please Login again"));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["orderid"] = null;
            Response.Redirect("Product.aspx?msg=" + Server.UrlEncode("Cart cleared successfully, Please Place Order again"));
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product.aspx");
        }
    }
}