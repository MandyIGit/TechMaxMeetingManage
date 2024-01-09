using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class email_template
    {
        private int id;  //id
        private string tp_name;  //模板名称
        private string tp_content;  //模板内容
        private string tel;  //秘书处电话
        private string fax;  //秘书处传真
        private string email;  //秘书处邮箱
        private string web_url;  //大会网址
        private string mid;  //大会编码
        private string mtype_id;  //会议类型ID
        private DateTime inputtime;  //录入时间
        private DateTime operatingtime;  //操作时间
        private int isdel;  //是否删除（1-是，2-否）
        private int pageIndex;  //当前页数
        private int pageSize;  //每页显示的记录数
        private string m_p_content_ch;  //中宾参会缴费确认模板温馨提示内容
        private string m_p_content_en;  //外宾参会缴费确认模板温馨提示内容
        private string h_p_content_ch;  //中宾酒店缴费确认模板温馨提示内容
        private string h_p_content_en;  //外宾酒店缴费确认模板温馨提示内容

        /// <summary>
        /// 外宾酒店缴费确认模板温馨提示内容
        /// </summary>
        public string H_p_content_en
        {
            get { return h_p_content_en; }
            set { h_p_content_en = value; }
        }

        /// <summary>
        /// 中宾酒店缴费确认模板温馨提示内容
        /// </summary>
        public string H_p_content_ch
        {
            get { return h_p_content_ch; }
            set { h_p_content_ch = value; }
        }

        /// <summary>
        /// 外宾参会缴费确认模板温馨提示内容
        /// </summary>
        public string M_p_content_en
        {
            get { return m_p_content_en; }
            set { m_p_content_en = value; }
        }

        /// <summary>
        /// 中宾参会缴费确认模板温馨提示内容
        /// </summary>
        public string M_p_content_ch
        {
            get { return m_p_content_ch; }
            set { m_p_content_ch = value; }
        }

        /// <summary>
        /// 每页显示的记录数
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        /// <summary>
        /// 是否删除（1-是，2-否）
        /// </summary>
        public int Isdel
        {
            get { return isdel; }
            set { isdel = value; }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime Operatingtime
        {
            get { return operatingtime; }
            set { operatingtime = value; }
        }

        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime Inputtime
        {
            get { return inputtime; }
            set { inputtime = value; }
        }

        /// <summary>
        /// 会议类型ID
        /// </summary>
        public string Mtype_id
        {
            get { return mtype_id; }
            set { mtype_id = value; }
        }

        /// <summary>
        /// 大会编码
        /// </summary>
        public string Mid
        {
            get { return mid; }
            set { mid = value; }
        }

        /// <summary>
        /// 大会网址
        /// </summary>
        public string Web_url
        {
            get { return web_url; }
            set { web_url = value; }
        }

        /// <summary>
        /// 秘书处邮箱
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// 秘书处传真
        /// </summary>
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        /// <summary>
        /// 秘书处电话
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        /// <summary>
        /// 模板内容
        /// </summary>
        public string Tp_content
        {
            get { return tp_content; }
            set { tp_content = value; }
        }

        /// <summary>
        /// 模板名称
        /// </summary>
        public string Tp_name
        {
            get { return tp_name; }
            set { tp_name = value; }
        }

        /// <summary>
        /// id
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
