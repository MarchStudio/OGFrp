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

        private string configpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OGFrp\\config.ini";

        public struct config
        {
            /// <summary>
            /// 设置的语言
            /// </summary>
            public string lang { get; set; }


        public string GetLang()
        {
            StreamReader reader = new StreamReader(configpath);

            return 
        }

    }
}
