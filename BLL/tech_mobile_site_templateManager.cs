using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_mobile_site_templateManager
    {
        private Itech_mobile_site_template dal = null;
        public tech_mobile_site_templateManager()
        {
            dal = BLLComm.GetClassInstance("tech_mobile_site_template") as Itech_mobile_site_template;
        }

        static readonly private tech_mobile_site_templateManager _instance = new tech_mobile_site_templateManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_mobile_site_templateManager Instance
        {
            get { return _instance; }
        }


        public int Operation(Object obj, string type)
        {
            return dal.Operation(obj, type);
        }

        public DataTable GetTech_mobile_site_template(Object obj, string type)
        {
            return dal.GetTech_mobile_site_template(obj, type);
        }

        public tech_mobile_site_template GetModelByTemplateId(string id)
        {
            return dal.GetModelByTemplateId(id);
        }

    }
}
