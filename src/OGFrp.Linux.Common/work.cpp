#define Version "1.0.220102"

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <iostream>
#include <istream>
#include <string>
#include <sys/stat.h>
#include <sys/types.h>

#include "libs.h"

using namespace std;

class OGFrp {

private:
	string Arch = "Unknown";

public:

	OGFrp(string Arch) {
		this->Arch = Arch;
	}

	void welcome() {
		system("mkdir ~/.OGFrp");
		printf("  ____   _____ ______\n / __ \\ / ____|  ____|\n| |  | | |  __| |__ _ __ _ __\n| |  | | | |_ |  __| '__| '_ \\\n| |__| | |__| | |  | |  | |_) |\n \\____/ \\_____|_|  |_|  | .__/\n                        | |\n                        |_|\n\n");
		printf("Welcome! OGFrp.Linux (Version %s %s)\n", Version, Arch.c_str());
		printf("\n");
		printf("  * Website:   https://ogfrp.cn \n");
		printf("  * GitHub:    https://github.com/oldgodshen/ogfrp \n");
		printf("  * Support:   https://jq.qq.com/?_wv=1027&k=whQ4pUD0 \n");
		printf("\n");
		printf("Type \"help\" to find more.\n");
		printf("\n");
	}

	string token = "\0";
	string exePath;

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
	}

	void lsfrps() {
		printf("\n");
		system(("curl \"https://api.ogfrp.cn/?action=getnodes&token=" + token + "\"").c_str());
		printf("\n");
	}

	void startfrpc(string nodeid, string actoken) {
		if (nodeid.length() < 1) {
			printf("Useage: start [serverid]\n");
			printf("Type \"help\" to find more.\n");
			return;
		}
		cout << "Starting frpc..." << endl;
		cout << "To stop frpc, please press Ctrl+C" << endl;
		string iniPath = "~/.OGFrp/frpc.ini";
		string curlsh = "curl \"https://api.ogfrp.cn/?action=getconf&token=" + token + "&node=" + nodeid + "\" -o " + iniPath;
		system(curlsh.c_str());
		string frpcsh = exePath + "/frpc -c " + iniPath;
		system(frpcsh.c_str());
		printf("\nFrpc exit.\n");
		return;
	}

	void printHelp() {
		printf("-----OGFrp.Linux helper-----\n");
		printf("exit               Quit.\n");
		printf("lsfrps             List available frp servers, access token required.\n");
		printf("start [serverid]   Start frpc on the specified frp server. | serverid: ID of the frp server\n");
		printf("token              Print the token you set.\n");
		printf("token [token]      Set your OGFrp access token. | token: your OGFrp access token\n");
	}

	int shell(string path) {
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
						printf("The token you entered does not seem to be correct.\nYour frp service may not work properly.\nAre you sure to continue?[y/N]");
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
			else if (cmd == "start") {
				startfrpc(args, token);
			}
			else if (cmd == "lsfrps") {
				lsfrps();
			}
			else if (cmd != "") {
				printf("%s: Command not found.\n", cmd.c_str());
			}
			else {
				continue;
			}
		}
	}

	int main() {
		exePath = get_cur_executable_path_();
		welcome();
		return shell(exePath);
	}
};