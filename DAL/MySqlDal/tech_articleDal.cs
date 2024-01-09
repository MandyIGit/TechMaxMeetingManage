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

namespace TechMaxDAL.MySqlDal
{
    /// <summary>
    /// 学术论文表数据访问类
    /// Jacky
    /// 2014-11-11
    /// </summary>
    public class tech_articleDal : Itech_article
    {
        //private string mid = Common.ConfigHelper.GetConfigString("Mcode");
        //private string mtype_id = Common.ConfigHelper.GetConfigString("MType");

        //private string mid = "HY1038";
        //private string mtype_id = "MT1027";

        #region 学术论文查询条件SQL语句
        /// <summary>
        /// 方法说明：学术论文查询条件SQL语句
        /// 创建人员：Jacky
        /// 创建日期：2014/11/13 9:07
        /// 修改日期：
        /// </summary>
        /// <param name="info">条件信息</param>
        /// <returns>SQL语句</returns>
        private string GetArticleSQL(tech_article info)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(info.Article_id))
            {
                sb.AppendFormat(" AND tae.article_id='{0}' ", info.Article_id);
            }
            if (info.Publisher != 0)
            {
                sb.AppendFormat(" AND tae.publisher='{0}' ", info.Publisher);
            }
            if (info.Nationality != 0)
            {
                sb.AppendFormat(" AND tae.nationality={0} ", info.Nationality);
            }
            if (!string.IsNullOrEmpty(info.User_name))
            {
                sb.AppendFormat(" AND CONCAT(tua.given_name,' ',tua.family_name) LIKE '%{0}%' ", info.User_name);
            }
            if (info.Isexpert!=0)
            {
                sb.AppendFormat(" AND tae.isexpert={0} ", info.Isexpert);
            }
            if (info.P_form != 0 && info.P_form != 9999)
            {
                sb.AppendFormat(" AND tae.p_form={0} ", info.P_form);
            }
            if (info.Type_id != 0 && info.Type_id != 9999)
            {
                sb.AppendFormat(" AND tae.type_id={0} ", info.Type_id);
            }
            if (info.Isletter != 0 && info.Isletter != 9999)
            {
                sb.AppendFormat(" AND tae.isletter={0} ", info.Isletter);
            }
            return sb.ToString();
        } 
        #endregion

        #region 按条件得到学术论文信息并分页显示
        /// <summary>
        /// 方法说明：按条件得到学术论文信息并分页显示
        /// 创建人员：Jacky
        /// 创建日期：2014/11/11 13:30
        /// 修改日期：
        /// </summary>
        /// <param name="info">条件信息</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <returns>学术论文信息</returns>
        public DataTable GetTech_article(tech_article info, int pageIndex, int pageSize)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT tae.article_id,tae.title,tae.publisher,tua.family_name,tua.given_name,tat.type_name,tpf.p_name,tae.annex_path,tae.summary ");
            sb.Append(" ,tae.isexpert,tae.type_id,tae.p_form,tae.isok,tae.isdel,tae.mid,tae.mtype_id,tae.nationality,tae.isletter,tae.isconfirm ");
            sb.Append(" ,tae.purpose,tae.methods,tae.results,tae.conclusions,tae.article_text,tae.key_word,tae.first_author,tae.other_author ");
            sb.Append(" ,CONCAT(tua.family_name,tua.given_name) AS ch_name ");
            sb.Append(" ,CONCAT(tua.given_name,' ',tua.family_name) AS en_name ");
            sb.Append(" FROM tech_article tae ");
            sb.Append(" INNER JOIN tech_article_type tat ON tat.type_id=tae.type_id ");
            sb.Append(" INNER JOIN tech_published_form tpf ON tpf.p_id=tae.p_form ");
            sb.Append(" INNER JOIN tech_user_all tua ON tua.user_code=tae.publisher ");
            sb.AppendFormat(" WHERE tae.isdel=2 AND tae.mid='{0}' AND tae.mtype_id='{1}' ", info.Mid, info.Mtype_id);
            sb.Append(GetArticleSQL(info));
            sb.Append(" GROUP BY tae.article_id ");
            int index = pageIndex;
            if (index <= 0)
            {
                index = 1;
            }
            sb.AppendFormat(" LIMIT {0},{1} ", (index - 1) * pageSize, pageSize);
            return MySQLHelper.ExecuteDataTable(sb.ToString());
        } 
        #endregion

        #region 按条件得到学术论文信息
		/// <summary>
        /// 方法说明：按条件得到学术论文信息
        /// 创建人员：Jacky
        /// 创建日期：2014/11/11 15:09
        /// 修改日期：
        /// </summary>
        /// <param name="info">条件信息</param>
        /// <returns>学术论文信息</returns>
        public DataTable GetTech_article(tech_article info)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT tae.article_id,tae.title,tae.publisher,tua.family_name,tua.given_name,tae.type_id,tat.type_name,tae.p_form,tpf.p_name,tae.annex_path,tae.summary ");
            sb.Append(" ,tae.isexpert,tae.type_id,tae.p_form,tae.isok,tae.isdel,tae.mid,tae.mtype_id,tae.nationality,tae.isletter,tae.isconfirm,tae.corresponding_author,tae.corresponding_author_phone ");
            sb.Append(" ,tae.purpose,tae.methods,tae.results,tae.conclusions,tae.article_text,tae.key_word,tae.first_author,tae.other_author,tae.pCmtID,tae.corresponding_author,tae.corresponding_author_phone ");
            sb.Append(" ,CONCAT(tua.family_name,tua.given_name) AS ch_name ");
            sb.Append(" ,CONCAT(tua.given_name,' ',tua.family_name) AS en_name ");
            sb.Append(" ,CONCAT(author.given_name,' ',author.family_name) AS author_en_name ");
            sb.Append(" ,CONCAT(author.family_name,author.given_name) AS author_ch_name ");
            sb.Append(" ,(SELECT GROUP_CONCAT(CONCAT(tech_user_all.family_name,tech_user_all.given_name))  ");
	        sb.Append(" FROM tech_user_all  ");
	        sb.Append(" WHERE FIND_IN_SET(tech_user_all.user_code,tae.other_author)) AS other_author_name ");
            sb.Append(" FROM tech_article tae ");
            sb.Append(" INNER JOIN tech_article_type tat ON tat.type_id=tae.type_id ");
            sb.Append(" INNER JOIN tech_published_form tpf ON tpf.p_id=tae.p_form ");
            sb.Append(" INNER JOIN tech_user_all tua ON tua.user_code=tae.publisher ");
            sb.Append(" INNER JOIN tech_user_all author ON author.user_code=tae.first_author ");
            sb.AppendFormat(" WHERE tae.isdel=2 AND tae.mid='{0}' AND tae.mtype_id='{1}' ", info.Mid, info.Mtype_id);
            sb.Append(GetArticleSQL(info));
            sb.Append(" GROUP BY tae.article_id ");
            return MySQLHelper.ExecuteDataTable(sb.ToString());
        } 
	    #endregion


        #region 按名字索引查找论文通知
        /// <summary>
        /// 方法说明：按名字索引查找论文通知
        /// 创建人员：李
        /// 创建日期：2015/12/25
        /// 修改日期：
        /// </summary>
        /// <param name="info">名字</param>
        public DataTable GetTech_article(string info)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT tuser.user_code,CONCAT(tuser.family_name,tuser.given_name) as fullname,tuser.unitid ");
            sb.Append(" ,CONCAT(unit.unit_province,unit.unit_city,unit.unitname) as danwei ");
            sb.Append(" ,article.first_author,article.other_author,article.article_id,article.title ");
            sb.Append(" ,(select GROUP_CONCAT(CONCAT(other.family_name,other.given_name)) as other_fullname FROM tech_user_all other WHERE FIND_IN_SET(other.user_code,article.other_author)) as other_name ");
            sb.Append(" FROM tech_user_all tuser LEFT JOIN tech_unit unit ON unit.unitid=tuser.unitid ");
            sb.Append(" LEFT JOIN tech_article article ON article.first_author=tuser.user_code ");
            sb.AppendFormat(" WHERE tuser.isdel=2 AND tuser.family_name LIKE '%{2}%' GROUP BY title",info);
            return MySQLHelper.ExecuteDataTable(sb.ToString());
        }
        #endregion

        #region 按条件得到学术论文信息数
        /// <summary>
        /// 方法说明：按条件得到学术论文信息数
        /// 创建人员：Jacky
        /// 创建日期：2014/11/11 15:10
        /// 修改日期：
        /// </summary>
        /// <param name="info">条件信息</param>
        /// <returns>学术论文信息数</returns>
        public int GetTech_article_count(tech_article info)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT COUNT(1) ");
            sb.Append(" FROM tech_article tae ");
            sb.Append(" INNER JOIN tech_article_type tat ON tat.type_id=tae.type_id ");
            sb.Append(" INNER JOIN tech_published_form tpf ON tpf.p_id=tae.p_form ");
            sb.Append(" INNER JOIN tech_author tar ON tar.article_id=tae.article_id ");
            sb.Append(" INNER JOIN tech_provincecode tp ON tp.province_id=tar.province_id ");
            sb.Append(" INNER JOIN tech_user_all tua ON tua.user_code=tae.publisher ");
            sb.AppendFormat(" WHERE tae.isdel=2 AND tae.mid='{0}' AND tae.mtype_id='{1}' AND tar.sort=1 ", info.Mid, info.Mtype_id);
            sb.Append(GetArticleSQL(info));
            sb.Append(" GROUP BY tae.article_id ");
            return Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
        } 
        #endregion
    }
}
