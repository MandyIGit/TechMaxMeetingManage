using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_admin
    {
        private int admin_code;

        public int Admin_code
        {
            get { return admin_code; }
            set { admin_code = value; }
        }

        private string admin_name;

        public string Admin_name
        {
            get { return admin_name; }
            set { admin_name = value; }
        }
        private string login_name;

        public string Login_name
        {
            get { return login_name; }
            set { login_name = value; }
        }

        private string login_pwd;

        public string Login_pwd
        {
            get { return login_pwd; }
            set { login_pwd = value; }
        }

        private int gender;

        public int Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private int admin_type;

        public int Admin_type
        {
            get { return admin_type; }
            set { admin_type = value; }
        }

        private DateTime lastlogin_time;

        public DateTime Lastlogin_time
        {
            get { return lastlogin_time; }
            set { lastlogin_time = value; }
        }

        private DateTime input_time;

        public DateTime Input_time
        {
            get { return input_time; }
            set { input_time = value; }
        }

        private string mtype_id;

        public string Mtype_id
        {
            get { return mtype_id; }
            set { mtype_id = value; }
        }

        private string mid;

        public string Mid
        {
            get { return mid; }
            set { mid = value; }
        }

        private DateTime operationtime;

        public DateTime Operationtime
        {
            get { return operationtime; }
            set { operationtime = value; }
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

        private string remark;  //备注信息

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private int errorTimes;

        public int ErrorTimes
        {
            get { return errorTimes; }
            set { errorTimes = value; }
        }

        private DateTime lastErrorDateTime;

        public DateTime LastErrorDateTime
        {
            get { return lastErrorDateTime; }
            set { lastErrorDateTime = value; }
        }
    }
}
