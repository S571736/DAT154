// Assignment2.cpp : Defines the entry point for the application.
//

#include "framework.h"
#include "Assignment2.h"
#include "Car.cpp"
//#include "Graphics.cpp"
#include <list>
#include <stdlib.h>
#include <sstream>

using namespace std;

#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name

// Forward declarations of functions included in this code module:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

void Rectangle(HDC*, int, int, int, int, COLORREF);
void Circle(HDC*, int, int, int, int, COLORREF);
void TrafficLights(HDC*);
void Roads(HDC*);
void Cars(HDC*);
int lights = 0;
int lightTimer = 0;
int pw = 0;
int pn = 0;
int prob;
bool invalidate = false;


list<Car> cars;
list<Car>::iterator CI;

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
	_In_opt_ HINSTANCE hPrevInstance,
	_In_ LPWSTR    lpCmdLine,
	_In_ int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

	// TODO: Place code here.

	// Initialize global strings
	LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadStringW(hInstance, IDC_ASSIGNMENT2, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance(hInstance, nCmdShow))
	{
		return FALSE;
	}

	HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_ASSIGNMENT2));

	MSG msg;

	// Main message loop:
	while (GetMessage(&msg, nullptr, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return (int)msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEXW wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style = CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc = WndProc;
	wcex.cbClsExtra = 0;
	wcex.cbWndExtra = 0;
	wcex.hInstance = hInstance;
	wcex.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_ASSIGNMENT2));
	wcex.hCursor = LoadCursor(nullptr, IDC_ARROW);
	wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wcex.lpszMenuName = MAKEINTRESOURCEW(IDC_ASSIGNMENT2);
	wcex.lpszClassName = szWindowClass;
	wcex.hIconSm = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassExW(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
	hInst = hInstance; // Store instance handle in our global variable

	HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);

	if (!hWnd)
	{
		return FALSE;
	}

	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);

	return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE: Processes messages for the main window.
