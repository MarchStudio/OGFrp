using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;

namespace OGFrp.UI
{
    public class Frp
    {
        Net Net = new Net();
        Config Config = new Config();

        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OGFrp";

        public int DownloadFrpc()
        {
            try
            {
                Net.Download("https://api.ogfrp.cn/win/frpc.exe", path + "\\frpc.exe");
            }
            catch (Exception)
            {
                return -1;
            }
            return 0;
        }

        public int reDownloadFrpc()
        {
            try
            {
                Net.Download("https://api.ogfrp.cn/win/frpc.exe", path + "\\frpc.exe", true);
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 0; ;
        }

        public int serverToId(string server)
        {
            switch (server)
            {
                case "hk1.ogfrp.cn":
                    return 1;
                case "sh1.ogfrp.cn":
                    return 2;
                default:
                    return 0;
            }
        }

        public int launchFrpc(string token, string server)
        {
            try
            {
                File.WriteAllText(Config.FolderPath + "\\frpc.ini", Net.Get("https://ogfrp.cn/api/?action=getconf&token=" + token + "&node=" + serverToId(server)));
                Interaction.Shell(Config.FolderPath + "\\frpc.exe -c \"" + Config.FolderPath + "\\frpc.ini\"", AppWinStyle.NormalFocus);
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 0;
        }
    }
}
