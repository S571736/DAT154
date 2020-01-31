#include "Car.h"
#include "Graphics.cpp"


class Car 
{
private:
	int x, y;
	bool South;

public:
	Car(int x_p, int y_p, bool South) {
		x = x_p;
		y = y_p;
		South = South;
	}
	void Move() {
		if (South) {
			y++;
		}else {
			x++;	
		}
	}
	bool GetDirection() {
		return South;
	}
	int getX() {
		return x;
	}
	int getY() {
		return y;
	}
	//TODO: make draw method when graphics library is working
};