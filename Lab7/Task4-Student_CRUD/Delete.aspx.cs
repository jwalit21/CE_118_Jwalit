using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab74
{
    public partial class Delete : System.Web.UI.Page
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
            Response.Redirect("Update.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Show.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(sid_delete.Text);
            using (DataClasses1DataContext dbcontext = new DataClasses1DataContext())
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
            }
        }
    }
}