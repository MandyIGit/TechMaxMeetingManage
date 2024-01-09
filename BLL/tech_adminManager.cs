using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_adminManager
    {
        private Itech_admin dal = null;
        public tech_adminManager()
        {
            dal = BLLComm.GetClassInstance("tech_admin") as Itech_admin;
        }

        static readonly private tech_adminManager _instance = new tech_adminManager();

        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_adminManager Instance
        {
            get { return _instance; }
        }

        public int Operation(Object obj, string type)
        {
            return dal.Operation(obj, type);
        }

        public tech_admin Login(string login_name, string login_pwd)
        {
            return dal.Login(login_name,login_pwd);
        }

        public tech_admin GetModel(int Admin_Code)
        {
            return dal.GetModel(Admin_Code);
        }

        public DataTable GetTech_admin(Object obj, string type)
        {
            return dal.GetTech_admin(obj, type);
        }

    }
}
