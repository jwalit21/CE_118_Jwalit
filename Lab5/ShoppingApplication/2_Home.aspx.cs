using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shoppingApplication
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"] == null || Session["password"] == null)
            {
                Response.Redirect("2_Login.aspx?msg="+ Server.UrlEncode("Please Login"));         
            }
            else
            {
                username_label.Text = "Hello " + (string)Session["username"];
            }
        }

        protected void catagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, int> d1 = new Dictionary<string, int>();
            d1.Add("TV", 50000);
            d1.Add("Keyboard", 1000);
            d1.Add("Fridge", 30000);
            d1.Add("Mobile", 15000);
            Dictionary<string, int> d2 = new Dictionary<string, int>();
            d2.Add("Chhel Chhabilo Gujarati", 500);
            d2.Add("Wings of Fire", 1000);
            d2.Add("Satya na prayogo", 300);
            d2.Add("Half Girlfriend", 450);

            if (catagory.SelectedValue.Equals("Electronics"))
            {
                items.Items.Clear();
                foreach (var item in d1)
                {
                    ListItem l = new ListItem(item.Key);
                    items.Items.Add(l);
                }
            }
            else if (catagory.SelectedValue.Equals("Books"))
            {
                items.Items.Clear();

                foreach (var item in d2)
                {
                    ListItem l = new ListItem(item.Key);
                    items.Items.Add(l);
                }
            }
        }

        protected void items_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, int> d1 = new Dictionary<string, int>();
            d1.Add("TV", 50000);
            d1.Add("Keyboard", 1000);
            d1.Add("Fridge", 30000);
            d1.Add("Mobile", 15000);
            Dictionary<string, int> d2 = new Dictionary<string, int>();
            d2.Add("Chhel Chhabilo Gujarati", 500);
            d2.Add("Wings of Fire", 1000);
            d2.Add("Satya na prayogo", 300);
            d2.Add("Half Girlfriend", 450);

            Dictionary<string, int> purchased = (Dictionary<string, int>)Session["purchased"];
            string cata = catagory.SelectedValue;
            string item = items.SelectedValue;
            if (cata.Equals("Electronics"))
            {
                if (purchased.ContainsKey(item))
                {
                    purchased[item] = purchased[item] + d1[item];
                }
                else
                {
                    purchased.Add(item, d1[item]);
                }
                int total = purchased[item] / d1[item];
                selected.Text = "Till now " + item + " is selected " + total.ToString() + " times.";
                Session["purchased"] = purchased;

            }
            else if (cata.Equals("Books"))
            {
                if (purchased.ContainsKey(item))
                {
                    purchased[item] = purchased[item] + d2[item];
                }
                else
                {
                    purchased.Add(item, d2[item]);
                }
                int total = purchased[item] / d2[item];
                selected.Text = "Till now " + item + " is selected " + total.ToString() + " times.";
                Session["purchased"] = purchased;
            }

        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("2_Login.aspx?msg=" + Server.UrlEncode("Logged out successfully, Please Login again"));
        }

        protected void order_Click(object sender, EventArgs e)
        {
            Session["catagory"] = catagory.SelectedValue;
            Response.Redirect("2_Order.aspx");
        }
    }
}