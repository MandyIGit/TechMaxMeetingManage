using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{

    [Serializable()]
    public class tv_competence
    {
        private int c_id;  //编号
        private int sys_code;  //管理员ID
        private int menu_id;  //管理菜单ID

        /// <summary>
        /// 管理菜单ID
        /// </summary>
        public int Menu_id
        {
            get { return menu_id; }
            set { menu_id = value; }
        }

        /// <summary>
        /// 管理员ID
        /// </summary>
        public int Sys_code
        {
            get { return sys_code; }
            set { sys_code = value; }
        }

        /// <summary>
        /// 编号
        /// </summary>
        public int C_id
        {
            get { return c_id; }
            set { c_id = value; }
        }
    }
}
