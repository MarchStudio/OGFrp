#include <iostream>
#include <string>
#include <stdlib.h>

using namespace std;

// dllmain.cpp : 定义 DLL 应用程序的入口点。
#include "pch.h"

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

namespace OGFrp {
    namespace Frp {

        class frpc {
        private:
            string frpcPath = "";
        public:

            frpc(string frpPath) {
                this->frpcPath = frpPath;
            }

            int launch(string iniPath) {
                string FRPC = "\"" + frpcPath + "\"";
                string INI = "\"" + iniPath + "\"";
                try
                {
                    system((FRPC + " -c " + INI).c_str());
                    return 0;
                }
                catch (const std::exception&)
                {
                    return -1;
                }
            }

            int kill() {

            }
        }

    }
}
