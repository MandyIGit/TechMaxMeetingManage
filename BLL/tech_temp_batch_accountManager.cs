using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_temp_batch_accountManager
    {
        private Itech_temp_batch_account dal = null;
        public tech_temp_batch_accountManager()
        {
            dal = BLLComm.GetClassInstance("tech_temp_batch_account") as Itech_temp_batch_account;
        }

        static readonly private tech_temp_batch_accountManager _instance = new tech_temp_batch_accountManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_temp_batch_accountManager Instance
        {
            get { return _instance; }
        }
        public int Operation(object obj, string type)
        {
            return dal.Operation(obj, type);
        }
        public List<tech_temp_batch_account> GetTechTempBatchAccount()
        {
            return dal.GetTechTempBatchAccount();
        }
        public tech_temp_batch_account GetModelByOrderId(string order_id)
        {
            return dal.GetModelByOrderId(order_id);
        }
    }
}
