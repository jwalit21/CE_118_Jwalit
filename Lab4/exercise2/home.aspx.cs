using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Basic_login_application
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                password.Attributes["value"] = password.Text;
                confirm_password.Attributes["value"] = confirm_password.Text;
            }
            else
            {
                success.Text = "Logged in successfully";
            }
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedValue.Equals("Maharashtra"))
            {
                DropDownList2.Items.Clear();
                ListItem l1 = new ListItem("Mumbai");
                ListItem l2 = new ListItem("Pune");
                DropDownList2.Items.Add(l1);
                DropDownList2.Items.Add(l2);
            }
            if (DropDownList3.SelectedValue.Equals("Gujarat"))
            {
                DropDownList2.Items.Clear();
                ListItem l1 = new ListItem("Ahmedabad");
                ListItem l2 = new ListItem("Vadodara");
                DropDownList2.Items.Add(l1);
                DropDownList2.Items.Add(l2);
            }
        }

        protected void pan_Validate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "")
                args.IsValid = false;
            else
            {
                if (args.Value.Length == 10 && (args.Value.StartsWith("B") || args.Value.StartsWith("A")))
                {
                    args.IsValid = true;
                }
                else
                    args.IsValid = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Page.IsValid == true)
            {
                msg.Text = "Data saved successfully !";
                msg.ForeColor = System.Drawing.Color.Green;
                Label_Fullname.Text = "Fullname: " + fullname.Text;
                Label_Age.Text = "Age: " + age.Text;
                Label_Gender.Text = "Gender: " + gender.SelectedValue;
                Label_Hobbies.Text = "Hobbies: ";
                for (int i = 0; i < hobbies.Items.Count; i++)
                {
                    if(hobbies.Items[i].Selected)
                    {
                        Label_Hobbies.Text = Label_Hobbies.Text + hobbies.Items[i] + " ";
                    }
                }
                Label_Mobile.Text = "Mobile no: " + mobile.Text;
                Label_Pan.Text = "PAN no: " + pan.Text;
                Label_State.Text = "State: " + DropDownList3.SelectedValue;
                Label_City.Text = "City: " + DropDownList2.SelectedValue;
            }
            else
            {
                msg.Text = "Data is invalid !";
                msg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}