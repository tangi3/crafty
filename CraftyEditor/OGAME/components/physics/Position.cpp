#pragma once
#include "../../base/Component.cpp"

class Position : Component
{
	public: float x, y;

	public: Position() : Component()
	{
		x = 0;
		y = 0;
	}
};