#include "Graphics.h"
#include <stdlib.h>
#include <wtypes.h>

class Graphics
{
public:
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
};