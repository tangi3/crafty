#pragma once
#include "SFML/Graphics.hpp"
using namespace sf;

#pragma once
#include "../../OGAME/base/Component.cpp"

class Visual : public Component
{
	public: RectangleShape rectangle;
	public: Sprite sprite;
	public: Texture texture;
	public: Color color;
	public: int r, g, b, a;
	public: vector<IntRect> frames;

	public: Visual() : Component("view") { frames = vector<IntRect>(); }
};