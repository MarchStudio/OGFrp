#include <stdio.h>
#include <iostream>
#include <string>

#ifdef Windows
#include <windows.h>
#endif

using namespace std;

namespace OGFrp {
	namespace Console {
		
		class Net {
		public:
			int Download(string address, string fileName) {
#ifdef Windows

#elif defined Linux
				//Code on Linux
#else
				printf("Invaild Platform.");
				return -1;
#endif
			}
		};

	}
}
