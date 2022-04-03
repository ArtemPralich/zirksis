#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <openssl/md2.h>

using namespace std;

int main() {
	int i;
	MD2_CTX md2handler;
	unsigned char md2digest[MD2_DIGEST_LENGTH];

	MD2_Init(&md2handler);

	MD2_Update(&md2handler, "01234", 5);
	MD2_Update(&md2handler, "56789", 5);
	MD2_Final(md2digest, &md2handler);

	for (i = 0; i < MD2_DIGEST_LENGTH; i++) {
		printf("%02x", md2digest[i]);
	};

	printf("\n");
	return 0;
};