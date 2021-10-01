using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGFrpCore
{
    public partial class Config
    {

        /// <summary>
        /// 构造函数
        /// </summary>
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
        /// 加载配置文件
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
                    //read left:
                    char temp = '\0';
                    while(temp == '=')
                    {
                        Left += temp;
                        temp = Chr(reader.Read());
                    }
                    Right = reader.ReadToEnd();
                    switch (Left)
                    {
                        case "Lang":
                            this.lang = Right;
                            break;
                        default:
                            break;
                    }
                    Left = "";
                    Right = "";
                }
            }
            catch
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 写入配置文件
        /// </summary>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        public int WriteConfig(string Left, string Right)
        {
            try
            {

            }
            catch
            {
                return -1;
            }
            return 0;
        }

    }
}
