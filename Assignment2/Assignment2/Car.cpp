#include "Car.h"
#include "Graphics.cpp"


class Car 
{
private:
	int x, y;
	bool South;

public:
	Car(int x_p, int y_p, bool SouthIn) {
		x = x_p;
		y = y_p;
		South = SouthIn;
	}
	void Move() {
		if (South) {
			y += 5;
		}
		else {
			x += 5;	
		}
	}
	bool getSouth() {
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