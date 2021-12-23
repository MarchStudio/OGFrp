using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace OGFrp.UI
{
    public class FrpServer
    {

        /// <summary>
        /// Appdata/OGFrp的位置
        /// </summary>
        private readonly string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OGFrp";

        /// <summary>
        /// 将api.ogfrp.cn上的节点信息转换成FrpServerModel
        /// </summary>
        /// <param name="Content">将api.ogfrp.cn上的节点信息</param>
        public FrpServerModel StringToServer(string Content)
        {
            FrpServerModel result = new FrpServerModel();
            FileSystem.WriteAllText(FolderPath + "\\node.tmp", Content, false);
            StreamReader reader = new StreamReader(FolderPath + "\\node.tmp");
            char nc = (char)0;
            string ct = "";
            while(nc != '|')
            {
                nc = (char)reader.Read();
                if (nc != '|')
                    ct += nc;
            }
            result.ID = ct;
            result.Address = reader.ReadToEnd();
            return result;
        }
    }
}
