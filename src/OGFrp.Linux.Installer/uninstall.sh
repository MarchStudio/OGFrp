#!/bin/bash
printf "\033c"

Red_Error() {
  echo '================================================='
  printf '\033[1;31;40m%b\033[0m\n' "$@"
  echo '================================================='
  exit 1
}

Uninstall_OGFrp() {
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
}


Finish() {
  echo "OGFrp.Linux For ${arch} 已卸载完成"
  exit
}

echo "+---------------------------------------------------------------------
| OGFrp.Linux Uninstall
+----------------------------------------------------------------------
| Shell Uninstall Script by OldGodShen
+----------------------------------------------------------------------
"

Uninstall_OGFrp