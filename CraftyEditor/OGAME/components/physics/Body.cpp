#pragma once
#include "../../base/Component.cpp"

#pragma once
#include "Position.cpp"
#include "Size.cpp"
#include "Offset.cpp"

class Body : Component
{
	public: Position position;
	public: Size size;
	public: Offset offsets;

	public: int scale;

	public: Body() : Component()
	{
		position = Position();
		size = Size();
		offsets = Offset();
		scale = 1;
	}
};