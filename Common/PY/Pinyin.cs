/**
 * NPinyin包含一个公开类Pinyin，该类实现了取汉字文本首字母、文本对应拼音、以及
 * 获取和拼音对应的汉字列表等方法。由于汉字字库大，且多音字较多，因此本组中实现的
 * 拼音转换不一定和词语中的字的正确读音完全吻合。但绝大部分是正确的。
 * 
 * 最后感谢百度网友韦祎提供的常用汉字拼音对照表。见下载地址：
 * http://wenku.baidu.com/view/d725f4335a8102d276a22f46.html
 * 
 * 最后，我想简要地说明一下我的设计思路：
 * 首先，我将汉字按拼音分组后建立一个字符串数组（见PyCode.codes），然后使用程序
 * 将PyCode.codes中每一个汉字通过其编码值使用散列函数：
 * 
 *     f(x) = x % PyCode.codes.Length
 *   { 
 *     g(f(x)) = pos(x)
 *     
 * 其中, pos(x)为字符x所属字符串所在的PyCode.codes的数组下标, 然后散列到同
 * PyCode.codes长度相同长度的一个散列表中PyHash.hashes）。
 * 当检索一个汉字的拼音时，首先从PyHash.hashes中获取和
 * 对应的PyCode.codes中数组下标，然后从对应字符串查找，当到要查找的字符时，字符
 * 串的前6个字符即包含了该字的拼音。
 * 
 * 此种方法的好处一是节约了存储空间，二是兼顾了查询效率。
 *
 * 如有意见，请与我联系反馈。我的邮箱是：qzyzwsy@gmail.com
 * 
 * 汪思言 2011年1月3日凌晨
 * */

/*
 * v0.2.x的变化
 * =================================================================
 * 1、增加对不同编码格式文本的支持,同时增加编码转换方法Pinyin.ConvertEncoding
 * 2、重构单字符拼音的获取，未找到拼音时返回字符本身.
 * 
 * 汪思言 2012年7月23日晚
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
        /// 取中文文本的拼音首字母
        /// </summary>
        /// <param name="text">编码为UTF8的文本</param>
        /// <returns>返回中文对应的拼音首字母</returns>

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
        /// 取中文文本的拼音首字母
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="encoding">源文本的编码</param>
        /// <returns>返回encoding编码类型中文对应的拼音首字母</returns>
        public static string GetInitials(string text, Encoding encoding)
        {
            string temp = ConvertEncoding(text, encoding, Encoding.UTF8);
            return ConvertEncoding(GetInitials(temp), Encoding.UTF8, encoding);
        }



        /// <summary>
        /// 取中文文本的拼音
        /// </summary>
        /// <param name="text">编码为UTF8的文本</param>
        /// <returns>返回中文文本的拼音</returns>

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
        /// 取中文文本的拼音
        /// </summary>
        /// <param name="text">编码为UTF8的文本</param>
        /// <param name="encoding">源文本的编码</param>
        /// <returns>返回encoding编码类型的中文文本的拼音</returns>
        public static string GetPinyin(string text, Encoding encoding)
        {
            string temp = ConvertEncoding(text.Trim(), encoding, Encoding.UTF8);
            return ConvertEncoding(GetPinyin(temp), Encoding.UTF8, encoding);
        }

        /// <summary>
        /// 取和拼音相同的汉字列表
        /// </summary>
        /// <param name="Pinyin">编码为UTF8的拼音</param>
        /// <returns>取拼音相同的汉字列表，如拼音“ai”将会返回“唉爱……”等</returns>
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
        /// 取和拼音相同的汉字列表，编码同参数encoding
        /// </summary>
        /// <param name="Pinyin">编码为encoding的拼音</param>
        /// <param name="encoding">编码</param>
        /// <returns>返回编码为encoding的拼音为pinyin的汉字列表，如拼音“ai”将会返回“唉爱……”等</returns>
        public static string GetChineseText(string pinyin, Encoding encoding)
        {
            string text = ConvertEncoding(pinyin, encoding, Encoding.UTF8);
            return ConvertEncoding(GetChineseText(text), Encoding.UTF8, encoding);
        }



        /// <summary>
        /// 返回单个字符的汉字拼音
        /// </summary>
        /// <param name="ch">编码为UTF8的中文字符</param>
        /// <returns>ch对应的拼音</returns>
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
        /// 返回单个字符的汉字拼音
        /// </summary>
        /// <param name="ch">编码为encoding的中文字符</param>
        /// <returns>编码为encoding的ch对应的拼音</returns>
        public static string GetPinyin(char ch, Encoding encoding)
        {
            ch = ConvertEncoding(ch.ToString(), encoding, Encoding.UTF8)[0];
            return ConvertEncoding(GetPinyin(ch), Encoding.UTF8, encoding);
        }

        /// <summary>
        /// 转换编码 
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="srcEncoding">源编码</param>
        /// <param name="dstEncoding">目标编码</param>
        /// <returns>目标编码文本</returns>
        public static string ConvertEncoding(string text, Encoding srcEncoding, Encoding dstEncoding)
        {
            byte[] srcBytes = srcEncoding.GetBytes(text);
            byte[] dstBytes = Encoding.Convert(srcEncoding, dstEncoding, srcBytes);
            return dstEncoding.GetString(dstBytes);
        }

        /// <summary>
        /// 取文本索引值
        /// </summary>
        /// <param name="ch">字符</param>
        /// <returns>文本索引值</returns>
        private static short GetHashIndex(char ch)
        {
            return (short)((uint)ch % PyCode.codes.Length);
        }

        /// <summary>
        /// 查看该用户名称是否是复姓
        /// 靳海云
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool GetFuxing(string name)
        {
            if (name.Length < 2) { return false; }
            string xing = name.Substring(0, 2);
            string[] fuxing = new string[] {"欧阳","太史","端木","上官","司马","东方","独孤","南宫","万俟","闻人","夏侯","诸葛","尉迟","公羊","赫连","澹台","皇甫","宗政","濮阳","公冶","太叔","申屠","公孙","慕容","仲孙","钟离","长孙","宇文","司徒","鲜于",
                "司空","闾丘","子车","亓官","司寇","巫马","公西","颛孙","壤驷","公良","漆雕","乐正","宰父","谷梁","拓跋","夹谷","轩辕","令狐","段干","百里","呼延","东郭","南门","羊舌","微生","公户","公玉","公仪","梁丘","公仲","公上","公门","公山","公坚",
                "左丘"," 公伯","西门","公祖","第五","公乘","贯丘","公皙","南荣","东里","东宫","仲长","子书","子桑","即墨","达奚","褚师","吴铭 "};
            for (int i = 0; i < fuxing.Length; ++i)
            {
                if (fuxing[i].Trim() == xing) { return true; }
            }
            return false;
        }


        /// <summary>
        /// 判断是否是汉字
        /// 靳海云
        /// </summary>
        /// <param name="name">姓名</param>
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
