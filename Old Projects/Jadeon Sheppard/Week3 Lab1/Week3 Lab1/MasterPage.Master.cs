using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week3_Lab1 {
    public partial class MasterPage : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["Theme"] == null)
                btnTheme.Text = "Winter";
            else if ((string)Session["Theme"] == "Summer")
                btnTheme.Text = "Winter";
            else
                btnTheme.Text = "Summer";
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

        protected void btnTheme_Click(object sender, EventArgs e)
        {
            if (Session["Theme"] == null)
                Session["Theme"] = "Winter";
            else if ((string)Session["Theme"] == "Summer")
                Session["Theme"] = "Winter";
            else
                Session["Theme"] = "Summer";

            Server.Transfer(Request.FilePath);
        }
    }
}