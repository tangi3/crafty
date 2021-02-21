#pragma once
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\base\Component.cpp"

class Size : public Component
{
	public: int width, height;
	public: int widthOffset, heightOffset;
	
	public: Size() : Component("size")
	{
		width = 1;
		height = 1;

		widthOffset = 0;
		heightOffset = 0;
	}
};