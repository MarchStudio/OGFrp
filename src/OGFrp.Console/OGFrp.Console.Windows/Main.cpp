#include "CrossPlatform.h"

using namespace OGFrp::Console;

CrossPlatFormCore cpf(P_Windows);

int main() {
	cpf.createFolder();
	cpf.printWelcome();
	cpf.enter();
	return 0;
}