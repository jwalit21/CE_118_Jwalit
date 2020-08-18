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
    public partial class Product : System.Web.UI.Page
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
            if (Request.QueryString["msg"] != null)
            {
                msg.Text = Server.UrlDecode(Request.QueryString["msg"].ToString());
            }

            if (!IsPostBack)
            {

                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                try
                {
                    using (connection)
                    {
                        string command = "Select * from Product";
                        SqlCommand cmd = new SqlCommand(command, connection);
                        connection.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        GridView1.DataSource = rdr;
                        GridView1.DataBind();
                        rdr.Close();
                        rdr = cmd.ExecuteReader();
                        products.Items.Clear();
                        while (rdr.Read())
                        {
                            ListItem l = new ListItem(rdr["pname"].ToString());
                            l.Value = rdr["pid"].ToString();
                            products.Items.Add(l);
                        }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            try
            {
                using (connection)
                {
                    string command;
                    SqlCommand cmd;
                    int order_id;
                    if (Session["orderid"] == null)
                    {
                        command = "insert into Order1(userid) values(@userid)";
                        cmd = new SqlCommand(command, connection);
                        cmd.Parameters.AddWithValue("@userid", (string)(Session["userid"]));
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        order_id = 0;

                        command = "select max(oid) as orderid from Order1 where Order1.userid=@user";
                        cmd = new SqlCommand(command, connection);
                        cmd.Parameters.AddWithValue("@user", (string)(Session["userid"]));
                        connection.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            order_id = Int32.Parse(rdr["orderid"].ToString());
                        }
                        Session["orderid"] = order_id;
                        rdr.Close();
                        connection.Close();
                    }
                    else
                    {
                        order_id = Int32.Parse(Session["orderid"].ToString());
                    }

                    foreach (ListItem i in products.Items)
                    {
                        if(i.Selected)
                        {
                            command = "insert into OrderProduct(oid,pid) values(@oid,@pid)";
                            cmd = new SqlCommand(command, connection);
                            cmd.Parameters.AddWithValue("@oid", order_id.ToString());
                            cmd.Parameters.AddWithValue("@pid", i.Value);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    Response.Redirect("Order.aspx");
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx?msg=" + Server.UrlEncode("Logged out successfully, Please Login again"));
        }

    }
}