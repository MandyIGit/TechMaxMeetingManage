using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_article_typeManager
    {
        private Itech_article_type dal = null;
        public tech_article_typeManager()
        {
            dal = BLLComm.GetClassInstance("tech_article_type") as Itech_article_type;
        }

        static readonly private tech_article_typeManager _instance = new tech_article_typeManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_article_typeManager Instance
        {
            get { return _instance; }
        }

        public int Operation(Object obj, string type)
        {
            return dal.Operation(obj, type);
        }
        public DataTable GetTech_article_type(Object obj, string type)
        {
            return dal.GetTech_article_type(obj, type);
        }
        public DataTable GetTechArticleType(tech_article_type model)
        {
            return dal.GetTechArticleType(model);
        }
        public tech_article_type GetModelById(int id)
        {
            return dal.GetModelById(id);
        }
    }
}
