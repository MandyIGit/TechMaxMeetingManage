using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_mobile_menu_contentManager
    {
        private Itech_mobile_menu_content dal = null;
        public tech_mobile_menu_contentManager()
        {
            dal = BLLComm.GetClassInstance("tech_mobile_menu_content") as Itech_mobile_menu_content;
        }

        static readonly private tech_mobile_menu_contentManager _instance = new tech_mobile_menu_contentManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_mobile_menu_contentManager Instance
        {
            get { return _instance; }
        }

        public int ModifyModel(tech_mobile_menu_content model)
        {
            return dal.ModifyModel(model);
        }

        public DataTable GetTech_mobile_menu_content(Object obj, string type)
        {
            return dal.GetTech_mobile_menu_content(obj, type);
        }

        public tech_mobile_menu_content GetModelByMcId(string mc_id)
        {
            return dal.GetModelByMcId(mc_id);
        }
    }
}
