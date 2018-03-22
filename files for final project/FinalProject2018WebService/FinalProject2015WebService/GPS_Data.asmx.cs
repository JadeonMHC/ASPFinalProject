using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.OleDb;
using System.Timers;

namespace FinalProject2015WebService
{
    /// <summary>
    /// Summary description for GPS_Data
    /// </summary>
    [WebService(Namespace = "http://localhost/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    
    public class GPS_Data : System.Web.Services.WebService
    {
        // Static variables don't need to be saved with Application[]
        private static List<string> LatLng = new List<string>();
        public static int DataCnt;
        private static List<Vehicle> Vehicles = new List<Vehicle>();
 
        // constructor
        public GPS_Data()
        {
            if (Vehicles.Count == 0)
            {
                LoadDBData();
                Vehicles.Add(new Vehicle("Steve on bike"));
                Vehicles.Add(new Vehicle("Steve in truck"));
                Vehicles.Add(new Vehicle("Steve in corvette"));
            }
        }
         
 
        [WebMethod(EnableSession = true)]
        public string GetCarPosition(int CarNum)
        {
                if (CarNum > 0 && CarNum < 4)
                    return Vehicles[CarNum - 1].name + "," + LatLng.ElementAt(Vehicles[CarNum - 1].position);
                else
                    return "Invalid CarNum";
        }
    

        private void LoadDBData()
        {
            string DBPath = Server.MapPath("~/App_Data/DriveData.mdb");
            string ConString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBPath;  // use this for .mdb
            string SqlString = "SELECT DataString FROM Data";
            OleDbConnection Con = new OleDbConnection(ConString);
            OleDbCommand Cmd = new OleDbCommand(SqlString, Con);

            Cmd.Connection.Open();
            OleDbDataReader myReader = Cmd.ExecuteReader();

            while (myReader.Read())
            {
                string tmp = myReader.GetString(0);
                if (tmp.Length >= 10)
                    if (tmp.Substring(0, 6) == "$GPRMC")
                    {
                        string ret = ConvertGPRMC(tmp);
                        if (ret != "") LatLng.Add(ret);
                    }
            }
            myReader.Close();
            Con.Close();
            DataCnt = LatLng.Count;
        }

        private string ConvertGPRMC(string coord)
        {
            double NewLat=0;
            double NewLong=0;
            string[] coordArray = new string[20];

            try
            {
                coordArray = coord.Split(',').ToArray();
                if (coordArray.Length >= 7)
                {
                    int d = coordArray[3].IndexOf('.');  // find the location of the decimal point
                    if (d != -1)
                    {
                        NewLat = (Convert.ToDouble(coordArray[3].Substring(0, d - 2))); // whole number LAT
                        NewLat += Convert.ToDouble(coordArray[3].Substring(d - 2, coordArray[3].Length - d + 2)) / 60; // add fractional portion
                    }

                    if (coordArray[4].IndexOf('S') != -1)
                        NewLat = -NewLat;

                    d = coordArray[5].IndexOf('.');  // find the location of the decimal point
                    if (d != -1)
                    {
                        NewLong = (Convert.ToDouble(coordArray[5].Substring(0, d - 2))); // whole number LONG
                        NewLong += Convert.ToDouble(coordArray[5].Substring(d - 2, coordArray[5].Length - d + 2)) / 60; // add fractional portion
                    }

                    if (coordArray[6].IndexOf('W') != -1)
                        NewLong = -NewLong;

                    return NewLat.ToString() + "," + NewLong.ToString();
                }
                return "";
            }
            catch (Exception ex)
            {
                // no error message as we are inside the server
                return "";
            }
        }

    }
}
