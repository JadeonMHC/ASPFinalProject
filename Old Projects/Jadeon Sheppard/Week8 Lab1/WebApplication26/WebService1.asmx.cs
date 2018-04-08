using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.OleDb;

namespace WebApplication26
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://localhost/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        public OleDbConnection Connect() {
            string DBPath = System.Web.Hosting.HostingEnvironment.MapPath("~/app_data/data.mdb");
            string ConString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" + DBPath;
            return new OleDbConnection(ConString);
        }

        [WebMethod]
        public int numEntries() {
            OleDbConnection c = Connect();
            OleDbCommand Cmd = new OleDbCommand("SELECT COUNT(*) FROM Data", c);

            Cmd.Connection.Open();
            OleDbDataReader myReader = Cmd.ExecuteReader();
            myReader.Read();

            return myReader.GetInt32(0);
        }

        [WebMethod]
        public int? valAt(int i) {
            try {
                OleDbConnection c = Connect();
                OleDbCommand Cmd = new OleDbCommand("SELECT * FROM Data WHERE ID=" + (i + 1).ToString(), c);

                Cmd.Connection.Open();
                OleDbDataReader myReader = Cmd.ExecuteReader();
                myReader.Read();

                return myReader.GetInt32(1);
            }
            catch (Exception e) {
                return null;
            }
        }
     
        [WebMethod]
        public int? setVal(int i, int v) {
            OleDbConnection c = Connect();
            OleDbCommand Cmd = new OleDbCommand("UPDATE Data SET val=" + v.ToString() + " WHERE ID = " + (i + 1).ToString(), c);
            Cmd.Connection.Open();

            int rows = Cmd.ExecuteNonQuery();

            if (rows == 0)
                return null;
            else
                return v;
            
        }

        [WebMethod]
        public int? newEntry(int v) {
            OleDbConnection c = Connect();
            OleDbCommand Cmd = new OleDbCommand("INSERT INTO Data (val) VALUES (" + v.ToString() + ")", c);
            Cmd.Connection.Open();

            int rows = Cmd.ExecuteNonQuery();

            if (rows == 0)
                return null;
            else
                return v;
        }
    }
}
