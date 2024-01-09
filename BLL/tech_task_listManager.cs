using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tech_task_listManager
    {
        private Itech_task_list dal = null;
        public tech_task_listManager()
        {
            dal = BLLComm.GetClassInstance("tech_task_list") as Itech_task_list;
        }
        public static tech_task_listManager Instance
        {
            get { return _instance; }
        }

        static readonly private tech_task_listManager _instance = new tech_task_listManager();

        public int Operation(tech_task_list info, string type)
        {
            return dal.Operation(info, type);
        }

        public int GetTech_task_list_count(tech_task_list info)
        {
            return dal.GetTech_task_list_count(info);
        }

        public DataTable GetTech_task_list(tech_task_list info, int pageIndex, int pageSize)
        {
            return dal.GetTech_task_list(info, pageIndex, pageSize);
        }

        public DataTable GetTech_task_list(tech_task_list info)
        {
            return dal.GetTech_task_list(info);
        }

        public DataTable GetTech_task_list(tech_task_list info, string type)
        {
            return dal.GetTech_task_list(info, type);
        }

        public tech_task_list GetModel(string id)
        {
            return dal.GetModel(id);
        }
    }
}
