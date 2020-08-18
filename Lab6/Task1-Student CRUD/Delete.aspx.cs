using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab6_1_Student_CRUD
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(sid_delete.Text);
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                using (connection)
                {
                    string command = "Select * from Student";
                    SqlCommand cmd = new SqlCommand(command, connection);
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    int flag = 0;
                    while (rdr.Read())
                    {
                        if (id == Int32.Parse(rdr["sid"].ToString()))
                        {
                            flag = 1;
                            string command_2 = "delete from student where sid=@id";
                            SqlCommand cmd2 = new SqlCommand(command_2, connection);
                            cmd2.Parameters.AddWithValue("@id", id);
                            rdr.Close();
                            cmd2.ExecuteNonQuery();
                            msg.Visible = true;
                            msg.Text = "Student deleted successfully";
                            msg.ForeColor = System.Drawing.Color.Green;
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        msg.Visible = true;
                        msg.Text = "Entered Value is not valid";
                        msg.ForeColor = System.Drawing.Color.Red;
                        sid_delete.Text = "";
                    }
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Show.aspx");
        }
    }
}