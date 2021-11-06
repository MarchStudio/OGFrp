#include "CrossPlatformCore.h"

using namespace OGFrp::Console;

CrossPlatFormCore cpf(P_Linux, F_amd64);

int main() {
	return cpf.enter();
}