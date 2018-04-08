using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data.OleDb;

namespace Week9 {
    public partial class API : System.Web.UI.Page {
        public OleDbConnection Connect() {
            string DBPath = "~/app_data/data.accdb";
            string ConString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" + MapPath(DBPath);
            return new OleDbConnection(ConString);
        }

        protected void Page_Load(object sender, EventArgs e) {
            List<Dictionary<string, string>> ts = new List<Dictionary<string, string>>();

            string SQLString = "SELECT html FROM Slides ORDER BY ID";

            OleDbConnection Con = Connect();
            OleDbCommand Cmd = new OleDbCommand(SQLString, Con);

            Cmd.Connection.Open();
            OleDbDataReader myReader = Cmd.ExecuteReader();

            while (myReader.Read()) {
                ts.Add(new Dictionary<string, string> {
                    { "html", myReader.GetString(0) }
                });
            }

                

            string ob = JsonConvert.SerializeObject(ts);
            Response.Write(ob);
        }
    }
}