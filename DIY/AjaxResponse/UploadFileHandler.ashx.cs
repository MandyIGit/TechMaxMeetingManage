using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using BLL;

namespace DIY.AjaxResponse
{
    /// <summary>
    /// UploadFileHandler 的摘要说明
    /// </summary>
    public class UploadFileHandler : PageBaseHandler
    {
        HttpRequest requst;
        HttpResponse response;

        protected override void GetData(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            requst = context.Request;
            response = context.Response;
            string contextType = requst["type"];
            string postvalue = requst["postvalue"];
            switch (contextType)
            {
                case "UploadFile":
                    //上传文件到服务器
                    UploadFile(context, postvalue);
                    break;
            }
        }

        private void UploadFile(HttpContext context, string postvalue)
        {
            string verifyToken = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("unique_salt" + context.Request["timestamp"], "md5");
            HttpPostedFile file = context.Request.Files["Filedata"];
            string uploadPath = postvalue;
            string path = "";
            string errorMsg = "";
            if (file != null && context.Request["token"] == verifyToken)
            {
                int fileLength = file.ContentLength;//文件大小，单位byte
                string fileName = Path.GetFileName(file.FileName);//文件名称
                string extension = Path.GetExtension(file.FileName).ToLower();//文件扩展名
                //限制上传文件最大不能超过2000M
                if (!(fileLength < 2 * 1024 * 1024))
                {
                    response.Write("文件仅支持最大不能超过2M！");
                    return;
                }
                //限制文件格式
                if (!".jpg.jpeg.png.gif.css".Contains(extension))
                {
                    response.Write("仅支持.jpg.jpeg.png.gif.css的文件格式！");
                    return;
                }
                //创建文件夹
                string ftpURI = uploadPath;
                try
                {
                    List<string> str = FtpHelper.GetDirctory(ftpURI);
                    if (str.Count == 0)
                    {
                        FtpHelper.MakeDir(ftpURI);
                    }
                }
                catch (Exception ex)
                {
                    response.Write(ex.ToString());
                }
                //准备上传文件
                Stream fileStream = null;
                try
                {
                    fileStream = file.InputStream;//读取本地文件流
                    bool b = FtpHelper.Upload(ftpURI, fileName, fileLength, fileStream, out errorMsg);//开始上传
                    if (b)
                    {
                        path = ftpURI + "/" + fileName;
                        path = path.Replace("//", "/");
                        response.Write(path);
                    }
                    else
                    {
                        response.Write("上传失败！" + errorMsg);
                    }
                }
                catch (Exception ex)
                {
                    response.Write("上传失败！" + ex.ToString());
                }
                finally
                {
                    if (fileStream != null) fileStream.Close();
                }
            }
            else
            {
                response.Write("文件路径错误！");
            }
        }
    }
}