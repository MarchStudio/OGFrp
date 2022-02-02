using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OGFrp.UI
{
    /// <summary>
    /// 多语言资源模型
    /// </summary>
    public class AssetModel
    {
        /// <summary>
        /// 语言记录名字
        /// </summary>
        public string LangNameS { get; set; }
        /// <summary>
        /// 语言显示名字
        /// </summary>
        public string LangNameD { get; set; }
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
        /// 登录：登录
        /// </summary>
        public string Login { get; set; }
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
        /// <summary>
        /// 面板：下载Frpc
        /// </summary>
        public string DownloadFrpc { get; set; }
        /// <summary>
        /// 面板：下载Frpc中
        /// </summary>
        public string DownloadingFrpc { get; set; }
        /// <summary>
        /// 面板：已下载Frpc
        /// </summary>
        public string DownloadedFrpc { get; set; }
        /// <summary>
        /// 下载：下载中
        /// </summary>
        public string Downloading { get; set; }
        /// <summary>
        /// 下载：下载失败
        /// </summary>
        public string DownloadFailed { get; set; }
        /// <summary>
        /// 面板：启动frpc
        /// </summary>
        public string LaunchFrpc { get; set; }
        /// <summary>
        /// 面板：请选择服务器
        /// </summary>
        public string PlzSelectServer { get; set; }
        /// <summary>
        /// frpc：显示日志
        /// </summary>
        public string ViewLog { get; set; }
        /// <summary>
        /// 面板：主页
        /// </summary>
        public string Home { get; set; }
        /// <summary>
        /// 主页：欢迎回来
        /// </summary>
        public string WelcomeBack { get; set; }
        /// <summary>
        /// 面板：映射
        /// </summary>
        public string Frp { get; set; }
        /// <summary>
        /// 应用程序：需要重启
        /// </summary>
        public string RestartRequired { get; set; }
        /// <summary>
        /// 面板：设置
        /// </summary>
        public string Settings { get; set; }
        /// <summary>
        /// 设置：语言
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// FrpcCover：点击复制
        /// </summary>
        public string ClickToDuplicate { get; set; }
        /// <summary>
        /// FrpcCover：已复制
        /// </summary>
        public string Duplicated { get; set; }
        /// <summary>
        /// 设置：Frpc启动模式
        /// </summary>
        public string FrpcLaunchMode { get; set; }
        /// <summary>
        /// Frpc启动模式：按隧道
        /// </summary>
        public string ByProxy { get; set; }
        /// <summary>
        /// Frpc启动模式：按节点
        /// </summary>
        public string ByNode { get; set; }
    }
}
