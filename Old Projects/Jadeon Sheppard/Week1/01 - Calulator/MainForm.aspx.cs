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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["Calc"] == null)
                ViewState["Calc"] = new CalcState();

            if (Session["Red"] == null)
                Session["Red"] = false;

            

            SetBG();
        }

        void SetBG()
        {
            if ((bool)Session["Red"])
                body.Attributes.Add("style", "background: #ff0000;");
            else
                body.Attributes.Add("style", "background: #666;");

            Button1.Text = (bool)Session["Red"] ? "Make Grey" : "Make Red";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Red"] = !(bool)Session["Red"];
            SetBG();
        }
    }
}