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
        public int ID { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 节点描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 节点IP
        /// </summary>
        public string Address { get; set; }
    }
}
