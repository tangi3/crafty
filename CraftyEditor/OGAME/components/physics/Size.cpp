#pragma once
#include "../../base/Component.cpp"

class Size : Component
{
public: int width, height;

	public: Size() : Component()
	{
		width = 0;
		height = 0;
	}
};