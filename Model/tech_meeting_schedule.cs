using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_meeting_schedule
    {
        private int scheduleid;
        private string schedulename;
        private string en_schedulename;
        private int meetingid;
        private DateTime scheduletime;
        private int hallid;
        private int typeid;
        private int speakuser;
        private string speakusername;
        private int hire;
        private int speechorder;
        private string begintime;
        private string endtime;
        private string articleid;
        private string entile;
        private DateTime inputtime;
        private string authname;
        private string assemblyid;
        private string title;
        private int pptstatus;

        /// <summary>
        /// 是否上传PPT（1：已上传；2：未上传）
        /// </summary>
        public int Pptstatus
        {
            get { return pptstatus; }
            set { pptstatus = value; }
        }
        /// <summary>
        /// 论文标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        /// <summary>
        /// 汇编编号
        /// </summary>
        public string Assemblyid
        {
            get { return assemblyid; }
            set { assemblyid = value; }
        }
        /// <summary>
        /// 作者名称
        /// </summary>
        public string Authname
        {
            get { return authname; }
            set { authname = value; }
        }
        private List<tech_meeting_role> holderlist;

        /// <summary>
        /// 主持人集合
        /// </summary>
        public List<tech_meeting_role> Holderlist
        {
            get { return holderlist; }
            set { holderlist = value; }
        }
        private List<tech_meeting_role> transferlist;
        /// <summary>
        /// 翻译集合
        /// </summary>
        public List<tech_meeting_role> Transferlist
        {
            get { return transferlist; }
            set { transferlist = value; }
        }
        private List<tech_meeting_role> expertlist;
        /// <summary>
        /// 专家集合
        /// </summary>
        public List<tech_meeting_role> Expertlist
        {
            get { return expertlist; }
            set { expertlist = value; }
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
        /// 英文标题
        /// </summary>
        public string Entile
        {
            get { return entile; }
            set { entile = value; }
        }

        /// <summary>
        /// 所属论文编号
        /// </summary>
        public string Articleid
        {
            get { return articleid; }
            set { articleid = value; }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string Endtime
        {
            get { return endtime; }
            set { endtime = value; }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string Begintime
        {
            get { return begintime; }
            set { begintime = value; }
        }

        /// <summary>
        /// 演讲顺序
        /// </summary>
        public int Speechorder
        {
            get { return speechorder; }
            set { speechorder = value; }
        }

        /// <summary>
        /// 录用形式(1-大会报告,2-专题发言,3-论文发言,4-继教课程,5-病例讨论,6-卫星会)
        /// </summary>
        public int Hire
        {
            get { return hire; }
            set { hire = value; }
        }

        /// <summary>
        /// 发言人姓名
        /// </summary>
        public string Speakusername
        {
            get { return speakusername; }
            set { speakusername = value; }
        }

        /// <summary>
        /// 发言人ID
        /// </summary>
        public int Speakuser
        {
            get { return speakuser; }
            set { speakuser = value; }
        }

        /// <summary>
        /// 议题类型
        /// </summary>
        public int Typeid
        {
            get { return typeid; }
            set { typeid = value; }
        }

        /// <summary>
        /// 会议厅ID
        /// </summary>
        public int Hallid
        {
            get { return hallid; }
            set { hallid = value; }
        }

        /// <summary>
        /// 会议日期
        /// </summary>
        public DateTime Scheduletime
        {
            get { return scheduletime; }
            set { scheduletime = value; }
        }

        /// <summary>
        /// 所属会议ID
        /// </summary>
        public int Meetingid
        {
            get { return meetingid; }
            set { meetingid = value; }
        }

        /// <summary>
        /// 日程英文名称
        /// </summary>
        public string En_schedulename
        {
            get { return en_schedulename; }
            set { en_schedulename = value; }
        }

        /// <summary>
        /// 日程名称
        /// </summary>
        public string Schedulename
        {
            get { return schedulename; }
            set { schedulename = value; }
        }

        /// <summary>
        /// 编号
        /// </summary>
        public int Scheduleid
        {
            get { return scheduleid; }
            set { scheduleid = value; }
        }
        #region 增加字段
        /// <summary>
        /// 增加字段
        /// </summary>
        private string hallname;

        public string Hallname
        {
            get { return hallname; }
            set { hallname = value; }
        }
        private string meetingname;

        public string Meetingname
        {
            get { return meetingname; }
            set { meetingname = value; }
        }


        private string publishtype;
        /// <summary>
        /// 发表形式
        /// </summary>
        public string Publishtype
        {
            get { return publishtype; }
            set { publishtype = value; }
        }
        private string articletype;
        /// <summary>
        /// 论文类型
        /// </summary>
        public string Articletype
        {
            get { return articletype; }
            set { articletype = value; }
        }
        private string commitauthor;
        /// <summary>
        /// 提交作者
        /// </summary>
        public string Commitauthor
        {
            get { return commitauthor; }
            set { commitauthor = value; }
        }
        private string firstauthor;
        /// <summary>
        /// 第一作者
        /// </summary>
        public string Firstauthor
        {
            get { return firstauthor; }
            set { firstauthor = value; }
        }
        private string speech;
        /// <summary>
        /// 发言人
        /// </summary>
        public string Speech
        {
            get { return speech; }
            set { speech = value; }
        }
        private string articletitle;
        /// <summary>
        /// 论文标题
        /// </summary>
        public string Articletitle
        {
            get { return articletitle; }
            set { articletitle = value; }
        }
        private string meetingmsg;
        /// <summary>
        /// 会议单元名称
        /// </summary>
        public string Meetingmsg
        {
            get { return meetingmsg; }
            set { meetingmsg = value; }
        }
        private int msgid;

        public int Msgid
        {
            get { return msgid; }
            set { msgid = value; }
        }
        #endregion
        public class meeting_schedule_export
        {
            private string meetingtheme;
            /// <summary>
            /// 会议主题
            /// </summary>
            public string Meetingtheme
            {
                get { return meetingtheme; }
                set { meetingtheme = value; }
            }
            private string meetinghall;
            /// <summary>
            /// 会议大厅
            /// </summary>
            public string Meetinghall
            {
                get { return meetinghall; }
                set { meetinghall = value; }
            }
            private DateTime meetingtime;
            /// <summary>
            /// 会议时间
            /// </summary>
            public DateTime Meetingtime
            {
                get { return meetingtime; }
                set { meetingtime = value; }
            }
            private string arttype;
            /// <summary>
            /// 论文类型
            /// </summary>
            public string Arttype
            {
                get { return arttype; }
                set { arttype = value; }
            }
            private string arttitle;
            /// <summary>
            /// 论文标题
            /// </summary>
            public string Arttitle
            {
                get { return arttitle; }
                set { arttitle = value; }
            }
            private string artauth;
            /// <summary>
            /// 论文作者
            /// </summary>
            public string Artauth
            {
                get { return artauth; }
                set { artauth = value; }
            }
            private string authunit;
            /// <summary>
            /// 作者单位
            /// </summary>
            public string Authunit
            {
                get { return authunit; }
                set { authunit = value; }
            }
            private int speekorder;
            /// <summary>
            /// 演讲顺序
            /// </summary>
            public int Speekorder
            {
                get { return speekorder; }
                set { speekorder = value; }
            }

            #region 拓展
            private string hallname;

            /// <summary>
            /// 所属的会议大厅
            /// </summary>
            public string Hallname
            {
                get { return hallname; }
                set { hallname = value; }
            }

            #endregion
        }
    }
}
