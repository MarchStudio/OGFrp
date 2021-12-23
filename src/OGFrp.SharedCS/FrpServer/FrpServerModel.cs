using System;
using System.Collections.Generic;
using System.Text;

namespace OGFrp.UI
{
    public class FrpServerModel
    {
        /// <summary>
        /// 节点ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 节点IP
        /// </summary>
        public string Address { get; set; }

        public override string ToString()
        {
            return ID + "|" + Address;
        }
    }
}
