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
                string tcfgs = Net.Post("https://api.ogfrp.cn", "action=getallconf&token=" + token);
                this.configs = tcfgs;
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        private bool HaveProxy(string ini)
        {
            try
            {
                var t = ini.Split('[');
                if(t.Length >= 3)
                {
                    return true;
                }
            }
            catch 
            {
                return false;
            }
            return false;
        }

        public IEnumerable<String> IniToProxy(string ini)
        {
            var tSped = ini.Split('[');
            string[] useful = new string[tSped.Length - 1];
            for(int i = 1; i < tSped.Length; i++)
            {
                useful[i - 1] = "[" + tSped[i];
            }
            string[] result = new string[useful.Length - 1];
            for(int i = 0; i < result.Length; i++)
            {
                result[i] = useful[0] + "\n" + useful[i + 1];
            }
            return result;
        }

        public IEnumerable<String> ServerIniToCtn()
        {
            var tresult = configs.Split('|');
            int len = 0;
            for (int i = 0; i < tresult.Length; i++)
            {
                if (tresult[i] != "" && tresult[i] != "\n")
                {
                    len++;
                }
            }
            string[] result = new string[len];
            for(int i = 0; i < result.Length; i++)
            {
                result[i] = tresult[i];
            }
            return result;
        }

        public IEnumerable<String> GetProxyCtn()
        {
            List<String> result = new List<String>();
            var sictn = ServerIniToCtn();
            foreach (var srv in sictn)
            {
                if (HaveProxy(srv))
                {
                    var pini = IniToProxy(srv);
                    foreach (var pxy in pini)
                    {
                        result.Add(pxy);
                    }
                }
            }
            return result;
        }

        public IEnumerable<FrpcCover> ProxyDisplays()
        {
            string[] proxys = GetProxyCtn().ToArray();
            int len = proxys.ToArray().Length;
            FrpcCover[] result = new FrpcCover[len];
            for(int i = 0; i < len; i++)
            {
                result[i] = new FrpcCover();
                result[i].iniFile = proxys[i];
            }
            return result;
        }

    }
}
