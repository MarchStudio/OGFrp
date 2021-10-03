using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGFrp.Test
{
    class Program
    {


        static void Main(string[] args)
        {
            OGFrp.UI.Config Config = new UI.Config();
            Config.Username.Val = "GreatHuang2007";
            Config.Passward.Val = "123";
            Config.Lang.Val = "zh_cn";
            Config.ServerAddr.Val = "localhost";
            Config.ReadConfig();
            Console.WriteLine(Config.Username.Name + "=" + Config.Username.Val);
            Console.WriteLine(Config.Passward.Name + "=" + Config.Passward.Val);
            Console.WriteLine(Config.Lang.Name + "=" + Config.Lang.Val);
            Console.WriteLine(Config.ServerAddr.Name + "=" + Config.ServerAddr.Val);
            //Config.WriteConfig();
            Process.Start(Config.configpath);
            Console.Read();
        }
    }
}
