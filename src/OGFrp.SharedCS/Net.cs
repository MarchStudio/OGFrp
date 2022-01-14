using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Microsoft.VisualBasic;

namespace OGFrp.UI
{
    public class Net
    {
        public static string Get(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Proxy = null;
            request.KeepAlive = false;
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            myResponseStream.Close();

            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }
            return retString;
        }

        /// <summary>
        /// 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <param name="content">Post提交数据内容(utf-8编码的)</param>
        /// <returns></returns>
        public static string Post(string url, string content)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            #region 添加Post 参数
            byte[] data = Encoding.UTF8.GetBytes(content);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// 获取OGFrp用户的访问密钥
        /// </summary>
        /// <param name="Username">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns></returns>
        public static string GetAccessToken(string Username, string Password)
        {
            return Post("https://api.ogfrp.cn","action=gettoken&username=" + Username + "&password=" + Password);
        }

        public int Download(string source, string localPath, bool forceDownload = false)
        {
            if (forceDownload)
            {
                WebClient wc = new WebClient();
                wc.DownloadFile(source, localPath);
                wc.Dispose();
                return 0;
            }
            else if (!File.Exists(localPath))
            {
                WebClient wc = new WebClient();
                wc.DownloadFile(source, localPath);
                wc.Dispose();
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
