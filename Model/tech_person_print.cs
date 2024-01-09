using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_person_print
    {
        private int _id;  //ID
        private string _person_code;  //人员编码
        private string _person_name;  //人员姓名
        private int _person_group;  //分组（1-医师领导及工作人员，2-中宾专家，3-外宾专家）
        private int _is_print;  //是否打印（1-打印，2-未打印）
        private DateTime _operatingtime;  //操作时间
        private DateTime _inputtime;  //录入时间
        private int _pageIndex;
        private int _pageSize;


        public int id
        {
            get { return _id; }
            set { _id = value; }
        }        

        public string person_code
        {
            get { return _person_code; }
            set { _person_code = value; }
        }        

        public string person_name
        {
            get { return _person_name; }
            set { _person_name = value; }
        }        

        public int person_group
        {
            get { return _person_group; }
            set { _person_group = value; }
        }        

        public int is_print
        {
            get { return _is_print; }
            set { _is_print = value; }
        }        

        public DateTime operatingtime
        {
            get { return _operatingtime; }
            set { _operatingtime = value; }
        }        

        public DateTime inputtime
        {
            get { return _inputtime; }
            set { _inputtime = value; }
        }        

        public int pageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }        

        public int pageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }
    }
}
