using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_meeting_reg_type
    {
        private int id;  //ID
        private string ch_name;  //类型名称(中文)
        private string en_name;  //类型名称(英文)
        private DateTime begin_time;  //开始时间
        private DateTime end_time;  //结束时间
        private Decimal money;  //价格
        private int use_type;  //作用类型（1-中宾个人，2-外宾个人，3-中宾团队，4-外宾团队，5-晚宴）
        private int use_location;  //作用位置（1-前台，2-后台）
        private int isdel;  //状态信息（1-已删除，2-正常）
        private string mid;  //大会编码
        private string mtype_id;  //会议类型ID
        private int isupload;  //是否需要上传凭证  1是 2否
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
        /// 是否需要上传凭证  1是 2否
        /// </summary>
        public int Isupload
        {
            get { return isupload; }
            set { isupload = value; }
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
        /// 状态信息（1-已删除，2-正常）
        /// </summary>
        public int Isdel
        {
            get { return isdel; }
            set { isdel = value; }
        }

        /// <summary>
        /// 作用位置（1-前台，2-后台）
        /// </summary>
        public int Use_location
        {
            get { return use_location; }
            set { use_location = value; }
        }

        /// <summary>
        /// 作用类型（1-中宾个人，2-外宾个人，3-中宾团队，4-外宾团队，5-晚宴）
        /// </summary>
        public int Use_type
        {
            get { return use_type; }
            set { use_type = value; }
        }

        /// <summary>
        /// 价格
        /// </summary>
        public Decimal Money
        {
            get { return money; }
            set { money = value; }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime End_time
        {
            get { return end_time; }
            set { end_time = value; }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime Begin_time
        {
            get { return begin_time; }
            set { begin_time = value; }
        }

        /// <summary>
        /// 类型名称(英文)
        /// </summary>
        public string En_name
        {
            get { return en_name; }
            set { en_name = value; }
        }

        /// <summary>
        /// 类型名称(中文)
        /// </summary>
        public string Ch_name
        {
            get { return ch_name; }
            set { ch_name = value; }
        }

        /// <summary>
        /// ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
