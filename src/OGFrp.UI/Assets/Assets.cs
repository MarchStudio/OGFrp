using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OGFrp.UI
{

    /// <summary>
    /// 多语言资源
    /// </summary>
    public class Assets
    {

        public AssetModel[] AssetCollection = new AssetModel[]
        {
            new AssetModel
            {
                LangNameS = "zh_cn",
                LangNameD = "简体中文",
                Cancel = "取消",
                Close = "关闭",
                Yes = "是",
                No = "否",
                Welcome = "欢迎使用OGFrp",
                Loading = "正在加载...",
                Username = "用户名",
                Password = "密码",
                ServerAddr = "服务器地址",
                Letsgo = "我们开始吧",
                Login = "登录",
                Logining = "正在登录",
                LoginFailed = "登录失败！",
                UserInfo = "用户信息",
                AccessToken = "访问密钥",
                DownloadFrpc = "下载frpc.exe",
                DownloadingFrpc = "正在下载frpc.exe",
                DownloadedFrpc = "frpc.exe下载成功！",
                Downloading = "正在下载...",
                DownloadFailed = "下载失败！",
                LaunchFrpc = "启动隧道",
                PlzSelectServer = "请选择节点",
                ViewLog = "显示日志",
                Home = "主页",
                WelcomeBack = "欢迎回来",
                Frp = "映射",
                RestartRequired = "应用程序需要重启。",
                Settings = "设置",
                Language = "语言",
                ClickToDuplicate = "点击复制",
                Duplicated = "已复制"
            },
            new AssetModel
            {
                LangNameS = "en_us",
                LangNameD = "English",
                Cancel = "Cancel",
                Close = "Close",
                Yes = "Yes",
                No = "No",
                Welcome = "Welcome to OGFrp!",
                Loading = "Loading...",
                Username = "Username",
                Password = "Password",
                ServerAddr = "Server IP",
                Letsgo = "Let's go!",
                Login = "Login",
                Logining = "Logining...",
                LoginFailed = "Login failed!",
                UserInfo = "User info",
                AccessToken = "Access Token",
                DownloadFrpc = "Download frpc.exe",
                DownloadingFrpc = "Downloading frpc.exe...",
                DownloadedFrpc = "Frpc has successfully downloade!",
                Downloading = "Downloading...",
                DownloadFailed = "Ops! There seems to be something wrong while downloading.",
                LaunchFrpc = "Launch Frpc",
                PlzSelectServer = "Please select a server:",
                ViewLog = "View Log",
                Home = "Home",
                WelcomeBack = "Welcome Back!",
                Frp = "Frp",
                RestartRequired = "Application requires to be restarted.",
                Settings = "Settings",
                Language = "Language",
                ClickToDuplicate = "Click to duplicate.",
                Duplicated = "Duplicated!"
            }
        };

        /// <summary>
        /// 中文(简体)
        /// </summary>
        public AssetModel zh_cn;

        /// <summary>
        /// English
        /// </summary>
        public AssetModel en_us;

        public Assets()
        {
            this.zh_cn = this.AssetCollection[0];
            this.en_us = this.AssetCollection[1];
        }

        public string LangNameStoD(string LangNameS)
        {
            string result = "null";
            foreach (var i in this.AssetCollection)
            {
                if (i.LangNameS == LangNameS)
                    result = i.LangNameD;
            }
            return result;
        }

        public string LangNameDtoS(string LangNameD)
        {
            string result = "null";
            foreach (var i in this.AssetCollection)
            {
                if (i.LangNameD == LangNameD)
                    result = i.LangNameS;
            }
            return result;
        }
    }
}
