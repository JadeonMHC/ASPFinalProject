using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week4_Lab2 {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            MainLogin.UserName = "CptAwesome";
        }
    }
}