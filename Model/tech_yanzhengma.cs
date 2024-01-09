using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_yanzhengma
    {
        public int id { get; set; }
        public string mobile { get; set; }
        public int yanzhengma { get; set; }
        public int isdel { get; set; }
        public DateTime inputtime { get; set; }
        public DateTime operatingtime { get; set; }

        public string mid { get; set; }

        public string mtype_id { get; set; }
    }
}
