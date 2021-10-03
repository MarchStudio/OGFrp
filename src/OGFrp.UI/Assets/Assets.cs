using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OGFrp.UI
{

    /// <summary>
    /// 多语言资源
    /// </summary>
    public partial class Assets
    {

        /// <summary>
        /// 中文(简体)
        /// </summary>
        public AssetModel zh_cn = new AssetModel
        {
            Cancel = "取消",
            Close = "关闭",
            Yes = "是",
            No = "否",
            Welcome = "欢迎使用OGFrp！",
            Loading = "正在加载...",
            Username = "用户名",
            Passward = "密码",
            ServerAddr = "服务器地址"
        };

        /// <summary>
        /// English
        /// </summary>
        public AssetModel en_us = new AssetModel
        {
            Cancel = "Cancel",
            Close = "Close",
            Yes = "Yes",
            No = "No",
            Welcome = "Welcome to OGFrp!",
            Loading = "Loading...",
            Username = "Username",
            Passward = "Passward",
            ServerAddr = "Server IP"
        };
    }
}
