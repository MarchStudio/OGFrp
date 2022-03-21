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
  echo "即将开始删除OGFrp.Linux"
  sleep 3

  echo "[x] rm -irf ${ogfrp_install_path}"
  rm -irf ${ogfrp_install_path}

  echo "rm -irf /usr/bin/frpc"
  rm -irf /usr/bin/frpc

  echo "rm -irf /usr/bin/ogfrp"
  rm -irf /usr/bin/ogfrp

  Finish
}


Finish() {
  echo "OGFrp.Linux 已卸载完成"
  exit
}

echo "+---------------------------------------------------------------------
| OGFrp.Linux Uninstall
+----------------------------------------------------------------------
| Shell Uninstall Script by OldGodShen
+----------------------------------------------------------------------
"

Uninstall_OGFrp