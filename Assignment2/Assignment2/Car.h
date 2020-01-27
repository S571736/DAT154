#pragma once
class Car
{
private:
	int x, y;
	bool drivingSouth;

public: 
	Car(int xIn, int yIn, bool drivingSouthIn) {
		x = xIn;
		y = yIn;
		drivingSouth = drivingSouthIn;
	}

	void Move(){

	}

	bool getDrivingSouth(){
		return drivingSouth;
	}

	int getX() {
		return x;
	}
	int getY() {
		return y;
	}
};

