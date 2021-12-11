#define Version "1.0.211204"
#define Arch "x86"

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <iostream>
#include <istream>
#include <string>

using namespace std;

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

int main()
{
	char* path = NULL;
	path = getcwd(NULL, 0);
	exePath = path;
	free(path);
	welcome();
	return shell(exePath);
}