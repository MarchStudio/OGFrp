#include "work.cpp"
#include "libs.h"

#define Arch "x86"

OGFrp ogfrp(get_cur_executable_path_(),Arch);

int main() {
	return ogfrp.main();
}