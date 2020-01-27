// CarApp.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

using namespace std;
#pragma warning(disable : 4996)
class Car
{
public:
	int n;
	Car(int _n) : n(_n )
	{}
	void Draw()
	{
		cout << n << ": ()==()" << endl;
	}
};

class CarList
{
public:
	Car* t[1000];
	int m_i;
	CarList()
	{
		m_i = 0;
	}

	~CarList()
	{
	}

	void push(Car* pCar)
	{
		t[m_i++] = pCar;
	}

	void Draw()
	{
		for (int k = 0; k< m_i; k++)
			t[k]->Draw();   		// Same as (*t[m_i]).Draw();
	}
};

int main()
{
	CarList list;

	Car a(1), b(2), c(3);
	list.push(&a);
	list.push(&b);
	list.push(&c);

	list.Draw();

	system("pause");

}




//class X
//{
//	char s[100];
//public:
//	X(const char* p)
//	{
//		strcpy(s, p);
//	}
//	void Print()
//	{
//		cout << s << endl;
//	}
//};
//
//X* pa = new X("Hello");
//X* pb = new X("World");
//pa->Print(); // When using a pointer - use -> instead of .
//pb->Print(); // Same as (*pb). = pb->
//delete pa;
//delete pb;

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
