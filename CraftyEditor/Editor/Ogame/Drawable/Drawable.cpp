#include "../ECS/Headers.cpp"
#pragma once
#include "../transforms/Transforms.cpp"

class Drawable : Component
{
	public: Transforms transforms;

	public: Drawable(string id = "") : Component()
	{
		key = id;
		transforms = Transforms();
	}

	public: void tp(int x, int y)
	{
		transforms.position.x = x;
		transforms.position.y = y;

		update();
	}

	public: void offset(int x, int y)
	{
		transforms.position.offsetX = x;
		transforms.position.offsetY = y;

		update();
	}

	public: void resize(int width, int height)
	{
		transforms.size.width = width;
		transforms.size.height = height;

		update();
	}

	public: void update() { transforms.size.update(); }

	public: void update(int width, int height, float x, float y, float z)
	{
		transforms.size.parent_width = width;
		transforms.size.parent_height = height;

		transforms.position.parent_x = x;
		transforms.position.parent_y = y;
		transforms.position.parent_z = z;

		transforms.size.update();
	}

	public: void debug()
	{
		cout << "(" << transforms.position.x + transforms.position.offsetX << ", " << transforms.position.y + transforms.position.offsetY << ")";
		cout << " [" << transforms.size.width << ", " << transforms.size.height << "] (";
		cout << transforms.size.nbPixels << "pixels)" << endl;
	}
};