using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace coffee_ticket.Models
{
    public class Coffee
    {
        public int id { get; set; }
        public string site_id { get; set; }
        public string site_type { get; set; }
        public DateTime setup_time { get; set; }
        public DateTime download_time { get; set; }
        public string status { get; set; }
        public string memo { get; set; }    
        public DateTime crt_time { get; set; }

        public Coffee(string site_id, string site_type, DateTime setup_time, DateTime download_time, string memo)
        {
            this.site_id = site_id;
            this.site_type = site_type;
            this.setup_time = setup_time;
            this.download_time = download_time;
            this.memo = memo;
        }
    }
}
