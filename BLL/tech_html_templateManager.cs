using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_html_templateManager
    {
        private Itech_html_template dal = null;
        public tech_html_templateManager()
        {
            dal = BLLComm.GetClassInstance("tech_html_template") as Itech_html_template;
        }

        static readonly private tech_html_templateManager _instance = new tech_html_templateManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_html_templateManager Instance
        {
            get { return _instance; }
        }

        public int Operation(Object obj, string type)
        {
            return dal.Operation(obj, type);
        }
        public DataTable GetTech_html_template(Object obj, string type)
        {
            return dal.GetTech_html_template(obj, type);
        }
        public DataTable GetTechHtmlTemplate(tech_html_template model)
        {
            return dal.GetTechHtmlTemplate(model);
        }
        public tech_html_template GetModelByTId(int t_id)
        {
            return dal.GetModelByTId(t_id);
        }
        public string Get_tm_id()
        {
            return dal.Get_tm_id();
        }
    }

}
