#include "CrossPlatform.h"

using namespace OGFrp::Console;

CrossPlatFormCore cpf;

int main() {
	cpf.createFolder();
	cpf.printWelcome();
	cpf.enter();
	return 0;
}