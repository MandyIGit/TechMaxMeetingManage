/**
 * NPinyin����һ��������Pinyin������ʵ����ȡ�����ı�����ĸ���ı���Ӧƴ�����Լ�
 * ��ȡ��ƴ����Ӧ�ĺ����б�ȷ��������ں����ֿ���Ҷ����ֽ϶࣬��˱�����ʵ�ֵ�
 * ƴ��ת����һ���ʹ����е��ֵ���ȷ������ȫ�Ǻϡ������󲿷�����ȷ�ġ�
 * 
 * ����л�ٶ�����Τ�t�ṩ�ĳ��ú���ƴ�����ձ������ص�ַ��
 * http://wenku.baidu.com/view/d725f4335a8102d276a22f46.html
 * 
 * ��������Ҫ��˵��һ���ҵ����˼·��
 * ���ȣ��ҽ����ְ�ƴ���������һ���ַ������飨��PyCode.codes����Ȼ��ʹ�ó���
 * ��PyCode.codes��ÿһ������ͨ�������ֵʹ��ɢ�к�����
 * 
 *     f(x) = x % PyCode.codes.Length
 *   { 
 *     g(f(x)) = pos(x)
 *     
 * ����, pos(x)Ϊ�ַ�x�����ַ������ڵ�PyCode.codes�������±�, Ȼ��ɢ�е�ͬ
 * PyCode.codes������ͬ���ȵ�һ��ɢ�б���PyHash.hashes����
 * ������һ�����ֵ�ƴ��ʱ�����ȴ�PyHash.hashes�л�ȡ��
 * ��Ӧ��PyCode.codes�������±꣬Ȼ��Ӷ�Ӧ�ַ������ң�����Ҫ���ҵ��ַ�ʱ���ַ�
 * ����ǰ6���ַ��������˸��ֵ�ƴ����
 * 
 * ���ַ����ĺô�һ�ǽ�Լ�˴洢�ռ䣬���Ǽ���˲�ѯЧ�ʡ�
 *
 * �����������������ϵ�������ҵ������ǣ�qzyzwsy@gmail.com
 * 
 * ��˼�� 2011��1��3���賿
 * */

