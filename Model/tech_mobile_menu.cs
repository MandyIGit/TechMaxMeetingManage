using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class tech_mobile_menu
    {
        private int menu_id;  //菜单编号
        private string menu_name;  //菜单名称
        private string menu_icon;  //菜单图标
        private string menu_url;   //菜单链接
        private int isdel;  //是否删除(1-已删除,2-正常),默认为2
        private int isban;  //是否禁用(1-已禁用,2-正常),默认为2
        private DateTime inputtime;  //录入时间
        private string mid; //所属会议id
        private int sort;   //排序

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort
        {
            get { return sort; }
            set { sort = value; }
        }

        /// <summary>
        /// Mid
        /// </summary>
        public string Mid
        {
            get { return mid; }
            set { mid = value; }
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
        /// 是否禁用(1-已禁用,2-正常),默认为2
        /// </summary>
        public int Isban
        {
            get { return isban; }
            set { isban = value; }
        }

        /// <summary>
        /// 是否删除(1-已删除,2-正常),默认为2
        /// </summary>
        public int Isdel
        {
            get { return isdel; }
            set { isdel = value; }
        }

        /// <summary>
        /// 菜单的连接
        /// </summary>
        public string Menu_url
        {
            get { return menu_url; }
            set { menu_url = value; }
        }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Menu_icon
        {
            get { return menu_icon; }
            set { menu_icon = value; }
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
        /// 菜单编号
        /// </summary>
        public int Menu_id
        {
            get { return menu_id; }
            set { menu_id = value; }
        }
    }
}
