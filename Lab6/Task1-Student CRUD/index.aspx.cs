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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msg.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx");
        }
        
        protected void Button6_Click(object sender, EventArgs e)
        {
            string s_name = sname.Text;
            string s_sem = ssem.SelectedValue;
            string s_email = semail.Text;
            string s_mobile = smobile.Text;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                using (connection)
                {
                    string command = "insert into student(sname,semail,ssem,smobile) values(@name,@email,@sem,@mobile)";
                    SqlCommand cmd = new SqlCommand(command, connection);
                    cmd.Parameters.AddWithValue("@name", s_name);
                    cmd.Parameters.AddWithValue("@email", s_email);
                    cmd.Parameters.AddWithValue("@sem", s_sem);
                    cmd.Parameters.AddWithValue("@mobile", s_mobile);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    msg.Visible = true;
                    msg.Text = "Student added successfully";
                    msg.ForeColor = System.Drawing.Color.Green;
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
            sname.Text = "";
            semail.Text = "";
            smobile.Text = "";
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("Show.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("Delete.aspx");
        }
    }
}