using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Week10
{
    public class DBO
    {
        public List<Event> events;
    }

    public class Event
    {
        public string id;
        public string date;
        public string time;
        public string icon;
        public string title;
        public string description;

        public Event()
        {
            id = System.Guid.NewGuid().ToString();
        }
    }
}