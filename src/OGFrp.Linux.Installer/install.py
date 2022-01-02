import os

dirname, filename = os.path.split(os.path.abspath(__file__))

def main():
    print("  ____   _____ ______\n / __ \\ / ____|  ____|\n| |  | | |  __| |__ _ __ _ __\n| |  | | | |_ |  __| '__| '_ \\\n| |__| | |__| | |  | |  | |_) |\n \\____/ \\_____|_|  |_|  | .__/\n                        | |\n                        |_|\n")
    print("Welcone to install OGFrp.Linux!")
    print("Installer: 1.0.211231, based on Python, by GreatHuang2007")
    arch = input("Please select your arch[x86/amd64/arm/arm64]:")
    os.system("rm -rf /opt/OGFrp")
    os.system("mkdir /opt/OGFrp")
    if arch == "x86":
        print("Installing OGFrp.Linux x86 build...")
        os.system("rm -rf /usr/bin/ogfrp")
        os.system("rm -rf /usr/bin/frpc")
        os.system("cp " + dirname + "/frpc/i386 /opt/OGFrp/frpc")
        os.system("cp " + dirname + "/program/i386 /opt/OGFrp/OGFrp.Linux")
    elif arch == "amd64":
        print("Installing OGFrp.Linux amd64 build...")
        os.system("rm -rf /usr/bin/ogfrp")
        os.system("rm -rf /usr/bin/frpc")
        os.system("cp " + dirname + "/frpc/amd64 /opt/OGFrp/frpc")
        os.system("cp " + dirname + "/program/amd64 /opt/OGFrp/OGFrp.Linux")
    elif arch == "arm":
        print("Installing OGFrp.Linux arm build...") 
        os.system("rm -rf /usr/bin/ogfrp")
        os.system("rm -rf /usr/bin/frpc")
        os.system("cp " + dirname + "/frpc/arm /opt/OGFrp/frpc")
        os.system("cp " + dirname + "/program/arm /opt/OGFrp/OGFrp.Linux")
    elif arch == "arm64":
        print("Installing OGFrp.Linux arm64 build...") 
        os.system("rm -rf /usr/bin/ogfrp")
        os.system("rm -rf /usr/bin/frpc")
        os.system("cp " + dirname + "/frpc/arm64 /opt/OGFrp/frpc")
        os.system("cp " + dirname + "/program/arm64 /opt/OGFrp/OGFrp.Linux")
    else:
        print("Invaild arch.") 
        print("Installer will exit.")
        exit(0)
    os.system("ln /opt/OGFrp/OGFrp.Linux /usr/bin/ogfrp")
    os.system("ln /opt/OGFrp/frpc /usr/bin")
    os.system("chmod 777 /usr/bin/ogfrp")
    os.system("chmod 777 /usr/bin/frpc")
    print("Installtion done!")
    print("Installer will exit.")
    exit(0)

main()