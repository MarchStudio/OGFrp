using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Linq;

namespace OGFrp.UI
{
    public class FrpServer
    {

        private static int GetVowelCount(string source, string target)
        {
            return source.Count(i => target.Contains(i));
        }


        /// <summary>
        /// Appdata/OGFrp的位置
        /// </summary>
        private readonly string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OGFrp";

        /// <summary>
        /// 将api.ogfrp.cn上的一条节点信息转换成FrpServerModel
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
            reader.Close();
            FileSystem.DeleteFile(FolderPath + "\\node.tmp");
            return result;
        }

        /// <summary>
        /// 将api.ogfrp.cn上的全部节点列表信息转换为FrpServerList的Array
        /// </summary>
        /// <param name="Content">api.ogfrp.cn上返回的字符串</param>
        /// <returns></returns>
        public IEnumerable<FrpServerModel> FrpsServerList(string Content)
        {
            int len = GetVowelCount(Content, "\n");
            FrpServerModel[] result = new FrpServerModel[len];
            FileSystem.WriteAllText(FolderPath + "\\nodes.tmp", Content, false);
            StreamReader reader = new StreamReader(FolderPath + "\\nodes.tmp");
            for(int i = 0; i < len; i++)
            {
                result[i] = StringToServer(reader.ReadLine());
            }
            reader.Close();
            FileSystem.DeleteFile(FolderPath + "\\nodes.tmp");
            return result;
        }
    }
}
