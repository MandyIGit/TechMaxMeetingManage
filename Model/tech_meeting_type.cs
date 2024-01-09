using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_meeting_type
    {
        private string mtype_id;

        public string Mtype_id
        {
            get { return mtype_id; }
            set { mtype_id = value; }
        }

        private string mtype_name;

        public string Mtype_name
        {
            get { return mtype_name; }
            set { mtype_name = value; }
        }

        private string mtype_memo;

        public string Mtype_memo
        {
            get { return mtype_memo; }
            set { mtype_memo = value; }
        }

        private int v_sid;

        public int V_sid
        {
            get { return v_sid; }
            set { v_sid = value; }
        }

        private int isdel;

        public int Isdel
        {
            get { return isdel; }
            set { isdel = value; }
        }

        private DateTime inputtime;

        public DateTime Inputtime
        {
            get { return inputtime; }
            set { inputtime = value; }
        }

        private int pageIndex;  //当前页数

        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        private int pageSize;  //每页显示记录数

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
    }
}
