#pragma once
#include "../../base/Component.cpp"

class Offset : Component
{
	public: float x, y;
	public: int width, height;

	public: Offset() : Component()
	{
		x = 0;
		y = 0;
		width = 0;
		height = 0;
	}
};