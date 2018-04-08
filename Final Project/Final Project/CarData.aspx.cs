using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.ServiceModel;

namespace Final_Project
{
    public partial class CarData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BasicHttpBinding bin = new BasicHttpBinding();
                EndpointAddress address =
                   new EndpointAddress("http://" + Request.Form["addr"] + "/GPS_Data.asmx");

                GPSData.GPS_DataSoapClient client = new GPSData.GPS_DataSoapClient(bin, address);

                Response.Write(client.GetCarPosition(int.Parse(Request.Form["car"])));
            }
            catch (Exception)
            {

            }
        }
    }
}