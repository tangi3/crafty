#include "../ECS/Component.cpp"

class Size : Component
{
	public: float width, height, nbPixels, parent_width, parent_height;
	public: Size() : Component()
	{
		key = "size";

		width = 0;
		height = 0;

		nbPixels = 0;

		parent_width = 0;
		parent_height = 0;
	}

	public: void update() { Component::update();  nbPixels = width * height; }
};