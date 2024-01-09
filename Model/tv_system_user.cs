using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    [Serializable()]
    public class tv_system_user
    {
        private int sys_code;  //管理员ID
        private string sys_name;  //管理员姓名
        private string login_id;  //登录ID
        private string login_pwd;  //登录密码
        private string sys_mobile;  //管理员手机
        private int isdel;  //状态(1-已删除,2-正常)
        private DateTime inputtime;  //录入时间
        private DateTime add_date;  //添加时间
        private int system_level;  //级别名称
        private string mid;     //会议mid

        /// <summary>
        /// 会议mid
        /// </summary>
        public string Mid
        {
            get { return mid; }
            set { mid = value; }
        }

        /// <summary>
        /// 级别名称
        /// </summary>
        public int System_level
        {
            get { return system_level; }
            set { system_level = value; }
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Add_date
        {
            get { return add_date; }
            set { add_date = value; }
        }

        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime Inputtime
        {
            get { return inputtime; }
            set { inputtime = value; }
        }

        /// <summary>
        /// 状态(1-已删除,2-正常)
        /// </summary>
        public int Isdel
        {
            get { return isdel; }
            set { isdel = value; }
        }

        /// <summary>
        /// 管理员手机
        /// </summary>
        public string Sys_mobile
        {
            get { return sys_mobile; }
            set { sys_mobile = value; }
        }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Login_pwd
        {
            get { return login_pwd; }
            set { login_pwd = value; }
        }

        /// <summary>
        /// 登录ID
        /// </summary>
        public string Login_id
        {
            get { return login_id; }
            set { login_id = value; }
        }

        /// <summary>
        /// 管理员姓名
        /// </summary>
        public string Sys_name
        {
            get { return sys_name; }
            set { sys_name = value; }
        }

        /// <summary>
        /// 管理员ID
        /// </summary>
        public int Sys_code
        {
            get { return sys_code; }
            set { sys_code = value; }
        }
    }
}
