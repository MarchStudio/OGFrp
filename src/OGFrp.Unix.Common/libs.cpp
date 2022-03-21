#pragma once

#include <sys/statfs.h>
#include <limits.h>
#include <unistd.h>
#include <iostream>
#include <string>

/// get executable path
std::string get_cur_executable_path_() {
    char* p = NULL;

    const int len = 256;
    /// to keep the absolute path of executable's path
    char arr_tmp[len] = { 0 };

    int n = readlink("/proc/self/exe", arr_tmp, len);
    if (NULL != (p = strrchr(arr_tmp, '/')))
        *p = '\0';
    else {
        return std::string("");
    }

    return std::string(arr_tmp);
}
