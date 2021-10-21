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
        public string Get(string Url)
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
        /// 获取OGFrp用户的访问密钥
        /// </summary>
        /// <param name="Username">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns></returns>
        public string GetAccessToken(string Username, string Password)
        {
            return Get("https://ogfrp.cn/api/?action=gettoken&username=" + Username + "&password=" + Password);
        }

        public void Download(string source, string localPath, bool forceDownload = false)
        {
            if (forceDownload)
            {
                WebClient wc = new WebClient();
                wc.DownloadFile(source, localPath);
                wc.Dispose();
            }
            else if (!File.Exists(localPath))
            {
                WebClient wc = new WebClient();
                wc.DownloadFile(source, localPath);
                wc.Dispose();
            }
            else
            {
                return;
            }
            return;
        }
    }
}
