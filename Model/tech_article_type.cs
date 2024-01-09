using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_article_type
    {
        private int type_id;  //序号ID
        private string type_name;  //类型名称
        private int app_type;  //应用类型（1-中宾，2-外宾）
        private int isdel;  //是否删除（1-是，2-否）
        private string mid;  //大会编码
        private string mtype_id;  //会议类型ID
        private DateTime operatingtime;  //操作时间
        private DateTime inputtime;  //录入时间
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
        /// 是否删除（1-是，2-否）
        /// </summary>
        public int Isdel
        {
            get { return isdel; }
            set { isdel = value; }
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
        /// 类型名称
        /// </summary>
        public string Type_name
        {
            get { return type_name; }
            set { type_name = value; }
        }

        /// <summary>
        /// 序号ID
        /// </summary>
        public int Type_id
        {
            get { return type_id; }
            set { type_id = value; }
        }
    }
}
