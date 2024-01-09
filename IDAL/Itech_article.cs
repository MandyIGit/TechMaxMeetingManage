using System;
using System.Collections.Generic;
using System.Text;

using Model;
using System.Data;

namespace IDAL
{
    /// <summary>
    /// ѧ�����ı�ӿ�
    /// Jacky
    /// 2014-11-11
    /// </summary>
    public interface Itech_article
    {

        /// <summary>
        /// ����˵�����������õ�ѧ��������Ϣ����ҳ��ʾ
        /// ������Ա��Jacky
        /// �������ڣ�2014/11/11 13:30
        /// �޸����ڣ�
        /// </summary>
        /// <param name="info">������Ϣ</param>
        /// <param name="pageIndex">��ǰҳ��</param>
        /// <param name="pageSize">ÿҳ��ʾ��¼��</param>
        /// <returns>ѧ��������Ϣ</returns>
        DataTable GetTech_article(tech_article info, int pageIndex, int pageSize);

        /// <summary>
        /// ����˵�����������õ�ѧ��������Ϣ
        /// ������Ա��Jacky
        /// �������ڣ�2014/11/11 15:09
        /// �޸����ڣ�
        /// </summary>
        /// <param name="info">������Ϣ</param>
        /// <returns>ѧ��������Ϣ</returns>
        DataTable GetTech_article(tech_article info);

        /// <summary>
        /// ����˵����������������������֪ͨ
        /// ������Ա����
        /// �������ڣ�2015/12/25
        /// �޸����ڣ�
        /// </summary>
        /// <param name="info">����</param>
        DataTable GetTech_article(string info);

        /// <summary>
        /// ����˵�����������õ�ѧ��������Ϣ��
        /// ������Ա��Jacky
        /// �������ڣ�2014/11/11 15:10
        /// �޸����ڣ�
        /// </summary>
        /// <param name="info">������Ϣ</param>
        /// <returns>ѧ��������Ϣ��</returns>
        int GetTech_article_count(tech_article info);
    }
}
