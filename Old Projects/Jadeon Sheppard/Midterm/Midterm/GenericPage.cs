using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Midterm {
    public class GenericPage : Page {
        const string CookieName = "HTNENIFTheme";

        protected void Page_PreInit(object sender, EventArgs e) {
            HttpCookie cookie = Request.Cookies[CookieName];

            if (cookie == null) {
                cookie = new HttpCookie(CookieName, "light");
                Response.Cookies.Add(cookie);
            }
            else if (cookie.Value != "light" && cookie.Value != "dark") {
                cookie.Value = "light";
            }
            
            Theme = cookie.Value;

            ((MainMaster)Master).themeButton().Text = (cookie.Value == "light") ? "Dark" : "Light";
        }

        public void ToggleTheme() {
            if (Request.Cookies[CookieName].Value == "light")
                Response.Cookies.Add(new HttpCookie(CookieName, "dark"));
            else
                Response.Cookies.Add(new HttpCookie(CookieName, "light"));

            Response.Redirect(Request.RawUrl);
        }
    }
}