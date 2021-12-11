#pragma once

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <iostream>
#include <istream>
#include <string>

#include "Shell.cpp"

using namespace std;

using namespace OGFrp::Linux;
using namespace OGFrp::Linux::Cmd;
using namespace OGFrp::Linux::Shell;

namespace OGFrp {
	namespace Linux {

		/// <summary>
		/// 二进制文件路径
		/// </summary>
		string exePath;

		/// <summary>
		/// “伪”入口点
		/// </summary>
		int enter() {
			char* path = NULL;
			path = getcwd(NULL, 0);
			exePath = path;
			free(path);
			welcome();
			return shell();
		}

	}
}