using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_published_form
    {
        private int p_id;  //发表形式ID
        private string p_name;  //发表形式名称
        private int app_type;  //应用类型（1-中宾，2-外宾）
        private string mid;  //大会编码
        private string mtype_id;  //会议类型ID
        private DateTime operatingtime;  //操作时间
        private DateTime inputtime;  //录入时间
        private int isdel;  //是否删除（1-是，2-否）
        private int _pageIndex;
        private int _pageSize;

        /// <summary>
        /// 每页显示记录数
        /// </summary>
        public int pageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        /// <summary>
        /// 当前页数
        /// </summary>
        public int pageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
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
        /// 录入时间
        /// </summary>
        public DateTime Inputtime
        {
            get { return inputtime; }
            set { inputtime = value; }
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
        /// 应用类型（1-中宾，2-外宾）
        /// </summary>
        public int App_type
        {
            get { return app_type; }
            set { app_type = value; }
        }

        /// <summary>
        /// 发表形式名称
        /// </summary>
        public string P_name
        {
            get { return p_name; }
            set { p_name = value; }
        }

        /// <summary>
        /// 发表形式ID
        /// </summary>
        public int P_id
        {
            get { return p_id; }
            set { p_id = value; }
        }
    }
}
