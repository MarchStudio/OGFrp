#pragma once

#include <stdio.h>
#include <string.h>
#include <sys/statfs.h>
#include <limits.h>
#include <unistd.h>

#include <iostream>
#include <string>

/// get executable path
std::string get_cur_executable_path_();