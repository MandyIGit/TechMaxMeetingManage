using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_person_printManager
    {
        private Itech_person_print dal = null;
        public tech_person_printManager()
        {
            dal = BLLComm.GetClassInstance("tech_person_print") as Itech_person_print;
        }

        static readonly private tech_person_printManager _instance = new tech_person_printManager();
        public static tech_person_printManager Instance
        {
            get { return _instance; }
        }

        public int Operation(Object obj, string type)
        {
            return dal.Operation(obj, type);
        }
        public DataTable Get_tech_person_print(Object obj, string type)
        {
            return dal.Get_tech_person_print(obj, type);
        }
        public DataTable GetTechPersonPrint(tech_person_print model)
        {
            return dal.GetTechPersonPrint(model);
        }
        public tech_person_print GetModelById(int id)
        {
            return dal.GetModelById(id);
        }
    }
}
