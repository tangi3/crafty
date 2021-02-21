#pragma once
#include <SFML/Graphics.hpp>
using namespace sf;

#pragma once
#include "../../base/BaseComponent.cpp"

class Visual : BaseComponent
{
	public: Texture texture;
	public: IntRect area;
	public: RectangleShape rectangle;
	public: Color color;

	public: Visual() : BaseComponent() { }
};