#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <iostream>

#define Windows (1.0)
#define Linux_i386 (2.1)
#define Linux_amr64 (2.2)
#define Linux_arm64 (2.3)

using namespace std;

namespace OGFrp {
    namespace Console {
        namespace Files {

            //获取OGFrp的Appdata文件夹路径
            const char* getAppdataLoca(int platform) {
                switch (platform)
                {
                case 1:
                    return "%appdata%/OGFrp";
                case 2:
                    return "~/.ogfrp";
                default:
                    return "\0";
                }
            }
        }

        class CrossPlatFormCore {
        private:
            int Platform = 0;
            const char *CoreVersion = "1.0.0";

            const char* getPlatform() {
                switch (Platform)
                {
                case 1:
                    return "Windows";
                case 2:
                    return "Linux";
                default:
                    return "Unknown";
                }
            }

        public:
            CrossPlatFormCore(int platform) {
                this->Platform = platform;
            }

            void printWelcome() {
                printf("OGFrp,.Console.\nCross-Platform core version %s.\nRunning on %s.\n", CoreVersion, getPlatform());
            }

            char token[16] = {0};

            char enter() {
                printf("Please enter access token:");
                for (int i = 0; i < 16; i++) {
                    scanf("%c", &token[i]);
                }
                return 0;
            }

            //创建ogfrp的Appdata文件夹
            int createFolder() {
                switch (this->Platform)
                {
                case 1:
                    system("mkdir %appdata%/OGFrp");
                case 2:
                    system("~/.ogfrp");
                default:
                    return -1;
                }
                    return 0;
            }

            int launchfrpc() {
                
                return 0;
            }

        };
    }
}