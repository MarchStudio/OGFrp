#include "CrossPlatform.h"

using namespace OGFrp::Console;

CrossPlatFormCore cpf(Windows);

int main() {
	cpf.createFolder();
	/*
	cpf.printWelcome();
	cpf.enter();
	for (int i = 0; i < 16; i++) {
		printf("%c", cpf.token[i]);
	}
	*/
	return 0;
}