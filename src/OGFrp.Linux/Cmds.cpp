#pragma once

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <iostream>
#include <istream>
#include <string>

#include "Project.h"

using namespace std;

namespace OGFrp {
	namespace Linux {
		namespace Cmd {
			void welcome() {
				printf("  ____   _____ ______\n / __ \\ / ____|  ____|\n| |  | | |  __| |__ _ __ _ __\n| |  | | | |_ |  __| '__| '_ \\\n| |__| | |__| | |  | |  | |_) |\n \\____/ \\_____|_|  |_|  | .__/\n                        | |\n                        |_|\n\n");
				printf("Welcome! OGFrp.Linux (Version %s %s)\n", Version, Arch);
				printf("\n");
				printf("  * Website:   https://ogfrp.cn \n");
				printf("  * GitHub:    https://github.com/oldgodshen/ogfrp \n");
				printf("  * Support:   https://jq.qq.com/?_wv=1027&k=whQ4pUD0 \n");
				printf("\n");
				printf("Type \"help\" to find more.\n");
				printf("\n");
			}

			string token = "\0";

			string inputToken() {
			reipt:
				printf("Please enter your access token:");
				string t;
				getline(cin, t);
				if (t.length() != 16) {
					printf("The token you entered does not seem to be correct.\nAre you sure to continue?[y/n]");
					string yn;
					getline(cin, yn);
					if (yn == "y") {
						return t;
					}
					else {
						goto reipt;
					}
				}
				return t;
			}

			void lsfrps() {
				printf("lsfrps\n");
			}

			void printHelp() {
				printf("-----OGFrp.Linux helper-----\n");
				printf("exit               Quit.\n");
				printf("lsfrps             List available frp servers, access token required.\n");
				printf("start [serverid]   Start frpc on the specified frp server. | serverid: ID of the frp server\n");
				printf("token              Print the token you set.\n");
				printf("token [token]      Set your OGFrp access token. | token: your OGFrp access token\n");
			}
		}
	}
}