using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGFrp.UI
{
    /// <summary>
    /// ConfigModel
    /// </summary>
    public class ConfigModel 
    {
        /// <summary>
        /// 设置：设置名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 设置：记录值
        /// </summary>
        public string Val { get; set; }
    }

    public partial class Config
    {
        /// <summary>
        /// 设置：语言
        /// </summary>
        public ConfigModel Lang = new ConfigModel
        {
            Name = "Lang"
        };

        /// <summary>
        /// 设置：用户名
        /// </summary>
        public ConfigModel Username = new ConfigModel
        {
            Name = "Username"
        };

        /// <summary>
        /// 设置：密码
        /// </summary>
        public ConfigModel Passward = new ConfigModel
        {
            Name = "Passward"
        };

        /// <summary>
        /// 设置：Server IP
        /// </summary>
        public ConfigModel ServerAddr = new ConfigModel
        {
            Name = "ServerAddr"
        };

        /// <summary>
        /// 设置：记住密码
        /// </summary>
        public ConfigModel RmbPsw = new ConfigModel
        {
            Name = "RmbPsw"
        };

    }
}
