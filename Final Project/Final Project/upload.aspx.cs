using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Final_Project {
    public partial class WebForm2 : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            if (fileDB.HasFile) {
                string path = MapPath("~/bin/dbs/");
                Directory.CreateDirectory(path);

                path += fileDB.FileName;

                fileDB.PostedFile.SaveAs(path);
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e) {

        }
    }
}