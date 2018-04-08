using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Week3_Lab1
{
    public class PageCommon : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {

            if (Session["Theme"] == null)
                Theme = "Summer";
            else
                Theme = (string)Session["Theme"];

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}