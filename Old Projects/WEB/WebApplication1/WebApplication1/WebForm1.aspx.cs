using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Application["AS1"] == null)
                    Application["AS1"] = 1;
                else
                    TextBox1.Text = Convert.ToString(Application["AS1"]);

                if (ViewState["VS1"] == null)
                    ViewState["VS1"] = 1;
                else
                    TextBox1.Text = Convert.ToString(ViewState["VS1"]);

                if (Session["SS1"] == null)
                    Session["SS1"] = 1;
                else
                    TextBox1.Text = Convert.ToString(Session["SS1"]);
            }
        }

        protected void ListBox1_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int a = ((int)Application["AS1"]) + 1;
            TextBox1.Text = a.ToString();
            Application["AS1"] = a;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ViewState["VS1"] = (int)ViewState["VS1"] + 1;
            TextBox2.Text = Convert.ToString(ViewState["VS1"]);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}