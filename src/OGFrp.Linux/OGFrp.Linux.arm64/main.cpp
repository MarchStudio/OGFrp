#include "work.cpp"
#include "libs.h"

#define Arch "arm64"

OGFrp ogfrp(get_cur_executable_path_(), Arch);

int main() {
	return ogfrp.main();
}