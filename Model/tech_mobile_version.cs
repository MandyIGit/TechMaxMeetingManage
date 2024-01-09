using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class tech_mobile_version
    {
        private int _v_id;
        private string _v_name;
        private int _sort;
        private int _isdel;
        private DateTime _inputtime;
        private int _menu_type;

        private int pageIndex;  //当前页数
        private int pageSize;  //每页显示记录数

        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }        

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        public int v_id
        {
            get { return _v_id; }
            set { _v_id = value; }
        }

        public string v_name
        {
            get { return _v_name; }
            set { _v_name = value; }
        }

        public int sort
        {
            get { return _sort; }
            set { _sort = value; }
        }

        public int isdel
        {
            get { return _isdel; }
            set { _isdel = value; }
        }

        public DateTime inputtime
        {
            get { return _inputtime; }
            set { _inputtime = value; }
        }

        public int menu_type
        {
            get { return _menu_type; }
            set { _menu_type = value; }
        }
    }
}
