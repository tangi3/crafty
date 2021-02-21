#pragma once
#include "../../base/BaseComponent.cpp"

class Body : public BaseComponent
{
	public: float x, y, xOffset, yOffset;
	public: int width, height, scale;

	public: Body() : BaseComponent()
	{
		x = 0;
		y = 0;

		width = 0;
		height = 0;

		scale = 1;

		xOffset = 0;
		yOffset = 0;
	}
};