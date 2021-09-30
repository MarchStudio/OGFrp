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
