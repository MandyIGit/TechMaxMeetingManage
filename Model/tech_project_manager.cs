using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_project_manager
    {
        private int _id;
        private string _full_name;
        private string _login_name;
        private string _login_pwd;
        private string _mobile;
        private int _isdel;
        private DateTime _inputtime;
        private DateTime _operationtime;
        private DateTime _lastlogin_time;
        private int pageIndex;  //当前页数
        private int pageSize;  //每页显示记录数

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string full_name
        {
            get { return _full_name; }
            set { _full_name = value; }
        }

        public string login_name
        {
            get { return _login_name; }
            set { _login_name = value; }
        }

        public string login_pwd
        {
            get { return _login_pwd; }
            set { _login_pwd = value; }
        }

        public string mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
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

        public DateTime operationtime
        {
            get { return _operationtime; }
            set { _operationtime = value; }
        }

        public DateTime lastlogin_time
        {
            get { return _lastlogin_time; }
            set { _lastlogin_time = value; }
        }

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }
    }
}
