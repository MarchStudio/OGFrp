#include "CrossPlatformCore.h"

using namespace OGFrp::Console;

CrossPlatFormCore cpf(P_Linux, F_arm64);

int main() {
	return cpf.enter();
}