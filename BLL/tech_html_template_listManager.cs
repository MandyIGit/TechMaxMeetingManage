using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_html_template_listManager
    {
        private Itech_html_template_list dal = null;
        public tech_html_template_listManager()
        {
            dal = BLLComm.GetClassInstance("tech_html_template_list") as Itech_html_template_list;
        }

        static readonly private tech_html_template_listManager _instance = new tech_html_template_listManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_html_template_listManager Instance
        {
            get { return _instance; }
        }

        public int Operation(Object obj, string type)
        {
            return dal.Operation(obj, type);
        }
        public DataTable GetTech_html_template_list(Object obj, string type)
        {
            return dal.GetTech_html_template_list(obj, type);
        }
        public DataTable GetTechHtmlTemplateList(tech_html_template_list model)
        {
            return dal.GetTechHtmlTemplateList(model);
        }
        public tech_html_template_list GetModelByMId(string mid)
        {
            return dal.GetModelByMId(mid);
        }
        public string Get_tm_id()
        {
            return dal.Get_tm_id();
        }

    }
}
