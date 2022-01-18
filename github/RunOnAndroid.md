[Readme](https://github.com/OldGodShen/OGFrp/blob/master/README.md#ogfrp)

# 有关在Android上使用OGFrp

## I.引言

众所周知，Android的内核也是Linux。因此，在Android上运行OGFrp.Linux完全可行！

## II.准备工作
使用Termux，在Android上模拟Linux环境。

有关如何安装Tremux，请参阅这篇[文章](https://blog.csdn.net/ii719481781/article/details/102165960)

## III.在Termux中安装OGFrp.Linux

### 1.安装必备工具

在Termux终端中，输入如下命令

    $ pkg install wget curl zip

按提示操作，安装即可。（pkg和apt很相似）

### 2.下载OGFrp.Linux

在Termux终端中，输入如下命令

    $ cd ~
    $ wget https://client.ogfrp.cn/
    OGFrp/OGFrp.Linux.zip

### 3.安装OGFrp.Linux

#### 3.1.对于已root设备

若您的Android设备已root，那么您可以参考我们提供的[在Linux发行版上OGFrp.Linux的方案](https://github.com/OldGodShen/OGFrp/blob/master/github/UseLinux.md#ogfrplinux%E4%BD%BF%E7%94%A8%E5%B8%AE%E5%8A%A9)。

#### 3.2.对于未root设备

当然，如果您的Android设备没有root，也不意味着您无法安装和运行OGFrp.Linux。我们将给出无root安装OGFrp.Linux的方案

#### 3.2.1.解压

在Termux终端中，输入如下命令

    $ unzip ./OGFrp.Linux.zip

#### 3.2.2.免root安装

在Termux终端中，输入如下命令

    $ mv ./OGFrp.Linux/program/arm ~/ogfrp
    $ mv ./OGFrp.Linux/frpc/arm ~/frpc

#### 3.2.3.启动

在Termux终端中，输入如下命令

    $ ~/ogfrp

## III.开启frp之旅

参见https://github.com/OldGodShen/OGFrp/blob/master/github/UseLinux.md#ogfrplinux%E4%BD%BF%E7%94%A8%E5%B8%AE%E5%8A%A9

---

## 最后，我们很荣幸您选择OGFrp，祝您使用愉快！
