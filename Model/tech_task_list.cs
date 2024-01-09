using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_task_list
    {
        public int id { get; set; }
        public string meeting_hall { get; set; }
        public string session_name { get; set; }
        public DateTime begin_time { get; set; }
        public DateTime end_time { get; set; }
        public string role_name { get; set; }
        public string full_name { get; set; }
        public string mobile { get; set; }
        public string task_title { get; set; }
        public string mid { get; set; }
        public string mtype_id { get; set; }

        private int _pageIndex;  //当前页数

        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }

        private int _pageSize;  //每页显示记录数

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }
    }
}
