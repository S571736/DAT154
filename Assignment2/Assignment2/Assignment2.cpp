// Assignment2.cpp : Defines the entry point for the application.
//

#include "framework.h"
#include "Assignment2.h"
#include "Car.cpp"
#include <list>
#include <stdlib.h>

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
int lights = 0;
int changeLights = 0;

list<Car*> cars;
list<Car*>::iterator CI;

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
    if (!InitInstance (hInstance, nCmdShow))
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

    return (int) msg.wParam;
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

    wcex.style          = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc    = WndProc;
    wcex.cbClsExtra     = 0;
    wcex.cbWndExtra     = 0;
    wcex.hInstance      = hInstance;
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_ASSIGNMENT2));
    wcex.hCursor        = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground  = (HBRUSH)(COLOR_WINDOW+1);
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_ASSIGNMENT2);
    wcex.lpszClassName  = szWindowClass;
    wcex.hIconSm        = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

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
            TrafficLights(&hdc);


            EndPaint(hWnd, &ps);
            break;
        }
        break;
    case WM_DESTROY:
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
    Ellipse()
    
    SelectObject(*hdc, hOrg);
    DeleteObject(hBrush);
}

void TrafficLights(HDC* hdc) {
    static int x = 100, y = 150;
    switch (lights) 
    {    
    case 0:
    {
        // Red light
        
        Rectangle(hdc, x-10, x-10, y+10, y+160, RGB(140, 140, 140));
        Circle(hdc, x, x, y, y, RGB(255, 0, 0));
        Circle(hdc, x, x + 75, y, y+75, RGB(0, 0, 0));
        Circle(hdc, x, x + 150, y, y + 150, RGB(0,0,0));
    }
    break;
    case 1:
    {
        // Red + Yellow light
        Rectangle(hdc, x - 10, x - 10, y + 10, y + 160, RGB(140, 140, 140));
        Circle(hdc, x, x, y, y, RGB(255, 0, 0));
        Circle(hdc, x, x + 75, y, y + 75, RGB(255, 255, 0));
        Circle(hdc, x, x + 150, y, y + 150, RGB(0, 0, 0));
    }
    break;
    case 2: 
    {
        // Green light

        Rectangle(hdc, x - 10, x - 10, y + 10, y + 160, RGB(140, 140, 140));
        Circle(hdc, x, x, y, y, RGB(0, 0, 0));
        Circle(hdc, x, x + 75, y, y + 75, RGB(0, 0, 0));
        Circle(hdc, x, x + 150, y, y + 150, RGB(0, 255, 0));
    }
    break;
    case 3:
    {
        // Yellow light
        Rectangle(hdc, x - 10, x - 10, y + 10, y + 160, RGB(140, 140, 140));
        Circle(hdc, x, x, y, y, RGB(0, 0, 0));
        Circle(hdc, x, x + 75, y, y + 75, RGB(255, 255, 0));
        Circle(hdc, x, x + 150, y, y + 150, RGB(0, 0, 0));

    }
    break;
    default:
        break;
    }
}