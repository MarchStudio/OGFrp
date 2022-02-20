#!/bin/bash
printf "\033c"

Other_Arch() {
  read -p "未知架构，默认选择为x64，请确认是否继续安装！(y/n):" choice;
  if [ "$choice" = 'y' ]; then
    arch="x64"
    elif [ "$choice" = 'n' ]; then
    Red_Error "已退出安装"
    else
    echo "未知选项"
    Other_Arch
  fi
}

Check_Arch(){
  if [ "$(uname -m)" = 'x86_64' ]; then
    arch="amd64"
    echo "系统架构为x64，将会安装x64的OGFrp"
    sleep 3
  elif [ "$(uname -m)" = 'i386' ]; then
    arch="386"
    echo "系统架构为x86，将会安装x86的OGFrp"
    sleep 3
  elif [ "$(uname -m)" = 'i486' ]; then
    arch="386"
    echo "系统架构为x86，将会安装x86的OGFrp"
    sleep 3
  elif [ "$(uname -m)" = 'i586' ]; then
    arch="386"
    echo "系统架构为x86，将会安装x86的OGFrp"
    sleep 3
  elif [ "$(uname -m)" = 'i686' ]; then
    arch="386"
    echo "系统架构为x86，将会安装x86的OGFrp"
    sleep 3
  elif [ "$(uname -m)" = 'aarch64' ]; then
    arch="arm64"
    echo "系统架构为arm64，将会安装arm64的OGFrp"
    sleep 3
  elif [ "$(uname -m)" = 'arm' ]; then
    arch="arm"
    echo "系统架构为arm，将会安装arm的OGFrp"
    sleep 3
  else
    Other_Arch
  fi
}

Red_Error() {
  echo '================================================='
  printf '\033[1;31;40m%b\033[0m\n' "$@"
  echo '================================================='
  exit 1
}

Install_OGFrp() {
  ogfrp_install_path="/opt/OGFrp"
  echo "即将开始安装OGFrp.Linux For ${arch}"
  sleep 3

  echo "mkdir ${ogfrp_install_path}"
  mkdir ${ogfrp_install_path}

  echo "[x] rm -irf ${ogfrp_install_path}"
  rm -irf ${ogfrp_install_path}

  echo "cp ./frpc/${arch} ${ogfrp_install_path}/frpc"
  cp ./frpc/${arch} ${ogfrp_install_path}/frpc

  echo "cp ./program/${arch} ${ogfrp_install_path}/ogfrp"
  cp ./program/${arch} ${ogfrp_install_path}/ogfrp

  echo "chmod +x ${ogfrp_install_path}/frpc"
  chmod +x ${ogfrp_install_path}/frpc

  echo "chmod +x ${ogfrp_install_path}/ogfrp"
  chmod +x ${ogfrp_install_path}/ogfrp

  echo "ln -s ${ogfrp_install_path}/frpc /usr/bin/frpc"
  ln -s ${ogfrp_install_path}/frpc /usr/bin/frpc

  echo "ln -s ${ogfrp_install_path}/ogfrp /usr/bin/ogfrp"
  ln -s ${ogfrp_install_path}/ogfrp /usr/bin/ogfrp

  Finish


Finish() {
  echo "OGFrp.Linux For ${arch} 已安装完成"
  echo "输入 ogfrp 即可使用"
  exit
}

echo "+---------------------------------------------------------------------
| OGFrp.Linux Install
+----------------------------------------------------------------------
| Shell Install Script by OldGodShen
+----------------------------------------------------------------------
"

Check_Arch
Install_OGFrp