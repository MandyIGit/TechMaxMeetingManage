using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace DIY.AjaxResponse
{
    /// <summary>
    /// meeting_user_pptHandler 的摘要说明
    /// </summary>
    public class meeting_user_pptHandler : PageBaseHandler
    {

        HttpRequest request;
        HttpResponse response;
        private string mid, mtype_id;

        protected override void GetData(HttpContext context)
        {
            sbContextWrite = new StringBuilder();
            request = context.Request;
            response = context.Response;
            string type = request.QueryString["type"];
            string xml = Convert.ToString(request.Params["postvalue"]);
            mid = request.Params["mid"];
            mtype_id = request.Params["mtype_id"];

            DataSet ds = null;

            if (!string.IsNullOrEmpty(xml) && xml != "")
            {
                ds = TechMaxClass.DataSetVerify(TechMaxClass.getDataSetfromXML(xml));
            }

            int pageIndex = 0;
            int pageSize = 10;

            if (ds != null)
            {
                if (ds.Tables[0].Columns[0].ColumnName == "pageIndex")
                {
                    pageIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["pageIndex"]);
                    pageSize = Convert.ToInt32(ds.Tables[0].Rows[0]["pageSize"]);
                }
            }

            switch (type)
            {
                case "1":
                    //得到文字拼音
                    GetWordPY(xml);
                    break;
                case "SaveUser_edit_msg":  //后台保存用户信息（修改）
                    SaveUser_edit_msg(xml);
                    break;
            }
        }

        #region 后台保存用户信息（修改）
        /// <summary>
        /// 后台保存用户信息（修改）
        /// </summary>
        /// <param name="xml">用户ID</param>
        private void SaveUser_edit_msg(string xml)
        {
            tech_meeting_user_ppt info = new tech_meeting_user_ppt();

            info.puid = Convert.ToInt32(xml);
            info.family_name = Convert.ToString(request["family_name"]).Trim();
            info.given_name = Convert.ToString(request["given_name"]).Trim();
            if (!string.IsNullOrEmpty(request["family_name_pinyin"]))
                info.family_name_pinyin = Convert.ToString(request["family_name_pinyin"]).Trim();
            if (!string.IsNullOrEmpty(request["given_name_pinyin"]))
                info.given_name_pinyin = Convert.ToString(request["given_name_pinyin"]).Trim();
            info.mobile = Convert.ToString(request["mobile"]).Trim();
            info.email = Convert.ToString(request["email"]).Trim();
            info.learnpost = Convert.ToString(request["learnpost"]).Trim();
            info.unit = Convert.ToString(request["unit"]).Trim();

            string img_urlpath_str = request["img_urlpath"].Trim();

            string imgpath = string.Empty;
            string iname = string.Empty;

            if (img_urlpath_str.Contains(","))
            {
                string[] img_urlpath_arr = img_urlpath_str.Split(',');
                byte[] imgData = Convert.FromBase64String(img_urlpath_arr[1]);

                if (imgData != null && imgData.Length != 0)
                {                    
                    try
                    {
                        MemoryStream memoryStream = new MemoryStream(imgData, 0, imgData.Length);
                        memoryStream.Write(imgData, 0, imgData.Length);
                        //  转成图片
                        Image image = Image.FromStream(memoryStream);
                        //  图片名称
                        iname = DateTime.Now.ToString("yyMMddhhmmss") + ".jpg";
                        image.Save(HttpContext.Current.Server.MapPath("\\Upload\\photo\\") + iname);  // 将图片存到本地
                        imgpath = ConfigHelper.GetConfigString("ch_index") + "/Upload/photo/" + iname;

                    }
                    catch
                    {
                        response.Write("Error");
                    }
                }
            }
            else
            {
                imgpath = img_urlpath_str;
            }

            info.img_urlpath = imgpath;
            info.penintro = Common.DEncrypt.DESEncrypt.Encrypt(Convert.ToString(request["penintro"]).Trim());

            int result = tech_meeting_user_pptManager.Instance.Operation(info, "edit");

            if (result == 1)
            {
                response.Write("OK");
            }
            else
            {
                response.Write("Error");
            }

        }
        #endregion

        #region 得到文字拼音
        /// <summary>
        /// 方法说明：得到文字拼音
        /// 创建人员：Jacky
        /// 创建日期：2014/12/23 14:21
        /// 修改日期：
        /// </summary>
        private void GetWordPY(string xml)
        {
            if (!string.IsNullOrEmpty(xml))
            {
                string word = xml;
                string pinyin = string.Empty;
                pinyin = Pinyin.GetPinyin(word);
                pinyin = pinyin.Substring(0, 1).ToUpper() + pinyin.Substring(1, pinyin.Length - 1).ToLower();
                sbContextWrite.Append(pinyin);
            }
            else
            {
                sbContextWrite.Append("");
            }
        }
        #endregion
    }
}