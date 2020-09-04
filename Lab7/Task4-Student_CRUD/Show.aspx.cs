using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab74
{
    public partial class Show : System.Web.UI.Page
    {
        protected void Show_Data()
        {
            using (DataClasses1DataContext dbcontext = new DataClasses1DataContext())
            {
                GridView1.DataSource = from Student in dbcontext.Students orderby Student.Id ascending select new { Student.Id, Student.name };
                GridView1.DataBind();
                msg.Text = "List of Students";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            if(!IsPostBack)
            {
                ButtonField bf1 = new ButtonField();
                bf1.Text = "Select";
                bf1.CommandName = "Select_Data";
                ButtonField bf2 = new ButtonField();
                bf2.Text = "Update";
                bf2.CommandName = "Update_Data";
                ButtonField bf3 = new ButtonField();
                bf3.Text = "Delete";
                bf3.CommandName = "Delete_Data";

                GridView1.Columns.Add(bf1);
                GridView1.Columns.Add(bf2);
                GridView1.Columns.Add(bf3);
            }
            Show_Data();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Insert.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Update.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Delete.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Show_Data();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            using (DataClasses1DataContext dbcontext = new DataClasses1DataContext())
            {
                GridView1.DataSource = from Student in dbcontext.Students orderby Student.name ascending select new { Student.Id, Student.name };
                GridView1.DataBind();
                msg.Text = "List of Students";
            }
        }

        protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Update_Data")
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvr = GridView1.Rows[index];
                TableCell tableCell = gvr.Cells[3];
                int id = Int32.Parse(tableCell.Text);
                using (DataClasses1DataContext dbcontext = new DataClasses1DataContext())
                {
                    Student s = dbcontext.Students.SingleOrDefault((i) => i.Id == id);
                    if (s != null)
                    {
                        sid.Text = id.ToString();
                        sname.Text = s.name;
                        scpi.Text = s.cpi.ToString();
                        ssem.Text = s.sem.ToString();
                        smobile.Text = s.contactno.ToString();
                        semail.Text = s.emailid.ToString();
                        msg.Text = "Student found";
                        msg.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        msg.Text = "Student with the given ID doesn't exists";
                        msg.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            else if (e.CommandName == "Delete_Data")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvr = GridView1.Rows[index];
                TableCell tableCell = gvr.Cells[3];
                int id = Int32.Parse(tableCell.Text);
                using (DataClasses1DataContext dbcontext = new DataClasses1DataContext())
                {
                    try
                    {
                        Student s = dbcontext.Students.SingleOrDefault((i) => i.Id == id);
                        if (s != null)
                        {
                            dbcontext.Students.DeleteOnSubmit(s);
                            dbcontext.SubmitChanges();
                            msg.Text = "Student deleted successfully";
                            msg.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            msg.Text = "Student with the given ID doesn't exists";
                            msg.ForeColor = System.Drawing.Color.Red;
                        }
                        Show_Data();

                    }
                    catch(Exception err)
                    {
                        msg.Text = err.Message;
                    }
                }
            }
            else if(e.CommandName == "Select_Data")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvr = GridView1.Rows[index];
                TableCell tableCell = gvr.Cells[3];
                int id = Int32.Parse(tableCell.Text);
                using (DataClasses1DataContext dbcontext = new DataClasses1DataContext())
                {
                    Student s = dbcontext.Students.SingleOrDefault((i) => i.Id == id);
                    if (s != null)
                    {
                        sid_show.Text = id.ToString();
                        sname_show.Text = s.name;
                        scpi_show.Text = s.cpi.ToString();
                        ssem_show.Text = s.sem.ToString();
                        smobile_show.Text = s.contactno.ToString();
                        semail_show.Text = s.emailid.ToString();
                        msg.Text = "Student found";
                        msg.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        msg.Text = "Student with the given ID doesn't exists";
                        msg.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        protected void update_data_Click(object sender, EventArgs e)
        {
            using (DataClasses1DataContext dbcontext = new DataClasses1DataContext())
            {
                try
                {
                    Student s = dbcontext.Students.SingleOrDefault((i) => i.Id == int.Parse(sid.Text));
                    s.name = sname.Text;
                    s.cpi = (decimal)(double.Parse(scpi.Text));
                    s.sem = int.Parse(ssem.Text);
                    s.contactno = (decimal)double.Parse(smobile.Text);
                    s.emailid = semail.Text;
                    dbcontext.SubmitChanges();
                    msg.Text = "Student updated successfully";
                    msg.ForeColor = System.Drawing.Color.Green;
                    Panel1.Visible = false;
                }
                catch (Exception err)
                {
                    msg.Text = "Error while updation";
                }
            }
        }
    }
}