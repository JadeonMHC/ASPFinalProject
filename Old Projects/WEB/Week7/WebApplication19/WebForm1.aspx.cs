using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using Subgurim.Controles;
using System.Data.OleDb;

namespace WebApplication19
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string[] GPSData = new string[] {
            "5000.8154,N,11039.2593,W",
            "5000.9567,N,11039.4332,W",
            "5001.1218,N,11039.6425,W",
            "5001.3636,N,11039.9991,W",
            "5001.8286,N,11040.1426,W",
            "5002.1022,N,11040.1415,W",
            "5002.4679,N,11040.4419,W",
            "5002.4067,N,11040.6739,W"
        };

        public OleDbConnection Connect() {
            string DBPath = "~/app_data/data.mdb";
            string ConString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" + MapPath(DBPath);
            return new OleDbConnection(ConString);
        }

        private double GetDeg(string s, char m) {
            int per = s.IndexOf('.');

            double big = double.Parse(s.Substring(0, per - 2));
            double small = double.Parse(s.Substring(per - 2));

            return (big + (small / 60.0)) * ((m == 'S' || m == 'W') ? -1.0 : 1.0);
        }

        private GLatLng CoordFromString(string s) {
            string[] parts = s.Split(',');

            return new GLatLng(GetDeg(parts[0], parts[1][0]), GetDeg(parts[2], parts[3][0]));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GMap1.GZoom = 15;
            GMap1.enableHookMouseWheelToZoom = true;
            GMap1.mapType = GMapType.GTypes.Hybrid;
            GMap1.enableRotation = true;
            GMap1.Add(new GControl(GControl.preBuilt.LargeMapControl));
            GMap1.Add(GMapType.GTypes.Physical);
            GMap1.Add(GMapType.GTypes.Normal);
            GMap1.Add(GMapType.GTypes.Satellite);
            GMap1.Add(GMapType.GTypes.Hybrid);
            GMap1.enableGKeyboardHandler = true;
        }

        private void SetPath(List<GLatLng> path) {
            GLatLng min = path[0].Clone();
            GLatLng max = path[0].Clone();

            foreach (GLatLng c in path) {
                min.lat = Math.Min(min.lat, c.lat);
                min.lng = Math.Min(min.lng, c.lng);

                max.lat = Math.Max(max.lat, c.lat);
                max.lng = Math.Max(max.lng, c.lng);
            }

            GMap1.setCenter(new GLatLng((min.lat + max.lat) * 0.5, (min.lng + max.lng) * 0.5), 13);
            GPolyline LineRoute = new GPolyline(path, "FF0000", 5);
            GMap1.Add(LineRoute);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GMap1.reset();

            List<GLatLng> Route = new List<GLatLng>();
            foreach (string s in GPSData) {
                Route.Add(CoordFromString(s));
            }

            SetPath(Route);
        }

        protected void Button2_Click(object sender, EventArgs e) {
            GMap1.reset();

            string SQLString = "SELECT RTime, DataString FROM Data ORDER BY ID";

            OleDbConnection Con = Connect();
            OleDbCommand Cmd = new OleDbCommand(SQLString, Con);

            Cmd.Connection.Open();
            OleDbDataReader myReader = Cmd.ExecuteReader();

            List<GLatLng> lines = new List<GLatLng>();

            while (myReader.Read()) {
                string val = myReader.GetString(1);

                if (val[1] == 'G') {
                    int start = nthPos(val, ',', 2) + 1;
                    int end = nthPos(val, ',', 6);

                    string s = val.Substring(start, end - start);

                    lines.Add(CoordFromString(s));
                }
            }

            SetPath(lines);
        }

        private int nthPos(string hay, char needle, int n) {
            int index = 0;
            for (int i = 0; i <= n; index = hay.IndexOf(needle, index + 1), i++) {

            }

            return index;
        }
    }
}