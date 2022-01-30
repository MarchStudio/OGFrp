#include <iostream>
#include <unistd.h>

std::string get_cur_executable_path_() {
	std::string result;
    const int MAXPATH = 2500;
    char buffer[MAXPATH];
    getcwd(buffer, MAXPATH);
    result = buffer;
    return result;
}