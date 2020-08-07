using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shoppingApplication
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["password"] == null)
            {
                Response.Redirect("2_Login.aspx?msg=" + Server.UrlEncode("Please Login"));
            }
            else
            {
                username_label.Text = "Hello " + (string)Session["username"];
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
                int total_cost = 0;
                foreach (var item in purchased)
                {
                    TableCell tc_item = new TableCell();
                    tc_item.Text = item.Key;
                    TableCell tc_no = new TableCell();
                    if(d1.ContainsKey(item.Key))
                    {
                        tc_no.Text = (item.Value / d1[item.Key]).ToString();
                    }
                    else if(d2.ContainsKey(item.Key))
                    {
                        tc_no.Text = (item.Value / d2[item.Key]).ToString();
                    }
                    TableCell total_price = new TableCell();
                    total_price.Text = item.Value.ToString();
                    total_cost = total_cost + item.Value;
                    TableRow tr = new TableRow();
                    tr.Cells.Add(tc_item);
                    tr.Cells.Add(tc_no);
                    tr.Cells.Add(total_price);
                    Table1.Rows.Add(tr);
                }
                total.Text = "Hey " + (string)Session["name"] + ".....!! Your total Order value is " + total_cost.ToString();
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("2_Login.aspx?msg=" + Server.UrlEncode("Logged out successfully, Please Login again"));
        }
    }
}