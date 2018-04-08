using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week4_Lab_1 {
    public partial class MainForm : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            Response.Redirect("/success.html");
        }
    }
}