#include "../ECS/Headers.cpp"
#pragma once
#include "../Drawable/Drawable.cpp"
#include "Color.cpp"

class Rectangle : public Drawable
{
	public: Color color;

	public: Rectangle() : Drawable() { color = Color(); }

	public: Rectangle(int width, int height, int x, int y, string color) : Drawable()
	{
		resize(width, height);
		tp(x, y);
		fill(color);
		update();
	}

	public: void fill(string hexa) { color.set(hexa); }
};