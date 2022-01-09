using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGFrp.Lite
{

    public class work
    {

        public work()
        {
            printWelcome();
            while (true)
            {
                shell();
            }
        }

        void printWelcome()
        {
            Console.Write("  ____   _____ ______\n / __ \\ / ____|  ____|\n| |  | | |  __| |__ _ __ _ __\n| |  | | | |_ |  __| '__| '_ \\\n| |__| | |__| | |  | |  | |_) |\n \\____/ \\_____|_|  |_|  | .__/\n                        | |\n                        |_|\n\n");
            Console.Write("Welcome! OGFrp.Lite (Version {0}, Windows Generic, .NET Framework {1})\n", Heading.Version, Heading.dotnetfxVersion);
            Console.Write("\n");
            Console.Write("  * Website:   https://ogfrp.cn \n");
            Console.Write("  * GitHub:    https://github.com/oldgodshen/ogfrp \n");
            Console.Write("  * Support:   https://jq.qq.com/?_wv=1027&k=whQ4pUD0 \n");
            Console.Write("\n");
            Console.Write("Type \"help\" to find more.\n");
            Console.Write("\n");
        }

        void shell()
        {
            Console.Write("OGFrp> ");
            string script = Console.ReadLine();
            string args = 
        }
    };
}
