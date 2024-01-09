using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_yanzhengmaManager
    {
        private Itech_yanzhengma dal = null;

        public tech_yanzhengmaManager()
        {
            dal = BLLComm.GetClassInstance("tech_yanzhengma") as Itech_yanzhengma;
        }

        static readonly private tech_yanzhengmaManager _instance = new tech_yanzhengmaManager();

        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_yanzhengmaManager Instance
        {
            get { return _instance; }
        }

        public int Operation(tech_yanzhengma info, string type)
        {
            return dal.Operation(info, type);
        }

        public DataTable GetTech_yanzhengma(tech_yanzhengma info)
        {
            return dal.GetTech_yanzhengma(info);
        }

        public tech_yanzhengma getModel(string mobile, int yanzhengma)
        {
            return dal.getModel(mobile, yanzhengma);
        }
    }
}
