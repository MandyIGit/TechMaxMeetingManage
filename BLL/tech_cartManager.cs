using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using Model;

namespace BLL
{
    public class tech_cartManager
    {
        private Itech_cart dal = null;
        public tech_cartManager()
        {
            dal = BLLComm.GetClassInstance("tech_cart") as Itech_cart;
        }
        public static tech_cartManager Instance
        {
            get { return _instance; }
        }

        static readonly private tech_cartManager _instance = new tech_cartManager();

        public tech_cart GetTech_cart(object obj, string type)
        {
            return dal.GetTech_cart(obj, type);
        }
    }
}
