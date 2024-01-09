using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_project_managerManager
    {
        private Itech_project_manager dal = null;

        public tech_project_managerManager()
        {
            dal = BLLComm.GetClassInstance("tech_project_manager") as Itech_project_manager;
        }

        static readonly private tech_project_managerManager _instance = new tech_project_managerManager();

        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_project_managerManager Instance
        {
            get { return _instance; }
        }

        public int Operation(Object obj, string type)
        {
            return dal.Operation(obj, type);
        }

        public DataTable GetTech_project_manager(Object obj, string type)
        {
            return dal.GetTech_project_manager(obj, type);
        }

        public tech_project_manager Login(string login_name, string login_pwd)
        {
            return dal.Login(login_name, login_pwd);
        }

        public tech_project_manager GetModelById(string id)
        {
            return dal.GetModelById(id);
        }
    }
}
