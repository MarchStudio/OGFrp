using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGFrp.UI
{
    public partial class Config
    {


        ConfigModel[] ConfigArray = new ConfigModel[5];

        /// <summary>
        /// 构造函数
        /// </summary>
        public Config()
        {
            ConfigArray[0] = this.Lang;
            ConfigArray[1] = this.Username;
            ConfigArray[2] = this.Password;
            ConfigArray[3] = this.FrpcLaunchMode;
            ConfigArray[4] = this.Theme;
            try
            {
                ReadConfig();
            }
            catch
            {
                WriteConfig();
                ReadConfig();
            }
        }

        /// <summary>
        /// ASCII码转字符
        /// </summary>
        /// <param name="asciiCode">ASCII码值</param>
        /// <returns>ASCII码对应的字符</returns>
        public static string Chr(int asciiCode)
        {
            if (asciiCode >= 0 && asciiCode <= 255)
            {
                ASCIIEncoding asciiEncoding = new ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                string strCharacter = asciiEncoding.GetString(byteArray);
                return (strCharacter);
            }
            else
            {
                throw new Exception("ASCII Code is not valid.");
            }
        }

        /// <summary>
        /// Appdata/OGFrp的位置
        /// </summary>
        public static readonly string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OGFrp";

        /// <summary>
        /// 创建Appdata文件夹
        /// </summary>
        public void CreateFolder()
        {
            if (Directory.Exists(FolderPath) == false)
            {
                Directory.CreateDirectory(FolderPath);
            }
            return;
        }

        /// <summary>
        /// config.ini的位置
        /// </summary>
        public readonly string configpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OGFrp\\config.ini";

        /// <summary>
        /// 加载配置文件
        /// </summary>
        public void ReadConfig()
        {
            StreamReader reader = new StreamReader(configpath);
            string Left = ""; //配置名(等号左边的内容)
            string Right;  //配置值(等号右边的内容)
            while (Left != "::end")
            {
                Left = "";
                Right = "";
                //read left:
                int temp = 0;
                while (true)
                {
                    temp = reader.Read();
                    if (Chr(temp) == "=")
                    {
                        break;
                    }
                    else
                    {
                        Left += Chr(temp);
                    }
                }
                Right = reader.ReadLine();
                if (Left == "::end")
                {
                    reader.Close();
                    return;
                }
                switch (Left)
                {
                    case "Lang":
                        this.Lang.Val = Right;
                        break;
                    case "Username":
                        this.Username.Val = Right;
                        break;
                    case "Password":
                        this.Password.Val = Right;
                        break;
                    case "FrpcLaunchMode":
                        this.FrpcLaunchMode.Val = Right;
                        break;
                    case "Theme":
                        this.Theme.Val = Right;
                        break;
                    default:
                        break;
                }
            }
            reader.Close();
        }

        /// <summary>
        /// 写入配置文件
        /// </summary>
        public void WriteConfig()
        {
            CreateFolder();
            StreamWriter writer = new StreamWriter(configpath);
            string content = null;
            for (int i = 0; i < ConfigArray.Length; i++)
            {
                content += ConfigArray[i].Name;
                content += "=";
                content += ConfigArray[i].Val;
                content += "\n";
            }
            content += "::end=1";
            writer.Write(content);
            writer.Close();
        }

    }
}
