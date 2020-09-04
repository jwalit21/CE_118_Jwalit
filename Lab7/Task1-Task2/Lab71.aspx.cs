using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab7_1_2_Linq
{
    public partial class Lab71 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var numberlist = new List<int>();
            var nameslist = new List<string>();
            for (int i = 1; i <= 100; i++)
                numberlist.Add(i);
            nameslist.Add("jay");
            nameslist.Add("karan");
            nameslist.Add("jwalit");
            nameslist.Add("om");
            nameslist.Add("jal");
            nameslist.Add("dev");
            nameslist.Add("krutarth");
            nameslist.Add("shrushti");
            nameslist.Add("keya");
            nameslist.Add("harshil");
            Label1.Text = "";
            Label10.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            Label2.Text = "";
            Label5.Text = "";
            Label6.Text = "";
            Label7.Text = "";
            Label8.Text = "";
            Label9.Text = "";

            
            var output1 = numberlist.Where(i => (i % 2 == 1));
            foreach(int i in output1)
            {
                Label1.Text = Label1.Text + i.ToString() + " ";
            }
            var output2 = numberlist.Where(i => (i % 2 == 0));
            foreach (int i in output2)
            {
                Label2.Text = Label2.Text + i.ToString() + " ";
            }
            var output3 = numberlist.Select(i => i);
            foreach (int i in output3)
            {
                Label3.Text = Label3.Text + i.ToString() + " ";
            }
            int output4 = numberlist.Max();
            int output5 = numberlist.Min();
            double output6 = numberlist.Average();
            Label4.Text = output4.ToString() + " ";
            Label5.Text = output5.ToString() + " ";
            Label6.Text = output6.ToString() + " ";

            var output7 = nameslist.Where(i => (i.StartsWith("k"))==true);
            foreach (string i in output7)
            {
                Label7.Text = Label7.Text + i + " ";
            }
            var output8 = nameslist.Where(i => i.Length < 4);
            foreach (string i in output8)
            {
                Label8.Text = Label8.Text + i + " ";
            }
            var output9 = nameslist.Where(i => i.Length == 3);
            foreach (string i in output9)
            {
                Label9.Text = Label9.Text + i + " ";
            }
            var output10 = nameslist.OrderBy(i => i);
            foreach (string i in output10)
            {
                Label10.Text = Label10.Text + i + " ";
            }

        }
    }
}