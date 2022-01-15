using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace OGFrp.UI
{
    public class FrpcCollections
    {

        string token;

        public FrpcCollections(string token)
        {
            this.token = token; 
        }

        string configs;

        public int getFrpcConfigCollection()
        {
            try
            {
                string tcfgs = Net.Post("https://api.ogfrp.cn", "action=fuckconf&token=" + token);
                this.configs = tcfgs;
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public IEnumerable<FrpcCover> ServerIniToCtn(string content)
        {
            FileSystem.WriteAllText(Config.FolderPath + "\\proxys.tmp", content, false);
            var reader = new StreamReader(Config.FolderPath + "\\proxys.tmp");

        }

        public IEnumerable<FrpcCover> GetLists()
        {
            System.Collections.ArrayList tResult = new System.Collections.ArrayList();

            FrpcCover[] result = new FrpcCover[tResult.Count];
            return result;
        }
    }
}