//
//  WM_COMMAND  - process the application menu
//  WM_PAINT    - Paint the main window
//  WM_DESTROY  - post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	SetTimer(hWnd, 0, 3, (TIMERPROC)NULL);
	switch (message)
	{
	case WM_COMMAND:
	{
		int wmId = LOWORD(wParam);
		// Parse the menu selections:
		switch (wmId)
		{
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
	}
	break;
	case WM_PAINT:
	{
		PAINTSTRUCT ps;
		HDC hdc = BeginPaint(hWnd, &ps);

		Roads(&hdc);
		TrafficLights(&hdc);
		Cars(&hdc);

		EndPaint(hWnd, &ps);
		break;
	}
	break;
	case WM_TIMER:
	{

		invalidate = false;
		if (lightTimer == 99)
		{
			lights = (lights + 1) % 6;
			invalidate = true;
			//InvalidateRect(hWnd, 0, false);
		}

		int prob = rand() % 100;

		if (prob > 100 - pw) { // pw

			cars.push_front(Car(-50, rand() % 100 + 300, false));
		}
		if (prob > 100 - pn) //pn
		{
			cars.push_front(Car(rand() % 100 + 300, -50, true));
		}

		for (CI = cars.begin(); CI != cars.end(); ++CI) {
			// Slett biler
			if (CI->getX() >= 1920 || CI->getY() >= 1080) {
				cars.erase(CI);
				break;
			}

			auto CI2 = CI;
			CI2++;

			if (CI->getSouth()) {
				auto next = std::find_if(CI2, cars.end(), [](auto& c) {return c.getSouth(); });
				//Kj�rer ikkje p� bilen foran
				if (next != cars.end() && CI->getSouth()) {
					if (CI->getY() + 35 >= next->getY())
					{
						continue;
					}
				}
				//Kj�rer p� gr�nt lys
				if (lights == 4 || lights == 3)
				{
					CI->Move();
					invalidate = true;
					//InvalidateRect(hWnd, 0, false);
				}
				else {
					//Stopper n�r bilen kommer til streken
					if (CI->getY() <= 260 || CI->getY() >= 310) {
						CI->Move();
						invalidate = true;
						//InvalidateRect(hWnd, 0, false);
					}
				}
			}
			else
			{
				auto next = std::find_if(CI2, cars.end(), [](auto& c) {return !c.getSouth(); });
				//Kj�rer ikkje p� bilen foran
				if (next != cars.end() && !CI->getSouth()) {
					if (CI->getX() + 35 >= next->getX())
					{
						continue;
					}
				}
				//Kj�rer p� gr�nt lys
				if (lights == 1 || lights == 0)
				{
					CI->Move();
					invalidate = true;
					//InvalidateRect(hWnd, 0, false);
				}
				else {
					//Stopper n�r bilen kommer til streken
					if (CI->getX() <= 260 || CI->getX() >= 290) {
						CI->Move();
						invalidate = true;
						//InvalidateRect(hWnd, 0, false);
					}
				}
			}
			// F� biler til � kj�re
			// F� Biler til � stoppe p� r�dt lys
		}

		lightTimer = (lightTimer + 1) % 200;
		if (invalidate)
		{
			InvalidateRect(hWnd, 0, false);
		}
	}
	break;
	case WM_KEYDOWN:
	{
		switch (wParam)
		{
		case VK_UP:
		{
			pw = pw + 1;
		}
		break;
		case VK_RIGHT:
		{
			pn = pn + 1;
		}
		break;
		case VK_DOWN:
			pw = pw - 1;
			break;
		case VK_LEFT:
			pn = pn - 1;
			break;
		}
		break;
	}
	case WM_DESTROY:
		KillTimer(hWnd, 0);
		KillTimer(hWnd, 1);
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}

void Rectangle(HDC* hdc, int l, int t, int r, int b, COLORREF color) {
	HBRUSH hBrush = CreateSolidBrush(color);
	HGDIOBJ hOrg = SelectObject(*hdc, hBrush);
	RECT rect;
	rect.left = l;
	rect.top = t;
	rect.right = r;
	rect.bottom = b;
	FillRect(*hdc, &rect, hBrush);
	SelectObject(*hdc, hOrg);
	DeleteObject(hBrush);
}

void Circle(HDC* hdc, int l, int t, int r, int b, COLORREF color) {
	HBRUSH hBrush = CreateSolidBrush(color);
	HGDIOBJ hOrg = SelectObject(*hdc, hBrush);

	Ellipse(*hdc, l, t, r, b);

	SelectObject(*hdc, hOrg);
	DeleteObject(hBrush);
}

void TrafficLights(HDC* hdc) {
	//Graphics gfx;
	static int relation = 40;
	static int l = 200, t = 120, r = 240, b = 160;
	static int l1 = 200, t1 = 510, r1 = 240, b1 = 550;

	switch (lights)
	{
	case 0:
	{
		// Red light
		Rectangle(hdc, l - 10, t - 10, r + 10, b + relation * 2 + 10, RGB(0, 0, 0)); // Fjern eller finn l�sning p� gfx
		Circle(hdc, l, t, r, b, RGB(255, 0, 0));
		Circle(hdc, l, t + relation, r, b + relation, RGB(128, 128, 128));
		Circle(hdc, l, t + relation * 2, r, b + relation * 2, RGB(128, 128, 128));

		// Green light
		Rectangle(hdc, l1 - 10, t1 - 10, r1 + 10, b1 + relation * 2 + 10, RGB(0, 0, 0));
		Circle(hdc, l1, t1, r1, b1, RGB(128, 128, 128));
		Circle(hdc, l1, t1 + relation, r1, b1 + relation, RGB(128, 128, 128));
		Circle(hdc, l1, t1 + relation * 2, r1, b1 + relation * 2, RGB(0, 255, 0));
	}
	break;
	case 1:
	{
		// Red
		Rectangle(hdc, l - 10, t - 10, r + 10, b + relation * 2 + 10, RGB(0, 0, 0));
		Circle(hdc, l, t, r, b, RGB(255, 0, 0));
		Circle(hdc, l, t + relation, r, b + relation, RGB(128, 128, 128));
		Circle(hdc, l, t + relation * 2, r, b + relation * 2, RGB(128, 128, 128));

		// Yellow
		Rectangle(hdc, l1 - 10, t1 - 10, r1 + 10, b1 + relation * 2 + 10, RGB(0, 0, 0));
		Circle(hdc, l1, t1, r1, b1, RGB(128, 128, 128));
		Circle(hdc, l1, t1 + relation, r1, b1 + relation, RGB(255, 255, 0));
		Circle(hdc, l1, t1 + relation * 2, r1, b1 + relation * 2, RGB(128, 128, 128));
	}
	break;
	case 2:
	{
		// Red + Yellow

		Rectangle(hdc, l - 10, t - 10, r + 10, b + relation * 2 + 10, RGB(0, 0, 0));
		Circle(hdc, l, t, r, b, RGB(255, 0, 0));
		Circle(hdc, l, t + relation, r, b + relation, RGB(255, 255, 0));
		Circle(hdc, l, t + relation * 2, r, b + relation * 2, RGB(128, 128, 128));


		// Red light
		Rectangle(hdc, l1 - 10, t1 - 10, r1 + 10, b1 + relation * 2 + 10, RGB(0, 0, 0));
		Circle(hdc, l1, t1, r1, b1, RGB(255, 0, 0));
		Circle(hdc, l1, t1 + relation, r1, b1 + relation, RGB(128, 128, 128));
		Circle(hdc, l1, t1 + relation * 2, r1, b1 + relation * 2, RGB(128, 128, 128));
	}
	break;
	case 3:
	{
		// Green
		Rectangle(hdc, l - 10, t - 10, r + 10, b + relation * 2 + 10, RGB(0, 0, 0));
		Circle(hdc, l, t, r, b, RGB(128, 128, 128));
		Circle(hdc, l, t + relation, r, b + relation, RGB(128, 128, 128));
		Circle(hdc, l, t + relation * 2, r, b + relation * 2, RGB(0, 255, 0));

		// Red light
		Rectangle(hdc, l1 - 10, t1 - 10, r1 + 10, b1 + relation * 2 + 10, RGB(0, 0, 0));
		Circle(hdc, l1, t1, r1, b1, RGB(255, 0, 0));
		Circle(hdc, l1, t1 + relation, r1, b1 + relation, RGB(128, 128, 128));
		Circle(hdc, l1, t1 + relation * 2, r1, b1 + relation * 2, RGB(128, 128, 128));

	}
	break;
	case 4:
	{
		// Yellow
		Rectangle(hdc, l - 10, t - 10, r + 10, b + relation * 2 + 10, RGB(0, 0, 0));
		Circle(hdc, l, t, r, b, RGB(128, 128, 128));
		Circle(hdc, l, t + relation, r, b + relation, RGB(255, 255, 0));
		Circle(hdc, l, t + relation * 2, r, b + relation * 2, RGB(128, 128, 128));

		// Red
		Rectangle(hdc, l1 - 10, t1 - 10, r1 + 10, b1 + relation * 2 + 10, RGB(0, 0, 0));
		Circle(hdc, l1, t1, r1, b1, RGB(255, 0, 0));
		Circle(hdc, l1, t1 + relation, r1, b1 + relation, RGB(128, 128, 128));
		Circle(hdc, l1, t1 + relation * 2, r1, b1 + relation * 2, RGB(128, 128, 128));
	}
	break;
	case 5:
	{
		// Red
		Rectangle(hdc, l - 10, t - 10, r + 10, b + relation * 2 + 10, RGB(0, 0, 0));
		Circle(hdc, l, t, r, b, RGB(255, 0, 0));
		Circle(hdc, l, t + relation, r, b + relation, RGB(128, 128, 128));
		Circle(hdc, l, t + relation * 2, r, b + relation * 2, RGB(128, 128, 128));

		// Red + Yellow
		Rectangle(hdc, l1 - 10, t1 - 10, r1 + 10, b1 + relation * 2 + 10, RGB(0, 0, 0));
		Circle(hdc, l1, t1, r1, b1, RGB(255, 0, 0));
		Circle(hdc, l1, t1 + relation, r1, b1 + relation, RGB(255, 255, 0));
		Circle(hdc, l1, t1 + relation * 2, r1, b1 + relation * 2, RGB(128, 128, 128));
	}
	default:
		break;
	}
}
void Roads(HDC* hdc) {
	Rectangle(hdc, 0, 300, 1920, 450, RGB(150, 150, 150)); // Left -> Right road
	Rectangle(hdc, 300, 0, 450, 1080, RGB(150, 150, 150)); // Top -> Bottom road

	Rectangle(hdc, 298, 300, 300, 450, RGB(255, 255, 255)); // White crossing line top -> bottom
	Rectangle(hdc, 300, 298, 450, 300, RGB(255, 255, 255)); // White crossing line right -> left
	Rectangle(hdc, 450, 300, 452, 450, RGB(255, 255, 255)); // White crossing line top -> bottom
	Rectangle(hdc, 300, 450, 450, 452, RGB(255, 255, 255)); // White crossing line right -> left
}

void Cars(HDC* hdc) {
	for (CI = cars.begin(); CI != cars.end(); ++CI) {
		Rectangle(hdc, CI->getX() - 2, CI->getY() - 2, CI->getX() + 32, CI->getY() + 32, RGB(0, 0, 0));
		Rectangle(hdc, CI->getX(), CI->getY(), CI->getX() + 30, CI->getY() + 30, RGB(0, 255, 0));

	}
}