using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// �û���Ϣ��ʵ����
    /// Jacky
    /// 2014-10-28
    /// </summary>
    [Serializable()]
    public class tech_user_all
    {
        private int user_code;  //ID(����)
        private string family_name;  //����
        private string given_name;  //����
        private string family_name_pinyin;  //����ƴ��
        private string given_name_pinyin;  //����ƴ��
        private string mail;  //����
        private string gender_title;  //�б��Ա��У�Ů�������TITLE��Dr.Mr.��
        private string mobile;  //�ֻ�����
        private string datebirth;  //��������
        private string loginpwd;  //����
        private DateTime inputtime;  //¼��ʱ��
        private int isdel;  //״̬��1����ɾ�� 2����
        private int user_type;  //��Ա���� 1�б���Ϣ 2�����Ϣ
        private DateTime operatingtime;  //����ʱ��
        private string zip;  //�ʱ�
        private string address;  //��ַ
        private string tel;  //��������
        private string fax;  //����
        private string offices;  //�б��������һ������������
        private int unitid;  //������λID�������,��tech_unit���unitid�й���
        private string unit_name;  //������λ����
        private int provinceid;  //����ʡID
        private int cityid;  //������ID
        private string idnumber;  //���֤��
        private int education;  //ѧ��(1-��ʿ,2-˶ʿ,3-�о���,4-����,5-ר��)
        private string hoslevel;  //ҽԺ�ȼ�
        private string post;  //ְ��
        private string jobtitle;  //ְ��
        private string learnpost;  //ѧ��ְ��
        private string penintro;  //���˼���(��Ҫ�����ݿ⽫�������޸�Ϊtext)
        private string picture_url;  //��Ƭ·��
        private string area_code;  //����
        private int country;  //����ID
        private string city;  //���ڳ���
        private string company;  //���ڹ�˾
        private string other_email;  //��������
        private string passport;  //���պ�
        private string passport_country;  //������������
        private string passport_name;  //�����ϵ�����
        private string p_birth;  //�����ϵĳ�������
        private string p_gender;  //�����ϵ��Ա�
        private string discipline;  //ѧ��
        private string agency;  //ѧ������
        private string resume_url;  //����·��
        private string degree;  //ѧλ
        private string nation;  //����
        private string in_position;  //ѧ��ְ��
        private string po_scape;  //������ò
        private string full_name;  //ȫ��
        private string mid;  //������
        private string mtype_id;  //��������ID
        private int ischeck;  //�Ƿ񱨵���1-�ǣ�2-��
        private int is_meeting_letter;  //�Ƿ��͹��ɷ�ȷ�Ϻ���1-�ǣ�2-��
        private int is_hotel_letter;  //�Ƿ��;Ƶ�ȷ�Ϻ���1-�ǣ�2-��
        private int is_sch_email;  //�Ƿ��͹��ճ����ѣ�1-�ǣ�2-��
        private int isinvite;  //�Ƿ���Ҫ���뺯��1-�ǣ�2-��
        private string order_id;  //�λᶩ��ID
        private string departments;//����
        private string _Province_name;//ʡ������
        private string _City_name;//��������
        private int pageIndex;  //��ǰҳ��
        private int pageSize;  //ÿҳ��ʾ��¼��
        private int _nationality;//1�б����ˣ�2������� 3�б���ϯ�� 4�����ϯ�� 
        private string _education_name;//ѧ������
        private int is_accept;//��ϯ���Ƿ�����ճ̰���
        private int mt_type;//��ϯ�Ųλ�״̬
        private int en_nationality;  //����ID
        private string user_code_array;  //�û�ID��
        private string work_background;
        private string physi_no;
        private string professional_role;  //ְҵ��ɫ
        private int isCheck;  //����״̬��1-�ǣ�2-��
        private int isCanjuan;  //�Ƿ������ȯ��1-�ǣ�2-��
        private int isCredit;  //ѧ����ȡ״̬��1-���죬2-δ�죩
        private string zige_no;  //ҽʦ�ʸ�֤����
        private int isMeeting;  //�Ƿ�λ�ע�ᣨ1-�ǣ�2-��
        private int isFaculty;  //�Ƿ�������ϯ�ų�Ա��1-�ǣ�2-��
        private string brief_introduction;  //���˼��
        private int ispay; //�Ƿ�ɷ�
        private string invoice_title;  //��Ʊ̧ͷ
        private int pay_type;//�ɷѷ�ʽ
        private int msg_type;//ע������
        private string cart_order_id;//�̻�������
        private int _ppt_user_code;//��Ƭ�û�ID

        public int roleid { get; set; }

        private string bankCard;    //���п�
        private string bankDeposit; //������

        public string BankDeposit
        {
            get { return bankDeposit; }
            set { bankDeposit = value; }
        }

        public string BankCard
        {
            get { return bankCard; }
            set { bankCard = value; }
        }

        public int ppt_user_code
        {
            get { return _ppt_user_code; }
            set { _ppt_user_code = value; }
        }

        public decimal ying_shou { get; set; }  //Ӧ��
        public decimal yi_shou { get; set; }    //����

        public int is_live_surgery { get; set; }    //�Ƿ���Ҫ����ֱ����1-�ǣ�2-��
        public int is_gala_dinner { get; set; }     //�Ƿ���Ҫ���磨1-�ǣ�2-��

        public int faculty_type { get; set; }       //��ϯ������
        public string faculty_remark { get; set; }  //��ϯ�ű�ע



        /// <summary>
        /// ���ﳵ
        /// </summary>
        public string Cart_order_id
        {
            get { return cart_order_id; }
            set { cart_order_id = value; }
        }

        /// <summary>
        /// �ɷѷ�ʽ
        /// </summary>
        public int Pay_type
        {
            get { return pay_type; }
            set { pay_type = value; }
        }

        /// <summary>
        /// ע������
        /// </summary>
        public int Msg_type
        {
            get { return msg_type; }
            set { msg_type = value; }
        }

        /// <summary>
        /// ��Ʊ̧ͷ
        /// </summary>
        public string Invoice_title
        {
            get { return invoice_title; }
            set { invoice_title = value; }
        }

        /// <summary>
        /// �Ƿ�ɷ�
        /// </summary>
        public int Ispay
        {
            get { return ispay; }
            set { ispay = value; }
        }

        /// <summary>
        /// ���˼��
        /// </summary>
        public string Brief_introduction
        {
            get { return brief_introduction; }
            set { brief_introduction = value; }
        }

        /// <summary>
        /// �Ƿ�������ϯ�ų�Ա��1-�ǣ�2-��
        /// </summary>
        public int IsFaculty
        {
            get { return isFaculty; }
            set { isFaculty = value; }
        }

        /// <summary>
        /// �Ƿ�λ�ע�ᣨ1-�ǣ�2-��
        /// </summary>
        public int IsMeeting
        {
            get { return isMeeting; }
            set { isMeeting = value; }
        }

        /// <summary>
        /// ҽʦ�ʸ�֤����
        /// </summary>
        public string Zige_no
        {
            get { return zige_no; }
            set { zige_no = value; }
        }

        /// <summary>
        /// ѧ����ȡ״̬��1-���죬2-δ�죩
        /// </summary>
        public int IsCredit
        {
            get { return isCredit; }
            set { isCredit = value; }
        }

        /// <summary>
        /// �Ƿ������ȯ��1-�ǣ�2-��
        /// </summary>
        public int IsCanjuan
        {
            get { return isCanjuan; }
            set { isCanjuan = value; }
        }

        /// <summary>
        /// ����״̬��1-�ǣ�2-��
        /// </summary>
        public int IsCheck
        {
            get { return isCheck; }
            set { isCheck = value; }
        }


        /// <summary>
        /// ְҵ��ɫ
        /// </summary>
        public string Professional_role
        {
            get { return professional_role; }
            set { professional_role = value; }
        }


        /// <summary>
        /// ҽʦְҵ���
        /// </summary>
        public string Physi_no
        {
            get { return physi_no; }
            set { physi_no = value; }
        }


        /// <summary>
        /// ��������
        /// </summary>
        public string Work_background
        {
            get { return work_background; }
            set { work_background = value; }
        }

        /// <summary>
        /// �û�ID��
        /// </summary>
        public string User_code_array
        {
            get { return user_code_array; }
            set { user_code_array = value; }
        }

        /// <summary>
        /// ����ID
        /// </summary>
        public int En_nationality
        {
            get { return en_nationality; }
            set { en_nationality = value; }
        }

        public int Mt_type
        {
            get { return mt_type; }
            set { mt_type = value; }
        }
        public int Is_accept
        {
            get { return is_accept; }
            set { is_accept = value; }
        }

        /// <summary>
        /// ѧ������
        /// </summary>
        public string education_name
        {
            get { return _education_name; }
            set { _education_name = value; }
        }

        /// <summary>
        /// 1�б����ˣ�2������� 3�б���ϯ�� 4�����ϯ�� 
        /// </summary>
        public int nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }

        /// <summary>
        /// ��ǰҳ��
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        /// <summary>
        /// ÿҳ��ʾ��¼��
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        
        /// <summary>
        /// ��������
        /// </summary>
        public string City_name
        {
            get { return _City_name; }
            set { _City_name = value; }
        }
        /// <summary>
        /// ʡ������
        /// </summary>
        public string Province_name
        {
            get { return _Province_name; }
            set { _Province_name = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Departments
        {
            get { return departments; }
            set { departments = value; }
        }

        /// <summary>
        /// �λᶩ��ID
        /// </summary>
        public string Order_id
        {
            get { return order_id; }
            set { order_id = value; }
        }

        /// <summary>
        /// �Ƿ���Ҫ���뺯��1-�ǣ�2-��
        /// </summary>
        public int Isinvite
        {
            get { return isinvite; }
            set { isinvite = value; }
        }

        /// <summary>
        /// �Ƿ��͹��ճ����ѣ�1-�ǣ�2-��
        /// </summary>
        public int Is_sch_email
        {
            get { return is_sch_email; }
            set { is_sch_email = value; }
        }

        /// <summary>
        /// �Ƿ��;Ƶ�ȷ�Ϻ���1-�ǣ�2-��
        /// </summary>
        public int Is_hotel_letter
        {
            get { return is_hotel_letter; }
            set { is_hotel_letter = value; }
        }

        /// <summary>
        /// �Ƿ��͹��ɷ�ȷ�Ϻ���1-�ǣ�2-��
        /// </summary>
        public int Is_meeting_letter
        {
            get { return is_meeting_letter; }
            set { is_meeting_letter = value; }
        }

        /// <summary>
        /// �Ƿ񱨵���1-�ǣ�2-��
        /// </summary>
        public int Ischeck
        {
            get { return ischeck; }
            set { ischeck = value; }
        }

        /// <summary>
        /// ��������ID
        /// </summary>
        public string Mtype_id
        {
            get { return mtype_id; }
            set { mtype_id = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string Mid
        {
            get { return mid; }
            set { mid = value; }
        }

        /// <summary>
        /// ȫ��
        /// </summary>
        public string Full_name
        {
            get { return full_name; }
            set { full_name = value; }
        }

        /// <summary>
        /// ������ò
        /// </summary>
        public string Po_scape
        {
            get { return po_scape; }
            set { po_scape = value; }
        }

        /// <summary>
        /// ѧ��ְ��
        /// </summary>
        public string In_position
        {
            get { return in_position; }
            set { in_position = value; }
        }  

        /// <summary>
        /// ����
        /// </summary>
        public string Nation
        {
            get { return nation; }
            set { nation = value; }
        }

        /// <summary>
        /// ѧλ
        /// </summary>
        public string Degree
        {
            get { return degree; }
            set { degree = value; }
        }

        /// <summary>
        /// ����·��
        /// </summary>
        public string Resume_url
        {
            get { return resume_url; }
            set { resume_url = value; }
        }

        /// <summary>
        /// ѧ������
        /// </summary>
        public string Agency
        {
            get { return agency; }
            set { agency = value; }
        }

        /// <summary>
        /// ѧ��
        /// </summary>
        public string Discipline
        {
            get { return discipline; }
            set { discipline = value; }
        }

        /// <summary>
        /// �����ϵ��Ա�
        /// </summary>
        public string P_gender
        {
            get { return p_gender; }
            set { p_gender = value; }
        }

        /// <summary>
        /// �����ϵĳ�������
        /// </summary>
        public string P_birth
        {
            get { return p_birth; }
            set { p_birth = value; }
        }

        /// <summary>
        /// �����ϵ�����
        /// </summary>
        public string Passport_name
        {
            get { return passport_name; }
            set { passport_name = value; }
        }

        /// <summary>
        /// ������������
        /// </summary>
        public string Passport_country
        {
            get { return passport_country; }
            set { passport_country = value; }
        }

        /// <summary>
        /// ���պ�
        /// </summary>
        public string Passport
        {
            get { return passport; }
            set { passport = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string Other_email
        {
            get { return other_email; }
            set { other_email = value; }
        }

        /// <summary>
        /// ���ڹ�˾
        /// </summary>
        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        /// <summary>
        /// ���ڳ���
        /// </summary>
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        /// <summary>
        /// ����ID
        /// </summary>
        public int Country
        {
            get { return country; }
            set { country = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Area_code
        {
            get { return area_code; }
            set { area_code = value; }
        }

        /// <summary>
        /// ��Ƭ·��
        /// </summary>
        public string Picture_url
        {
            get { return picture_url; }
            set { picture_url = value; }
        }

        /// <summary>
        /// ���˼���(��Ҫ�����ݿ⽫�������޸�Ϊtext)
        /// </summary>
        public string Penintro
        {
            get { return penintro; }
            set { penintro = value; }
        }

        /// <summary>
        /// ѧ��ְ��
        /// </summary>
        public string Learnpost
        {
            get { return learnpost; }
            set { learnpost = value; }
        }

        /// <summary>
        /// ְ��
        /// </summary>
        public string Jobtitle
        {
            get { return jobtitle; }
            set { jobtitle = value; }
        }

        /// <summary>
        /// ְ��
        /// </summary>
        public string Post
        {
            get { return post; }
            set { post = value; }
        }

        /// <summary>
        /// ҽԺ�ȼ�
        /// </summary>
        public string Hoslevel
        {
            get { return hoslevel; }
            set { hoslevel = value; }
        }

        /// <summary>
        /// ѧ��(1-��ʿ,2-˶ʿ,3-�о���,4-����,5-ר��)
        /// </summary>
        public int Education
        {
            get { return education; }
            set { education = value; }
        }

        /// <summary>
        /// ���֤��
        /// </summary>
        public string Idnumber
        {
            get { return idnumber; }
            set { idnumber = value; }
        }

        /// <summary>
        /// ������ID
        /// </summary>
        public int Cityid
        {
            get { return cityid; }
            set { cityid = value; }
        }

        /// <summary>
        /// ����ʡID
        /// </summary>
        public int Provinceid
        {
            get { return provinceid; }
            set { provinceid = value; }
        }

        /// <summary>
        /// ������λ����
        /// </summary>
        public string Unit_name
        {
            get { return unit_name; }
            set { unit_name = value; }
        }

        /// <summary>
        /// ������λID�������,��tech_unit���unitid�й���
        /// </summary>
        public int Unitid
        {
            get { return unitid; }
            set { unitid = value; }
        }

        /// <summary>
        /// �б��������һ������������
        /// </summary>
        public string Offices
        {
            get { return offices; }
            set { offices = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        /// <summary>
        /// ��ַ
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        /// <summary>
        /// �ʱ�
        /// </summary>
        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime Operatingtime
        {
            get { return operatingtime; }
            set { operatingtime = value; }
        }

        /// <summary>
        /// ��Ա���� 1�б���Ϣ 2�����Ϣ
        /// </summary>
        public int User_type
        {
            get { return user_type; }
            set { user_type = value; }
        }

        /// <summary>
        /// ״̬��1����ɾ�� 2����
        /// </summary>
        public int Isdel
        {
            get { return isdel; }
            set { isdel = value; }
        }

        /// <summary>
        /// ¼��ʱ��
        /// </summary>
        public DateTime Inputtime
        {
            get { return inputtime; }
            set { inputtime = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Loginpwd
        {
            get { return loginpwd; }
            set { loginpwd = value; }
        }  

        /// <summary>
        /// ��������
        /// </summary>
        public string Datebirth
        {
            get { return datebirth; }
            set { datebirth = value; }
        }

        /// <summary>
        /// �ֻ�����
        /// </summary>
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        /// <summary>
        /// �б��Ա��У�Ů�������TITLE��Dr.Mr.��
        /// </summary>
        public string Gender_title
        {
            get { return gender_title; }
            set { gender_title = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        /// <summary>
        /// ����ƴ��
        /// </summary>
        public string Given_name_pinyin
        {
            get { return given_name_pinyin; }
            set { given_name_pinyin = value; }
        }

        /// <summary>
        /// ����ƴ��
        /// </summary>
        public string Family_name_pinyin
        {
            get { return family_name_pinyin; }
            set { family_name_pinyin = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Given_name
        {
            get { return given_name; }
            set { given_name = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Family_name
        {
            get { return family_name; }
            set { family_name = value; }
        }

        /// <summary>
        /// ID(����)
        /// </summary>
        public int User_code
        {
            get { return user_code; }
            set { user_code = value; }
        }
    }
}
