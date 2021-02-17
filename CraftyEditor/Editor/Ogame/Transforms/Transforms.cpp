#pragma once
#include "../ECS/Component.cpp"
#include "../Transforms/Position.cpp"
#include "Size.cpp"

class Transforms : Component
{
	public: Position position;
	public: Size size;
	//...

	public: Transforms() : Component()
	{
		key = "transforms";

		position = Position();
		size = Size();
		//...
	}
};