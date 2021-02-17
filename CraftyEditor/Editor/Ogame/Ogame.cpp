#pragma once
#include "transforms/Transforms.cpp"
#include "Drawable/Window.cpp"
#include "Systems/Render.cpp"

class Ogame : public Window
{
	public: Render render;
	public: bool initialized;

	public: Ogame(string title, int width, int height) : Window(title, width, height)
	{
		render = Render(transforms.size.width, transforms.size.height);

		//...

		initialized = false;
	}

	public: void running_time()
	{
		Window::running_time();

		if (!initialized)
		{
			Load();
			initialized = true;
		}

		Update();
		Draw();

		render.run();
	}

	public: virtual void Load() { }

	public: virtual void Update() {}

	public: virtual void Draw() { }
};