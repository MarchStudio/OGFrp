#pragma once

#include "CrossPlatformCore.h"
#include "Locals.h"

using namespace OGFrp::Console;

CrossPlatFormCore cpf(P_Windows, F_amd64);

int main() {
	return cpf.enter();
}