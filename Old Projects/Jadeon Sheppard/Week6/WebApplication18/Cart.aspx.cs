using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace WebApplication18
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        const int GRID_COL_PCODE = 0;
        const int GRID_COL_PIC = 1;
        const int GRID_COL_DESC = 2;
        const int GRID_COL_PRIC = 3;
        const int GRID_COL_QTY = 4;
        const int GRID_COL_BTNS = 5;
        const int GRID_COL_TOTAL = 6;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ReadDataFromDB();

            CreateDynControls();
        }

        private void ReadDataFromDB()
        {
            List<string> ImageList = new List<string>();
            DataTable dt = new DataTable();
            dt.Columns.Add("BlockID");
            dt.Columns.Add("Picture");
            dt.Columns.Add("Name");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantity");
            dt.Columns.Add(" ");
            dt.Columns.Add("Total");

            
            string SQLString = "SELECT ID, Picture, BlockID, BlockName, Price, Basis FROM Products ORDER BY ID";

            OleDbConnection Con = DBHandler.Connect(this);

            OleDbCommand Cmd = new OleDbCommand(SQLString, Con);

            

            Cmd.Connection.Open();
            OleDbDataReader myReader = Cmd.ExecuteReader();

            while (myReader.Read())
            {
                DataRow dr = dt.NewRow();
                dr["BlockID"] = myReader.GetString(2);
                dr["Name"] = myReader.GetString(3) + " x" + myReader.GetInt32(5).ToString();
                dr["Price"] = myReader.GetDouble(4).ToString("0");
                dr["Quantity"] = "0";
                dr["Total"] = "0";
                ImageList.Add(myReader.GetString(1));
                dt.Rows.Add(dr);
            }
            myReader.Close();

            Con.Close();

            GridView1.DataSource = dt;
            GridView1.DataBind();

            Session["ImageList"] = ImageList;


        }

        private void CreateDynControls()
        {
            int index = 0;
            List<string> ImageList = (List<string>)Session["ImageList"];
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Button b = new Button();
                    b.Text = "+";
                    b.ID = "btnADD" + index.ToString("000");
                    b.Click += bCmd_Click;
                    row.Cells[GRID_COL_BTNS].Controls.Add(b);

                    b = new Button();
                    b.Text = "-";
                    b.ID = "btnDEL" + index.ToString("000");
                    b.Click += bCmd_Click;
                    row.Cells[GRID_COL_BTNS].Controls.Add(b);

                    Image i = new Image();
                    i.ImageUrl = ResolveUrl("~/images/") + ImageList[index];
                    row.Cells[GRID_COL_PIC].Controls.Add(i);

                    index++;
                }
            }

        }

        protected void bCmd_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt16(((Button)sender).ID.Substring(6, 3));
            int value = Convert.ToInt16(GridView1.Rows[index].Cells[GRID_COL_QTY].Text);

            if (((Button)sender).Text == "+")
                value++;
            else if (((Button)sender).Text == "-")
                value--;

            if (value < 0)
                value = 0;

            int total = int.Parse(GridView1.Rows[index].Cells[GRID_COL_PRIC].Text) * value;

            GridView1.Rows[index].Cells[GRID_COL_QTY].Text = value.ToString();
            GridView1.Rows[index].Cells[GRID_COL_TOTAL].Text = total.ToString();

            int gt = 0;

            foreach (GridViewRow row in GridView1.Rows) {
                gt += int.Parse(row.Cells[GRID_COL_TOTAL].Text);
            }

            lblGrandTotal.Text = gt.ToString();
        }


    }
}