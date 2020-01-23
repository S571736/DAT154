// Assignment1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
int MyFunction(char* p);

int main()
{
    char buffer[25];
    std::cout << "Enter a word: ";
    std::cin >> buffer;

    std::cout << buffer << "\n";

    char* p = buffer;
    std::cout << "First letter: " << *p << "\nSize of buffer: " << MyFunction(p);
}

int MyFunction(char* p) 
{
    int i = 0;
    for(;*p;p++)
    {
        i++;
    }
    return i;
}
// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
