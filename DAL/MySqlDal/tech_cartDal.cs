using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Model;
using IDAL;
using DBHelper;
using Common;

namespace DAL.MySqlDal
{
    public class tech_cartDal : Itech_cart
    {
        public tech_cart GetTech_cart(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_cart info = new tech_cart();
            tech_cart model = new tech_cart();
            switch (type)
            {
                case "select_msg":
                    #region 查询支付基本信息
                    info = (tech_cart)obj;
                    sb.Append(" SELECT order_id,user_id,children_ids,total_fee,pay_type,`status`,inputtime,paytime,third_id ");
                    sb.Append(" FROM tech_cart ");
                    sb.Append(" WHERE `status`=1 ");
                    if (!string.IsNullOrEmpty(info.Order_id))
                    {
                        sb.AppendFormat(" AND order_id=\"{0}\" ", info.Order_id);
                    }
                    if (info.Total_fee>0)
                    {
                        sb.AppendFormat(" AND total_fee={0} ", info.Total_fee);
                    }
                    
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    if(dt!=null&&dt.Rows.Count>0)
                        model = MySQLHelper.ConvertTableToObject<tech_cart>(dt)[0];

                    #endregion
                    break;
            }
            return model;
        }
    }
}
