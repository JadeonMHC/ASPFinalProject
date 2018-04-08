using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebApplication27
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ServiceReference1.WebService1SoapClient WS;

        protected void Page_Load(object sender, EventArgs e)
        {
            WS = new ServiceReference1.WebService1SoapClient();
        }

        int? GetNumber(string s) {
            try {
                return int.Parse(s);
            }
            catch (Exception) {
                return null;
            }
        }

        protected void btnCount_Click(object sender, EventArgs e) {
            int c = WS.numEntries();

            lblNumEntries.Text = "There are " + c.ToString() + " entries.";
        }

        protected void btnGetEntry_Click(object sender, EventArgs e) {
            int? num = GetNumber(txtGetBox.Text);

            if (!num.HasValue)
                lblGetValue.Text = "Not a number.";
            else {
                int? v = WS.valAt(num.Value);

                if (v.HasValue)
                    lblGetValue.Text = "Entry #" + num.Value.ToString() + " is " + v.Value.ToString();
                else
                    lblGetValue.Text = "Index out of bounds.";
            }
        }

        protected void btnSet_Click(object sender, EventArgs e) {
            int? i = GetNumber(txtSetIndex.Text);
            int? v = GetNumber(txtSetValue.Text);

            if (!i.HasValue || !v.HasValue) {
                lblSetM.Text = "Both fields must be numbers.";
                lblSetM.ForeColor = Color.Red;
            }
            else {
                int? r = WS.setVal(i.Value, v.Value);

                lblSetM.Text = r.HasValue ? "Success" : "Failure";
                lblSetM.ForeColor = r.HasValue ? Color.Green : Color.Red;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e) {
            int? v = GetNumber(txtAdd.Text);

            if (!v.HasValue) {
                lblAddM.Text = "Must be a number.";
            }
            else {
                int? r = WS.newEntry(v.Value);

                if (r.HasValue) {
                    lblAddM.Text = r.HasValue ? "Added successfully" : "Some error has ocurred";
                }

            }
        }
    }
}