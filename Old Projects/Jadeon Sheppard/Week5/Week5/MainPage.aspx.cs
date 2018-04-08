using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Week5 {
    public partial class MainPage : System.Web.UI.Page {
        int[] WinStates = new int[]{
            73, 146, 292,
            7, 56, 448,
            273, 84
        };

        private HtmlGenericControl Status;
        private HtmlGenericControl[] Rows = new HtmlGenericControl[3];

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Session["cTurn"] = "X";
                Session["X"] = 0;
                Session["O"] = 0;
            }

            BODY.Style.Add("background", "#999");

            TicTacBox.Style.Add("width", "300px");
            TicTacBox.Style.Add("height", "300px");
            TicTacBox.Style.Add("display", "flex");
            TicTacBox.Style.Add("flex-direction", "column");
            TicTacBox.Style.Add("position", "absolute");
            TicTacBox.Style.Add("left", "50vw");
            TicTacBox.Style.Add("top", "50vh");
            TicTacBox.Style.Add("margin-left", "-150px");
            TicTacBox.Style.Add("margin-top", "-150px");

            for (int r = 0; r < 3; r++) {
                HtmlGenericControl nc = new HtmlGenericControl("div");
                nc.Style.Add("display", "flex");
                nc.Style.Add("flex-direction", "row");
                nc.Style.Add("flex", "2");

                TicTacBox.Controls.Add(nc);
                Rows[r] = nc;

                for (int c = 0; c < 3; c++) {
                    Button nb = new Button();

                    nb.Style.Add("flex", "2");
                    nb.Style.Add("font-family", "Arial Black");
                    nb.Style.Add("font-size", "60px");
                    nb.Click += ButtonPlay;

                    nb.ID = ((int)Math.Pow(2, r * 3 + c)).ToString();


                    nc.Controls.Add(nb);
                }
            }


            HtmlGenericControl head = new HtmlGenericControl("div");
            head.Style.Add("height", "50px");
            head.Style.Add("width", "300px");
            head.Style.Add("position", "absolute");
            head.Style.Add("top", "-50px");
            head.Style.Add("left", "0px");
            head.Style.Add("text-align", "center");
            head.Style.Add("font-family", "Arial Black");
            head.Style.Add("font-size", "40px");

            head.InnerHtml = "Tic-Tac-Too";

            TicTacBox.Controls.Add(head);


            Status = new HtmlGenericControl("div");
            Status.ID = "SB";
            Status.Style.Add("height", "30px");
            Status.Style.Add("width", "200px");
            Status.Style.Add("position", "absolute");
            Status.Style.Add("bottom", "-30px");
            Status.Style.Add("left", "0px");

            Status.InnerHtml = (string)Session["cTurn"] + "'s turn.";

            TicTacBox.Controls.Add(Status);


            Button NGB = new Button();

            NGB.Text = "New Game";
            NGB.Style.Add("height", "30px");
            NGB.Style.Add("width", "100px");
            NGB.Style.Add("position", "absolute");
            NGB.Style.Add("bottom", "-30px");
            NGB.Style.Add("right", "0px");

            NGB.Click += NewGame;

            TicTacBox.Controls.Add(NGB);
        }

        private void ButtonPlay(object sender, EventArgs e) {
            Button s = (Button)sender;
            if (s.Text == "") {
                string ct = (string)Session["cTurn"];
                s.Enabled = false;

                s.Text = ct;
                Session[ct] = (int)Session[ct] + int.Parse(s.ID);

                Session["cTurn"] = (ct == "X") ? "O" : "X";

                bool HasWin = false;
                int WinState = 0;

                foreach (int ws in WinStates) {
                    if (((int)Session[ct] & ws) == ws) {
                        HasWin = true;
                        WinState = ws;
                        break;
                    }
                }

                Status.InnerHtml = (string)Session["cTurn"] + "'s turn.";

                if (HasWin) {
                    foreach (HtmlGenericControl c in Rows) {
                        foreach (Button b in c.Controls) {
                            if ((WinState & int.Parse(b.ID)) == int.Parse(b.ID)) {
                                b.BackColor = System.Drawing.Color.AliceBlue;
                            }

                            b.Enabled = false;
                        }
                    }

                    Status.InnerHtml = ct + " wins!";
                }
            }
        }

        private void NewGame(object sender, EventArgs e) {
            Response.Redirect("/MainPage.aspx");
        }
    }
}