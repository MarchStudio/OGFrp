using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OGFrp.UI
{
    public class FrpServer
    {
        /// <summary>
        /// 将api.ogfrp.cn上的节点信息转换成FrpServerModel
        /// </summary>
        /// <param name="Content">将api.ogfrp.cn上的节点信息</param>
        public FrpServerModel StringToServer(string Content)
        {
            FrpServerModel result = new FrpServerModel();

            var reader = new StreamReader(Content);

            return result;
        }
    }
}
