using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_mobile_templateManager
    {
        private Itech_mobile_template dal = null;
        public tech_mobile_templateManager()
        {
            dal = BLLComm.GetClassInstance("tech_mobile_template") as Itech_mobile_template;
        }

        static readonly private tech_mobile_templateManager _instance = new tech_mobile_templateManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_mobile_templateManager Instance
        {
            get { return _instance; }
        }

        public int Operation(Object obj, string type)
        {
            return dal.Operation(obj, type);
        }

        public tech_mobile_template GetModelByMTemplateId(string mtemplate_id)
        {
            return dal.GetModelByMTemplateId(mtemplate_id);
        }

        public DataTable GetTech_mobile_template(Object obj, string type)
        {
            return dal.GetTech_mobile_template(obj, type);
        }
    }
}
