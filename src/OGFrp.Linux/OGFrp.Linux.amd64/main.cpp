#include "work.cpp"
#include "libs.h"

#define Arch "amd64"

OGFrp ogfrp(Arch); OGFrp ogfrp(get_cur_executable_path_(), Arch);

int main() {
	return ogfrp.main();
}