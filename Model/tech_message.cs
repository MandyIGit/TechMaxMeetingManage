using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_message
    {
        public int id { get; set; }
        public string Contacts { get; set; }
        public string UnitName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Intention { get; set; }
        public string Content { get; set; }
        public DateTime Inputtime { get; set; }
        public DateTime Operatingtime { get; set; }
        public int Status { get; set; }
        public int UnitType { get; set; }
        public string MeetingNeed { get; set; }
        public string MeetingScale { get; set; }
        public DateTime MeetingStartTime { get; set; }
        public int isComm { get; set; }
        public string CommProgress { get; set; }
        public string Remark { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
