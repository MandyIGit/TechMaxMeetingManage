using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_published_formManager
    {
        private Itech_published_form dal = null;
        public tech_published_formManager()
        {
            dal = BLLComm.GetClassInstance("tech_published_form") as Itech_published_form;
        }

        static readonly private tech_published_formManager _instance = new tech_published_formManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_published_formManager Instance
        {
            get { return _instance; }
        }

        public int Operation(Object obj, string type)
        {
            return dal.Operation(obj, type);
        }
        public DataTable GetTech_published_form(Object obj, string type)
        {
            return dal.GetTech_published_form(obj, type);
        }
        public DataTable GetTechPublishedForm(tech_published_form model)
        {
            return dal.GetTechPublishedForm(model);
        }
        public tech_published_form GetModelById(int id)
        {
            return dal.GetModelById(id);
        }
    }
}
