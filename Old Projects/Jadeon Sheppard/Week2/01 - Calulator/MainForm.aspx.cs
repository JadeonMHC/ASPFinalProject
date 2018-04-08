using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01___Calulator
{
    public partial class MainForm : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e) {

            if (Session["Theme"] == null)
                Theme = "Bliss";
            else
                Theme = (string)Session["Theme"];
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Theme"] == null)
                Session["Theme"] = "Bliss";

                if (ViewState["Calc"] == null)
                ViewState["Calc"] = new CalcState();

            if (Session["Red"] == null)
                Session["Red"] = false;

            Console.WriteLine(Session["Theme"]);

        }

        protected void NumButton_Click(object sender, EventArgs e)
        {
            txtInput.Text = ((CalcState)ViewState["Calc"]).DoNum(((Button)sender).Text);
        }

        protected void OpButton_Click(object sender, EventArgs e)
        {
            CalcState.Operator co = CalcState.Operator.Add;
            Button s = (Button)sender;

            if (s.ID == "btnAdd")
                co = CalcState.Operator.Add;
            else if (s.ID == "btnSub")
                co = CalcState.Operator.Sub;
            else if (s.ID == "btnMul")
                co = CalcState.Operator.Mul;
            else if (s.ID == "btnDiv")
                co = CalcState.Operator.Div;

            txtInput.Text = ((CalcState)ViewState["Calc"]).DoOperator(co);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ViewState["Calc"] = new CalcState();
            txtInput.Text = "";
        }

        protected void btnEqual_Click(object sender, EventArgs e)
        {
            txtInput.Text = ((CalcState)ViewState["Calc"]).DoEqual();
        }

        protected void btnBliss_Click(object sender, EventArgs e) {
            Session["Theme"] = "Bliss";
            Server.Transfer(Request.FilePath);
        }

        protected void btnBatman_Click(object sender, EventArgs e) {
            Session["Theme"] = "Batman";
            Server.Transfer(Request.FilePath);

        }

        protected void btnCube_Click(object sender, EventArgs e) {
            Session["Theme"] = "Portal";
            Server.Transfer(Request.FilePath);
        }
    }
}