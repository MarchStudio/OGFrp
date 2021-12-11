#pragma once

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <iostream>
#include <istream>
#include <string>

#include "Cmds.cpp"

using namespace std;
using namespace OGFrp::Linux::Cmd;

namespace OGFrp {
	namespace Linux {
		namespace Shell {
			/// <summary>
			/// 启动OGFrp Shell
			/// </summary>
			/// <returns>Shell的退出代码</returns>
			int shell() {
				while (true) {
					printf("OGFrp> ");
					string script;
					getline(cin, script);
					string cmd;
					{
						char t;
						for (int i = 0; i < script.length(); i++) {
							t = script[i];
							if (t == ' ') {
								break;
							}
							cmd += t;
						}
					}
					string args;
					for (int i = cmd.length() + 1; i < script.length(); i++) {
						args += script[i];
					}
					if (cmd == "exit") {
						return 0;
					}
					else if (cmd == "help") {
						printHelp();
					}
					else if (cmd == "token") {
						if (args == "") {
							cout << "The token you set is " << token << "." << endl;
						}
						else {
							if (args.length() == 16) {
								token = args;
								printf("Token set.\n");
							}
							else {
								printf("The token you entered does not seem to be correct.\nYour frp service may not work properly.\nAre you sure to continue?[y/n]");
								string judge;
								getline(cin, judge);
								if (judge == "y") {
									token = args;
									printf("Token set.\n");
								}
								else {
									printf("Token not set.\n");
								}
							}
						}
					}
					else if (cmd == "lsfrps") {
						lsfrps();
					}
					else {
						printf("%s: Command not found.\n", cmd.c_str());
					}
				}
			}
		}
	}
}