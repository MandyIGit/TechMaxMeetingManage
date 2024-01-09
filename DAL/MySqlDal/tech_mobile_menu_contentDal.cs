using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Model;
using IDAL;
using DBHelper;
using Common;

namespace DAL.MySqlDal
{
    public class tech_mobile_menu_contentDal : Itech_mobile_menu_content
    {

        public int ModifyModel(tech_mobile_menu_content model)
        {
            StringBuilder sb = new StringBuilder();
            if (model.mc_id == 0)
            {
                sb.Append("insert into tech_mobile_menu_content (mc_title,mc_msg,menu_id,inputtime) values ");
                sb.AppendFormat("('{0}','{1}','{2}','{3}')", model.mc_title, model.mc_msg, model.menu_id, model.inputtime);
            }
            else
            {
                sb.Append("update tech_mobile_menu_content set ");
                sb.AppendFormat("mc_title='{0}',mc_msg='{1}',menu_id='{2}'", model.mc_title, model.mc_msg, model.menu_id);
                sb.AppendFormat(" where mc_id={0}", model.mc_id);
            }
            int i = Convert.ToInt32(MySQLHelper.ExecuteNonQuery(sb.ToString()));
            return i;
        }

        public DataTable GetTech_mobile_menu_content(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_mobile_menu_content info = new tech_mobile_menu_content();
            switch (type)
            {
                case "select_mobile_menu_content":
                    #region 查询mobile_menu_content信息
                    info = (tech_mobile_menu_content)obj;
                    sb.Append("SELECT * FROM tech_mobile_menu_content WHERE isdel=2 ");
                    
                    if (info.menu_id > 0)
                    {
                        sb.AppendFormat(" AND menu_id = {0} ", info.menu_id);
                    }

                    sb.Append(" ORDER BY mc_id ASC ");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }

        public tech_mobile_menu_content GetModelByMcId(string mc_id)
        {
            tech_mobile_menu_content mobile_menu_content = null;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select * from tech_mobile_menu_content where mc_id={0} ", mc_id);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                mobile_menu_content = MySQLHelper.ConvertTableToObject<tech_mobile_menu_content>(dt)[0];
            }
            return mobile_menu_content;
        }

    }
}
