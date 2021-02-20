#pragma once
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\base\headers.cpp"
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\base\Entity.cpp"
#include "../components/transforms/Position.cpp"
#include "../components/transforms/Size.cpp"

class Entity2D : public Entity
{
	public: Position position;
	public: Size size;
	public: int pixels;

	public: Entity2D() : Entity() { initialize(); }
	public: Entity2D(string id) : Entity(id) { initialize(); }
	public: Entity2D(string id, float x, float y, int width, int height) : Entity(id)
	{
		initialize();
		move(x, y);
		resize(width, height);
	}

	private: void initialize()
	{
		position = Position();
		size = Size();
	}

	public: void move(float x, float y)
	{
		position.x = x;
		position.y = y;
	}

	public: void resize(int width, int height)
	{
		size.width = width;
		size.height = height;
		pixels = width * height;
	}
};