/*
 * v0.2.x�ı仯
 * =================================================================
 * 1�����ӶԲ�ͬ�����ʽ�ı���֧��,ͬʱ���ӱ���ת������Pinyin.ConvertEncoding
 * 2���ع����ַ�ƴ���Ļ�ȡ��δ�ҵ�ƴ��ʱ�����ַ�����.
 * 
 * ��˼�� 2012��7��23����
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class Pinyin
    {
        /// <summary>
        /// ȡ�����ı���ƴ������ĸ
        /// </summary>
        /// <param name="text">����ΪUTF8���ı�</param>
        /// <returns>�������Ķ�Ӧ��ƴ������ĸ</returns>

        public static string GetInitials(string text)
        {
            text = text.Trim();
            StringBuilder chars = new StringBuilder();
            for (int i = 0; i < text.Length; ++i)
            {
                string py = GetPinyin(text[i]);
                if (py != "") chars.Append(py[0]);
            }

            return chars.ToString().ToUpper();
        }


        /// <summary>
        /// ȡ�����ı���ƴ������ĸ
        /// </summary>
        /// <param name="text">�ı�</param>
        /// <param name="encoding">Դ�ı��ı���</param>
        /// <returns>����encoding�����������Ķ�Ӧ��ƴ������ĸ</returns>
        public static string GetInitials(string text, Encoding encoding)
        {
            string temp = ConvertEncoding(text, encoding, Encoding.UTF8);
            return ConvertEncoding(GetInitials(temp), Encoding.UTF8, encoding);
        }



        /// <summary>
        /// ȡ�����ı���ƴ��
        /// </summary>
        /// <param name="text">����ΪUTF8���ı�</param>
        /// <returns>���������ı���ƴ��</returns>

        public static string GetPinyin(string text)
        {
            StringBuilder sbPinyin = new StringBuilder();
            for (int i = 0; i < text.Length; ++i)
            {
                string py = GetPinyin(text[i]);
                if (py != "") sbPinyin.Append(py);
                sbPinyin.Append(" ");
            }

            return sbPinyin.ToString().Trim();
        }

        /// <summary>
        /// ȡ�����ı���ƴ��
        /// </summary>
        /// <param name="text">����ΪUTF8���ı�</param>
        /// <param name="encoding">Դ�ı��ı���</param>
        /// <returns>����encoding�������͵������ı���ƴ��</returns>
        public static string GetPinyin(string text, Encoding encoding)
        {
            string temp = ConvertEncoding(text.Trim(), encoding, Encoding.UTF8);
            return ConvertEncoding(GetPinyin(temp), Encoding.UTF8, encoding);
        }

        /// <summary>
        /// ȡ��ƴ����ͬ�ĺ����б�
        /// </summary>
        /// <param name="Pinyin">����ΪUTF8��ƴ��</param>
        /// <returns>ȡƴ����ͬ�ĺ����б���ƴ����ai�����᷵�ء�������������</returns>
        public static string GetChineseText(string pinyin)
        {
            string key = pinyin.Trim().ToLower();

            foreach (string str in PyCode.codes)
            {
                if (str.StartsWith(key + " ") || str.StartsWith(key + ":"))
                    return str.Substring(7);
            }

            return "";
        }


        /// <summary>
        /// ȡ��ƴ����ͬ�ĺ����б�����ͬ����encoding
        /// </summary>
        /// <param name="Pinyin">����Ϊencoding��ƴ��</param>
        /// <param name="encoding">����</param>
        /// <returns>���ر���Ϊencoding��ƴ��Ϊpinyin�ĺ����б���ƴ����ai�����᷵�ء�������������</returns>
        public static string GetChineseText(string pinyin, Encoding encoding)
        {
            string text = ConvertEncoding(pinyin, encoding, Encoding.UTF8);
            return ConvertEncoding(GetChineseText(text), Encoding.UTF8, encoding);
        }



        /// <summary>
        /// ���ص����ַ��ĺ���ƴ��
        /// </summary>
        /// <param name="ch">����ΪUTF8�������ַ�</param>
        /// <returns>ch��Ӧ��ƴ��</returns>
        public static string GetPinyin(char ch)
        {
            short hash = GetHashIndex(ch);
            for (int i = 0; i < PyHash.hashes[hash].Length; ++i)
            {
                short index = PyHash.hashes[hash][i];
                int pos = PyCode.codes[index].IndexOf(ch, 7);
                if (pos != -1)
                    return PyCode.codes[index].Substring(0, 6).Trim();
            }
            return ch.ToString();
        }

        /// <summary>
        /// ���ص����ַ��ĺ���ƴ��
        /// </summary>
        /// <param name="ch">����Ϊencoding�������ַ�</param>
        /// <returns>����Ϊencoding��ch��Ӧ��ƴ��</returns>
        public static string GetPinyin(char ch, Encoding encoding)
        {
            ch = ConvertEncoding(ch.ToString(), encoding, Encoding.UTF8)[0];
            return ConvertEncoding(GetPinyin(ch), Encoding.UTF8, encoding);
        }

        /// <summary>
        /// ת������ 
        /// </summary>
        /// <param name="text">�ı�</param>
        /// <param name="srcEncoding">Դ����</param>
        /// <param name="dstEncoding">Ŀ�����</param>
        /// <returns>Ŀ������ı�</returns>
        public static string ConvertEncoding(string text, Encoding srcEncoding, Encoding dstEncoding)
        {
            byte[] srcBytes = srcEncoding.GetBytes(text);
            byte[] dstBytes = Encoding.Convert(srcEncoding, dstEncoding, srcBytes);
            return dstEncoding.GetString(dstBytes);
        }

        /// <summary>
        /// ȡ�ı�����ֵ
        /// </summary>
        /// <param name="ch">�ַ�</param>
        /// <returns>�ı�����ֵ</returns>
        private static short GetHashIndex(char ch)
        {
            return (short)((uint)ch % PyCode.codes.Length);
        }

        /// <summary>
        /// �鿴���û������Ƿ��Ǹ���
        /// ������
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool GetFuxing(string name)
        {
            if (name.Length < 2) { return false; }
            string xing = name.Substring(0, 2);
            string[] fuxing = new string[] {"ŷ��","̫ʷ","��ľ","�Ϲ�","˾��","����","����","�Ϲ�","��ٹ","����","�ĺ�","���","ξ��","����","����","�̨","�ʸ�","����","���","��ұ","̫��","����","����","Ľ��","����","����","����","����","˾ͽ","����",
                "˾��","����","�ӳ�","����","˾��","����","����","���","����","����","���","����","�׸�","����","�ذ�","�й�","��ԯ","���","�θ�","����","����","����","����","����","΢��","����","����","����","����","����","����","����","��ɽ","����",
                "����"," ����","����","����","����","����","����","���","����","����","����","�ٳ�","����","��ɣ","��ī","����","��ʦ","���� "};
            for (int i = 0; i < fuxing.Length; ++i)
            {
                if (fuxing[i].Trim() == xing) { return true; }
            }
            return false;
        }


        /// <summary>
        /// �ж��Ƿ��Ǻ���
        /// ������
        /// </summary>
        /// <param name="name">����</param>
        /// <returns></returns>
        public static bool IsHanzi(string name)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(name))
            {
                char[] c = name.ToCharArray();
                for (int i = 0; i < c.Length; i++)
                {
                    if (c[i] >= 0x4e00 && c[i] <= 0x9fbb) { result = true; }
                    else { result = false; }
                }
            }
            return result;
        }
    }
}
