using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OGFrpCore
{

    /// <summary>
    /// 多语言资源
    /// </summary>
    public class Assets
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
            Letsgo = "我们开始吧",
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
            Letsgo = "Let's go"
            Username = "Username",
            Passward = "Passward",
            ServerAddr = "Server IP"
        };
    }
}
