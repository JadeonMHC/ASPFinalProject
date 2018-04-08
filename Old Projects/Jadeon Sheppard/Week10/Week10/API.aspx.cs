using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

using Newtonsoft.Json;

namespace Week10
{
    public partial class API : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";

            HttpRequest req = Request;
            var a = req.Form;

            DBO db = GetDB();

            if (a["action"] == "addEvent")
            {
                Event ne = new Event();
                ne.date = a["date"];
                ne.title = a["title"];
                ne.icon = a["icon"];
                ne.description = a["desc"];
                ne.time = a["time"];

                db.events.Add(ne);

                Response.Write("{\"success\":true}");
            }
            else if (a["action"] == "editEvent")
            {
                int index = -1;
                for (int i = 0; i < db.events.Count; i++)
                {
                    if (db.events[i].id == a["id"])
                    {
                        index = i;
                        break;
                    }
                }

                if (index != -1)
                {
                    db.events[index].date = a["date"];
                    db.events[index].title = a["title"];
                    db.events[index].icon = a["icon"];
                    db.events[index].description = a["desc"];
                    db.events[index].time = a["time"];
                }


                Response.Write("{\"success\":true}");
            }
            else if (a["action"] == "deleteEvent")
            {
                for (int i = 0; i < db.events.Count; i++)
                {
                    if (db.events[i].id == a["id"])
                    {
                        db.events.RemoveAt(i);
                        break;
                    }
                }

                Response.Write("{\"success\":true}");
            }
            else if (a["action"] == "getDB")
            {
                Response.Write(SerializeDB(db));
            }

            SaveDB(db);
        }

        private string fp()
        {
            return MapPath("db.json");
        }

        DBO GetDB()
        {
            if (File.Exists(fp()))
            {
                JsonSerializer ser = new JsonSerializer();
                return ser.Deserialize<DBO>(new JsonTextReader(new StringReader(File.ReadAllText(fp()))));
            }
            else
                return new DBO();
        }

        void SaveDB(DBO db)
        {
            File.WriteAllText(fp(), SerializeDB(db));
        }

        string SerializeDB(DBO db)
        {
            JsonSerializer ser = new JsonSerializer();
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            JsonTextWriter jr = new JsonTextWriter(sw);

            ser.Serialize(jr, db);

            return sb.ToString();
        }

       

    }
}