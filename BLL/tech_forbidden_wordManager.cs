using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tech_forbidden_wordManager
    {
        private Itech_forbidden_word dal = null;
        public tech_forbidden_wordManager()
        {
            dal = BLLComm.GetClassInstance("tech_forbidden_word") as Itech_forbidden_word;
        }

        static readonly private tech_forbidden_wordManager _instance = new tech_forbidden_wordManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_forbidden_wordManager Instance
        {
            get { return _instance; }
        }


        public int Operation(Object obj, string type)
        {
            return dal.Operation(obj, type);
        }

        public DataTable GetWord(tech_forbidden_word info)
        {
            return dal.GetWord(info);
        }

        public tech_forbidden_word GetWordByID(string id)
        {
            return dal.GetWordByID(id);
        }

    }
}
