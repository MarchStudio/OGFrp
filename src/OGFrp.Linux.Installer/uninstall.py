import os

def main():
    print("  ____   _____ ______\n / __ \\ / ____|  ____|\n| |  | | |  __| |__ _ __ _ __\n| |  | | | |_ |  __| '__| '_ \\\n| |__| | |__| | |  | |  | |_) |\n \\____/ \\_____|_|  |_|  | .__/\n                        | |\n                        |_|\n")
    print("Uninstaller: 1.0.1218, based on Python, by GreatHuang2007")
    ready = input("Are you ready to uninstall[y/n]:")
    if(ready == "y"):
        os.system("rm -rf /usr/bin/ogfrp")
        os.system("rm -rf /usr/bin/frpc")
        os.system("rm -rf /opt/OGFrp")
        print("Uninstalltion done!")
        print("See you later!")
        print("Visit our website: https://ogfrp.cn")
    
    print("Uninstaller will exit.")

main()
