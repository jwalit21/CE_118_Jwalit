using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab74
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Insert.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Delete.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Show.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(sid_update.Text);
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
                    msg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    msg.Text = "Student with the given ID doesn't exists";
                    msg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
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
                }
                catch(Exception err)
                {
                    msg.Text= "Error while updation";
                }
            }

        }
    }
}