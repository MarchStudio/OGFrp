using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGFrp.UI
{
    public class Gravatar
    {
        public static string ts;

        private static string GetMD5(string sDataIn)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;
            bytValue = System.Text.Encoding.UTF8.GetBytes(sDataIn);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }

        public static string FolderPath = Config.FolderPath + "\\head_imgs";

        /// <summary>
        /// 获取Gravatar头像
        /// </summary>
        /// <param name="email">邮箱地址</param>
        public static void getImage(string email)
        {
            if (Directory.Exists(FolderPath) == false)
            {
                Directory.CreateDirectory(FolderPath);
            }
            string url = "https://cdn.zerodream.net/images/gravatar/?id=" + GetMD5(email);
            System.Net.WebClient client = new System.Net.WebClient();
            client.DownloadFile(url, FolderPath + "\\" + email + ".png");
            return;
        }
    }
}
