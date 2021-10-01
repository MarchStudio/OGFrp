using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGFrpCore
{
    class Config
    {

        public Config()
        {
            ReadConfig();
        }

        /// <summary>
        /// ASCII码转字符
        /// </summary>
        /// <param name="asciiCode">ASCII码值</param>
        /// <returns>ASCII码对应的字符</returns>
        public static char Chr(int asciiCode)
        {
            if (asciiCode >= 0 && asciiCode <= 255)
            {
                ASCIIEncoding asciiEncoding = new ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                char strCharacter = asciiEncoding.GetString(byteArray)[0];
                return (strCharacter);
            }
            else
            {
                throw new Exception("ASCII Code is not valid.");
            }
        }

        /// <summary>
        /// config.ini的位置
        /// </summary>
        private string configpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OGFrp\\config.ini";

        /// <summary>
        /// 重新载入配置文件
        /// </summary>
        /// <returns>0表示成功，-1表示有异常发生</returns>
        public int ReadConfig()
        {
            try
            {
                StreamReader reader = new StreamReader(configpath);
                string Left = ""; //配置名(等号左边的内容)
                string Right = "";  //配置值(等号右边的内容)
                while(Left == "::end" && Right == "1")
                {
                    char temp = Chr(reader.Read());
                }
            }
            catch
            {
                return -1;
            }
            return 0;
        }


        /// <summary>
        /// 配置信息
        /// </summary>
        public struct config
        {
            /// <summary>
            /// 设置的语言
            /// </summary>
            public string lang { get; set; }
        }



        public string GetLang()
        {
            StreamReader reader = new StreamReader(configpath);

            return 
        }

    }
}
