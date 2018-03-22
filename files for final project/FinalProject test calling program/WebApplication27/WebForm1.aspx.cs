using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication27
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.GPS_DataSoapClient ws = new ServiceReference1.GPS_DataSoapClient();
            string val =ws.GetCarPosition(1);
            TextBox1.Text = val;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.GPS_DataSoapClient ws = new ServiceReference1.GPS_DataSoapClient();
            string val = ws.GetCarPosition(2);
            TextBox2.Text = val;
        }
    }
}