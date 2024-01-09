using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    [Serializable]
    public class tv_menu
    {
        private int menu_id;  //菜单ID
        private string menu_name;  //菜单名称
        private int pid;  //父级ID
        private string html_url;  //菜单所属页面URL
        private int sort_id;  //菜单输出排列序号
        private int isdel;  //状态(1-删除,2-正常),默认为2
        private DateTime inputtime;  //录入时间

        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime Inputtime
        {
            get { return inputtime; }
            set { inputtime = value; }
        }

        /// <summary>
        /// 状态(1-删除,2-正常),默认为2
        /// </summary>
        public int Isdel
        {
            get { return isdel; }
            set { isdel = value; }
        }

        /// <summary>
        /// 菜单输出排列序号
        /// </summary>
        public int Sort_id
        {
            get { return sort_id; }
            set { sort_id = value; }
        }

        /// <summary>
        /// 菜单所属页面URL
        /// </summary>
        public string Html_url
        {
            get { return html_url; }
            set { html_url = value; }
        }

        /// <summary>
        /// 父级ID
        /// </summary>
        public int Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Menu_name
        {
            get { return menu_name; }
            set { menu_name = value; }
        }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public int Menu_id
        {
            get { return menu_id; }
            set { menu_id = value; }
        }
    }
}
