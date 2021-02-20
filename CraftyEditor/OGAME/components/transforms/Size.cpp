#pragma once
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\base\Component.cpp"

class Size : public Component
{
	public: int width, height;
	public: float xOffset, yOffset;
	
	public: Size() : Component("size")
	{
		width = 1;
		height = 1;
		xOffset = 0;
		yOffset = 0;
	}
};