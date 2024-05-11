using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace coffee_ticket.Models
{
    public class Site
    {
        public string id { get; set; }
        public string name { get; set; }
        public string ip { get; set; }
        public Site(string id, string name, string ip)
        {
            this.id = id;
            this.name = name;
            this.ip = ip;
        }
    }

}
