// ConsoleLabApplication4.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

void minEl(int a[], int size);

int main()
{
//4.1

	int yes[] = { 1, 3, 7, 13, 21, 5, 8, 16, 11};
    minEl(yes, 9);
	//system()
	return 0;

}

void minEl(int a[], int size) {
	int min = a[0];
	for (int i = 1;i < size;++i) {
		if (a[i] < min) min = a[i];
	}
}