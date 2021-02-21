#pragma once
#include "../../base/Component.cpp"

class View : Component
{
	public: Texture texture;
	public: IntRect area;
	public: RectangleShape rectangle;
	public: Color color;

	public: View() : Component() { }
};