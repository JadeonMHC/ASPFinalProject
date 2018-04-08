using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Midterm {
    public partial class WebForm3 : GenericPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
                Response.Redirect(Request.RawUrl);

            Button subButton = new Button();
            subButton.Text = "Lookup Product";
            subButton.Click += SubButton_Click;

            SubmitArea.Controls.Add(subButton);
        }

        private void SubButton_Click(object sender, EventArgs e) {
            Label lab = new Label();
            lab.Text = "Found!";

            SubmitArea.Controls.Add(lab);
        }
    }
}