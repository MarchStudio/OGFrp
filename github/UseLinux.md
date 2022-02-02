# OGFrp.Linux使用帮助

## I.安装
### 1. 解压
    $ unzip OGFrp.Linux.zip
### 2. 安装依赖
#### Debian/Ubuntu：
    $ sudo apt install -y python curl
#### Red Hat/Fedora：
    $ sudo yum install -y python3 curl
### 3. 安装
    $ sudo python install.py
* 在此处需要注意的是，OGFrp.Linux的安装程序无法在Python 2环境中正常运行，这意味着你需要使用Python 3来启动安装程序
### 4.  启动
    $ ogfrp

---

## II.开启frp之旅
当你启动了ogfrp后，你的终端应该是这个样子：

    Welcome! OGFrp.Linux (Version 1.0.1217 amd64)

      * Website:   https://ogfrp.cn
      * GitHub:    https://github.com/oldgodshen/ogfrp
      * Support:   https://jq.qq.com/?_wv=1027&k=whQ4pUD0

    Type "help" to find more.
    
    OGFrp> 

此时，你需要做的，便是告诉OGFrp.Linux你的用户Token，你可以使用这条命令：

    OGFrp> token 1a2b3c4d5e6f7890

其中，1a2b3c4d5e6f7890应替换成你的OGFrp用户Token。

当然，OGFrp.Linux有自动检查token的功能，若您收到了这样的提示：

    OGFrp> token 123
    The token you entered does not seem to be correct.
    Your frp service may not work properly.
    Are you sure to continue?[y/N]

则意味着您可能输入了一个错误的token，frp可能无法正常运行。

此时，我们建议您输入“n”或“N”，然后重新输入token，就像这样子：

    OGFrp> token 123
    The token you entered does not seem to be correct.
    Your frp service may not work properly.
    Are you sure to continue?[y/N]n
    Token not set.
    OGFrp> token 1a2b3c4d5e6f7890
    Token set.

若您想查看您设置的token，请使用token命令，就像这样：

    OGFrp> token 1a2b3c4d5e6f7890
    Token set.
    OGFrp> token
    The token you set is 1a2b3c4d5e6f7890.

### 注意：OGFrp.Linux目前还无法保存token，这意味着您需要在每次启动时重新输入token。

---

接着，您便可以使用start命令来启动frpc了！

就像这个样子：

    OGFrp> start 1
    Starting frpc...
    To stop frpc, please press Ctrl+C
    ...
    ... start proxy success

在上述示例中，“1”表示OGFrp节点服务器的ID，若您不清楚各个节点的ID，您可以使用lsfrps命令来列出所有的OGFrp节点服务器，就像这个样子：

    OGFrp> lsfrps

    1|香港1|30Mbp/s 可http/https|hk1.ogfrp.cn
    2|上海1|60Mbp/s 不可http/https|sh1.ogfrp.cn
    4|成都1|8Mbp/s 可https 不可http|ct1.ogfrp.cn
    5|北京1|5Mbp/s 可https 不可http|bj1.ogfrp.cn
    6|北京2|100Mbp/s 不可http/https|bj2.ogfrp.cn
    8|美国 华盛顿 西雅图|2Gbp/s 可http/https|xyt.ogfrp.cn
    9|美国 加利福尼亚 圣何塞|1Gbp/s 可https/http|shs.ogfrp.cn
    
这样，您便可以轻松地找到OGFrp节点服务器对应的ID了。

### 注意：上述两个命令，只有在正确设置了您的OGFrp用户token之后才能正常运行。

---

此外，若您日后忘记了某些命令，您可以通过在OGFrp.Linux中使用“help”命令来列出OGFrp.Linux的所有命令以及它们的作用，就行这个样子：

    OGFrp> help
    -----OGFrp.Linux helper-----
    exit               Quit.
    lsfrps             List available frp servers, access token required.
    start [serverid]   Start frpc on the specified frp server. | serverid: ID of the frp server
    token              Print the token you set.
    token [token]      Set your OGFrp access token. | token: your OGFrp access token
    
---

## 最后，我们很荣幸您选择OGFrp，祝您使用愉快！
