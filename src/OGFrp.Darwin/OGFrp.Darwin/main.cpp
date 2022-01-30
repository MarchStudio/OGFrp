#include "work.cpp"
#include "libDarwin.cpp"

#define Arch "arm64"
#define Darwin "Darwin"

OGFrp ogfrp(get_cur_executable_path_(), Arch, Darwin);

int main() {
	return ogfrp.main();
}