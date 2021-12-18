@echo off
echo Cleaning Pack Folder...
rd /s /q OGFrp.Linux.Pack
echo Creating pack folder...
mkdir OGFrp.Linux.Pack
mkdir OGFrp.Linux.Pack\frpc
mkdir OGFrp.Linux.Pack\program
echo Copying bin files...
copy bin\frpc_linux_i386 .\OGFrp.Linux.Pack\frpc\i386
copy bin\frpc_linux_amd64 .\OGFrp.Linux.Pack\frpc\amd64
copy bin\frpc_linux_arm64 .\OGFrp.Linux.Pack\frpc\arm64
copy src\OGFrp.Linux\OGFrp.Linux.i386\bin\x86\Debug\OGFrp.Linux.i386.out OGFrp.Linux.Pack\program\i386
copy src\OGFrp.Linux\OGFrp.Linux.amd64\bin\x64\Debug\OGFrp.Linux.amd64.out OGFrp.Linux.Pack\program\amd64
copy src\OGFrp.Linux\OGFrp.Linux.arm64\bin\ARM64\Debug\OGFrp.Linux.arm64.out OGFrp.Linux.Pack\program\arm64
echo Generating install scripts...
copy src\LinuxInstaller\install.py OGFrp.Linux.Pack
copy src\LinuxInstaller\uninstall.py OGFrp.Linux.Pack
echo Done!