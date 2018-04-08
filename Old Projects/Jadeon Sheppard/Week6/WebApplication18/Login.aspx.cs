using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication18 {
    public partial class WebForm2 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnSignup_Click(object sender, EventArgs e) {
            if (txtSignPass.Text != txtSignPass2.Text) {
                SignupMessageArea.InnerText = "The passwords don't match.";
            }
            else {
                string msg = UserHandler.AddUser(this, txtSignName.Text.ToLower(), txtSignPass.Text);

                if (msg.Length > 0) {
                    SignupMessageArea.InnerText = msg;
                }
                else {
                    Response.Redirect("/Cart.aspx");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e) {
            string msg = UserHandler.Login(this, txtLoginName.Text.ToLower(), txtLoginPass.Text);

            if (msg.Length > 0) {
                LoginMessageArea.InnerText = msg;
            }
            else {
                Response.Redirect("/Cart.aspx");
            }
        }
    }
}