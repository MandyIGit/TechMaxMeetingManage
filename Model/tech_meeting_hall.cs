using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_meeting_hall
    {
        private int hallid;  //编号
        private string hallname;  //会议厅名称
        private string en_hallname;
        private string mid;  //所属大会ID
        private DateTime inputtime;  //录入时间
        private string meetingname;
        private int status;
        private string _alias_hallname;
        private int orders;     //排序
        private string _zhibo_url;
        private string _channelId;
        private string _secretkey;

        public string secretkey
        {
            get { return _secretkey; }
            set { _secretkey = value; }
        }

        public string channelId
        {
            get { return _channelId; }
            set { _channelId = value; }
        }

        public string zhibo_url
        {
            get { return _zhibo_url; }
            set { _zhibo_url = value; }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public int Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        /// <summary>
        /// 别名
        /// </summary>
        public string alias_hallname
        {
            get { return _alias_hallname; }
            set { _alias_hallname = value; }
        }
        /// <summary>
        /// 状态 1删除 2正常
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// 所属的会议名称
        /// </summary>
        public string Meetingname
        {
            get { return meetingname; }
            set { meetingname = value; }
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
        /// 所属大会ID
        /// </summary>
        public string Mid
        {
            get { return mid; }
            set { mid = value; }
        }

        /// <summary>
        /// 会议厅英文名称
        /// </summary>
        public string En_hallname
        {
            get { return en_hallname; }
            set { en_hallname = value; }
        }

        /// <summary>
        /// 会议厅名称
        /// </summary>
        public string Hallname
        {
            get { return hallname; }
            set { hallname = value; }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public int Hallid
        {
            get { return hallid; }
            set { hallid = value; }
        }
    }
}
