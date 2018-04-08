using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week3_Lab1 {
    public partial class MasterPage : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnHusky_Click(object sender, EventArgs e) {
            Response.Redirect("/Husky.aspx");
        }

        protected void btnGoldendoodle_Click(object sender, EventArgs e) {
            Response.Redirect("/GoldenDoodle.aspx");
        }

        protected void btnSharpei_Click(object sender, EventArgs e) {
            Response.Redirect("/SharPei.aspx");
        }
    }
}