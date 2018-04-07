using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;

using Newtonsoft.Json;

namespace Final_Project {
    public partial class DBData : System.Web.UI.Page {
        public static string DBPath(Page p)
        {
            string path = p.MapPath("~/app_data/dbs/");
            Directory.CreateDirectory(path);
            return path;
        }

        protected void Page_Load(object sender, EventArgs e) {
            string action = Request.Form["action"];

            if (action == "list_sources")
            {
                string[] tmp_databases = Directory.GetFiles(DBPath(this));
                List<string> dbpaths = new List<string>();

                foreach (string db in tmp_databases)
                {
                    string[] parts = db.Split('.');

                    if (parts[parts.Length - 1] == "mdb")
                    {
                        string[] pp = db.Split('\\');
                        dbpaths.Add(pp[pp.Length - 1].Split('.')[0]);
                    }
                }

                Response.Write(JsonConvert.SerializeObject(dbpaths));
            }
            else if (action == "get_db")
            {
                string path = DBPath(this) + Request.Form["name"] + ".mdb";
                string ConString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
                OleDbConnection con = new OleDbConnection(ConString);

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Data", con);
                cmd.Connection.Open();

                OleDbDataReader r = cmd.ExecuteReader();

                List<List<object>> rows = new List<List<object>>();

                while (r.Read())
                {
                    List<object> ao = new List<object>();

                    for (int i = 0; i < r.FieldCount; i++)
                    {
                        ao.Add(r.GetValue(i));
                    }

                    rows.Add(ao);
                }

                Response.Write(JsonConvert.SerializeObject(rows));
            }
        }
    }
}