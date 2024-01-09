using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class email_templateManager
    {
        private Iemail_template dal = null;
        public email_templateManager()
        {
            dal = BLLComm.GetClassInstance("email_template") as Iemail_template;
        }

        static readonly private email_templateManager _instance = new email_templateManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static email_templateManager Instance
        {
            get { return _instance; }
        }

        public int Operation(Object obj, string type)
        {
            return dal.Operation(obj, type);
        }
        public DataTable GetEmail_template(Object obj, string type)
        {
            return dal.GetEmail_template(obj, type);
        }
        public DataTable GetEmailTemplate(email_template model)
        {
            return dal.GetEmailTemplate(model);
        }
        public email_template GetModelById(int id)
        {
            return dal.GetModelById(id);
        }
    }
}
