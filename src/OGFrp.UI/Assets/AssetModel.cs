using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OGFrp.UI
{
    public class AssetModel
    {
        /// <summary>
        /// 欢迎屏幕：Title
        /// </summary>
        public string Welcome { get; set; }
        /// <summary>
        /// 欢迎屏幕：Loading
        /// </summary>
        public string Loading { get; set; }
        /// <summary>
        /// 欢迎屏幕：Let's go!
        /// </summary>
        public string Letsgo { get; set; }
        /// <summary>
        /// 对话框：是
        /// </summary>
        public string Yes { get; set; }
        /// <summary>
        /// 对话框：否
        /// </summary>
        public string No { get; set; }
        /// <summary>
        /// 对话框：取消
        /// </summary>
        public string Cancel { get; set; }
        /// <summary>
        /// 对话框：关闭
        /// </summary>
        public string Close { get; set; }
        /// <summary>
        /// 登录：用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 登录：密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 登录：服务器地址
        /// </summary>
        public string ServerAddr { get; set; }
        /// <summary>
        /// 登录：正在登录
        /// </summary>
        public string Logining { get; set; }
        /// <summary>
        /// 登录：登录失败
        /// </summary>
        public string LoginFailed { get; set; }
        /// <summary>
        /// 面板：用户信息
        /// </summary>
        public string UserInfo { get; set; }
        /// <summary>
        /// 面板：Access Token
        /// </summary>
        public string AccessToken { get; set; }
    }
}
