using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class SeesionObject
    {
        private int userid;

        /// <summary>
        /// 登录用户的Id
        /// </summary>
        public int Userid
        {
            get { return userid; }
            set { userid = value; }
        }
        private string username;

        /// <summary>
        /// 登录用户名
        /// </summary>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
    }
}
