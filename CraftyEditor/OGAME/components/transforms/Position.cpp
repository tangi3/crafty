#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\base\Component.cpp"

class Position : public Component
{
	public: float x, y, z;
	public: float xOffset, yOffset;

	public: Position() : Component("position")
	{
		x = 0;
		y = 0;
		z = 0;

		xOffset = 0;
		yOffset = 0;
	}
};