using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGFrp.UI
{
    public class SgProxy
    {

        /// <summary>
        /// 节点名称
        /// </summary>
        public string ServerName { get; set; }

        public SgProxy(string ini)
        {
            var spedIni = ini.Split('[');
            string common = "[" + ini[1];
        }

    }
}
