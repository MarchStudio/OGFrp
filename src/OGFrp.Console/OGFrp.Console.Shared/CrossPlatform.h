#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <iostream>

#include "Locals.h"

#define P_Windows 1
#define P_Linux 2
#define F_amd64 1
#define F_arm64 2

using namespace std;

namespace OGFrp {
    namespace Console {

        namespace Files {

            //获取OGFrp的Appdata文件夹路径
            const char* getAppdataLoca(int platform) {
                switch (platform) {
                case 1:
                    return "\"%appdata%\\OGFrp\"";
                case 2:
                    return "~/.OGFrp";
                default:
                    return "\0";
                }
            }
        }

        class CrossPlatFormCore {
        private:
            const char* CoreVersion = "21.10.1";

            int Platform, Framework;

            const char* getPlatform() {
                switch (Platform) {
                case 1:
                    return "Windows";
                case 2:
                    return "Linux";
                default:
                    return "Unknown";
                }
            }

        public:
            CrossPlatFormCore() {
#ifdef Windows
                this->Platform = P_Windows;
#elif defined Linux
                this->Platform = P_Linux;
#endif
            }

            void printWelcome() {
                printf("  ____   _____ ______\n \/ __ \\ \/ ____|  ____|\n| |  | | |  __| |__ _ __ _ __   OGFrp.Console.\n| |  | | | |_ |  __| '__| '_ \\\n| |__| | |__| | |  | |  | |_) | Cross-Platform core version %s.\n \\____\/ \\_____|_|  |_|  | .__\/\n                        | |     Running on %s.\n                        |_|\n\n", CoreVersion, getPlatform());
            }

            char token[16] = {0};

            char enter() {
                printf("Please enter access token:");
                for (int i = 0; i < 16; i++) {
                    scanf("%c", &token[i]);
                }
                printf("Launching frpc..\n");
                launchfrpc();
                return 0;
            }

            //创建ogfrp的Appdata文件夹
            int createFolder() {
                switch (this->Platform) {
                case 1:
                    system("mkdir \"%appdata%\\OGFrp\"");
                    break;
                case 2:
                    system("mkdir ~/.OGFrp");
                    break;
                default:
                    return -1;
                }
                return 0;
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