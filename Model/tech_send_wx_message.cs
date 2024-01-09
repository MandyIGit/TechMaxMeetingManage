using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_send_wx_message
    {
        public int id { get; set; }
        public string keyword1 { get; set; }
        public string keyword2 { get; set; }
        public string keyword3 { get; set; }
        public string keyword4 { get; set; }
        public string keyword5 { get; set; }

        public string weburl { get; set; }
        public string tagGroup { get; set; }

        public DateTime sendTime { get; set; }

        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
