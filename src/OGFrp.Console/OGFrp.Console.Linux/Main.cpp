#include "CrossPlatform.h"

using namespace OGFrp::Console;

CrossPlatFormCore cpf(P_Linux);

int main() {
	cpf.createFolder();
	cpf.printWelcome();
	cpf.enter();
	return 0;
}