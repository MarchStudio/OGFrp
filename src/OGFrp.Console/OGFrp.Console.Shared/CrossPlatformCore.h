#pragma once
#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <string>

#include "CrossPlatformHead.h"

using namespace std;

namespace OGFrp {
    namespace Console {

        class CrossPlatFormCore {
        private:
            const char* CoreVersion = "21.10.1";

            int Platform, Framework;

            string getFramework() {
                switch (this->Framework) {
                case F_amd64:
                    return "x86_64";
                case F_arm64:
                    return "arm64";
                default:
                    return "Unknown framework";
                }
            }

            string getPlatform() {
                switch (this->Platform) {
                case P_Windows:
                    return "Windows";
                case P_Linux:
                    return "Linux (" + getFramework() + ")";
                default:
                    return "Unknown";
                }
            }

        public:
            /// <summary>
            /// 构造跨平台对象
            /// </summary>
            /// <param name="platform">平台</param>
            /// <param name="framework">架构</param>
            CrossPlatFormCore(int platform, int framework) {
                this->Platform = platform;
                this->Framework = framework;
            }

            void printWelcome() {
                printf("  ____   _____ ______\n \/ __ \\ \/ ____|  ____|\n| |  | | |  __| |__ _ __ _ __   OGFrp.Console.\n| |  | | | |_ |  __| '__| '_ \\\n| |__| | |__| | |  | |  | |_) | Cross-Platform core version %s.\n \\____\/ \\_____|_|  |_|  | .__\/\n                        | |     Running on %s.\n                        |_|\n\n", CoreVersion, getPlatform().c_str());
            }


            string token; //OGFrp账号的的AccessToken

            /// <summary>
            /// 开始执行跨平台代码
            /// </summary>
            int enter() {
                createFolder();
                printWelcome();
                printf("Please enter access token:");
                for (int i = 0; i < 16; i++) {
                    char t;
                    scanf("%c", &t);
                    this->token += t;
                }
                printf("Launching frpc..\n");
                launchfrpc();
                return 0;
            }

            /// <summary>
            /// 创建OGFrp的Appdata文件夹
            /// </summary>
            int createFolder() {
                switch (this->Platform) {
                case P_Windows:
                    system("mkdir \"%appdata%\\OGFrp\"");
                    break;
                case P_Linux:
                    system("mkdir ~/.OGFrp");
                    break;
                default:
                    return -1;
                }
                return 0;
            }

            //获取OGFrp的Appdata文件夹路径
            string getAppdataLoca() {
                switch (this->Platform) {
                case P_Windows:
                    return "\"%appdata%\\OGFrp\"";
                case P_Linux:
                    return "~/.OGFrp";
                default:
                    return "\0";
                }
            }

            int launchfrpc() {
                switch (this->Platform) {
                case P_Windows:
                    system("%appdata%\\OGFrp\\frpc.exe -c %appdata%\\OGFrp\\frpc.ini");
                    break;
                case P_Linux:
                    system("~/OGFrp/frpc -c ~/.OGFrp/frpc.ini");
                    break;
                default:
                    printf("Invaild Platform.");
                    break;
                }
                return 0;
            }
        };
    }
}