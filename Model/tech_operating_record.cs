using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable()]
    public class tech_operating_record
    {
        private int id;  //序号
        private string record_content;  //记录内容
        private string operating_user;  //操作人
        private string operating_time;  //操作时间
        private int admin_code;  //管理员ID
        private string mid;  //大会编码
        private string mtype_id;  //大会类型ID
        private string ip_addr;  //IP地址
        private string host_name;  //客户电脑名称
        private string admin_name;  //管理员姓名
        private int pageIndex;  //当前页数
        private int pageSize;  //每页显示记录数

        private string _operating_time_start;
        private string _operating_time_end;

        public string operating_time_start
        {
            get { return _operating_time_start; }
            set { _operating_time_start = value; }
        }

        public string operating_time_end
        {
            get { return _operating_time_end; }
            set { _operating_time_end = value; }
        }

        /// <summary>
        /// 每页显示记录数
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
        /// 管理员姓名
        /// </summary>
        public string Admin_name
        {
            get { return admin_name; }
            set { admin_name = value; }
        }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IP_Addr
        {
            get { return ip_addr; }
            set { ip_addr = value; }
        }

        /// <summary>
        /// 客户电脑名称
        /// </summary>
        public string Host_name
        {
            get { return host_name; }
            set { host_name = value; }
        }
        /// <summary>
        /// 大会类型ID
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
        /// 管理员ID
        /// </summary>
        public int Admin_code
        {
            get { return admin_code; }
            set { admin_code = value; }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public string Operating_time
        {
            get { return operating_time; }
            set { operating_time = value; }
        }

        /// <summary>
        /// 操作人
        /// </summary>
        public string Operating_user
        {
            get { return operating_user; }
            set { operating_user = value; }
        }

        /// <summary>
        /// 记录内容
        /// </summary>
        public string Record_content
        {
            get { return record_content; }
            set { record_content = value; }
        }

        /// <summary>
        /// 序号
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
