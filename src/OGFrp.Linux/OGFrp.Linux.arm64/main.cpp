#include "work.cpp"

#define Version "1.0.1217"
#define Arch "arm64"

OGFrp ogfrp(Version, Arch);

int main() {
	return ogfrp.main();
}