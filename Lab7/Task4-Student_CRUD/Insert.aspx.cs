using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab74
{
    public partial class Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("Show.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("Delete.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Update.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            using (DataClasses1DataContext dbcontext = new DataClasses1DataContext())
            {
                Student s = new Student
                {
                    name = sname.Text,
                    cpi = (decimal)(double.Parse(scpi.Text)),
                    sem = int.Parse(ssem.Text),
                    contactno = (decimal)double.Parse(smobile.Text),
                    emailid = semail.Text
                };
                dbcontext.Students.InsertOnSubmit(s);
                dbcontext.SubmitChanges();

            }

            msg.Text = "Student added successfully";
            msg.ForeColor = System.Drawing.Color.Green;
        }
    }
}