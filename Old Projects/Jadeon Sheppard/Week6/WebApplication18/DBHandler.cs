using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.OleDb;

namespace WebApplication18 {
    public class DBHandler {
        public static OleDbConnection Connect(Page p) {
            string DBPath = "~/app_data/shopping.accdb";//Server.MapPath(fname);
            string ConString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" + p.MapPath(DBPath);
            return new OleDbConnection(ConString);
        }
    }
}