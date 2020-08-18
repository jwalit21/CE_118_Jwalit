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
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msg.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(sid_update.Text);
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
                    while(rdr.Read())
                    {
                        if(id== Int32.Parse(rdr["sid"].ToString()))
                        {
                            flag = 1;
                            sid.Text = rdr["sid"].ToString();
                            sname.Text = rdr["sname"].ToString();
                            ssem.SelectedValue = rdr["ssem"].ToString();
                            smobile.Text = rdr["smobile"].ToString();
                            semail.Text = rdr["semail"].ToString();
                            msg.Visible = true;
                            msg.Text = "Student found successfully";
                            msg.ForeColor = System.Drawing.Color.Green;
                            break;
                        }
                    }
                    rdr.Close();
                    if (flag == 0)
                    {
                        msg.Visible = true;
                        msg.Text = "Entered Value is not valid";
                        msg.ForeColor = System.Drawing.Color.Red;
                        sid_update.Text = "";
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
            Response.Redirect("Delete.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Show.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int s_id = Int32.Parse(sid.Text);
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
                    string command = "update student set sname=@name, semail=@email, ssem=@sem, smobile=@mobile where sid=@id";
                    SqlCommand cmd = new SqlCommand(command, connection);
                    cmd.Parameters.AddWithValue("@id", s_id);
                    cmd.Parameters.AddWithValue("@name", s_name);
                    cmd.Parameters.AddWithValue("@email", s_email);
                    cmd.Parameters.AddWithValue("@sem", s_sem);
                    cmd.Parameters.AddWithValue("@mobile", s_mobile);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    msg.Visible = true;
                    msg.Text = "Student updated successfully";
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
        }
    }
}