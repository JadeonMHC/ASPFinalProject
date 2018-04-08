using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Midterm {
    public partial class MainMaster : System.Web.UI.MasterPage {
        public Button themeButton() {
            return btnTheme;
        }

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnTheme_Click(object sender, EventArgs e) {
            ((GenericPage)Page).ToggleTheme();
        }
    }
}