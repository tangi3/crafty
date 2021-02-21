#pragma once
#include "Controller/GraphicController.cpp"

class Ogame
{
	public: GraphicController graphics;

	public: Ogame() {}

	public: void run(string caption, int width, int height)
	{
		graphics.initialize(caption, width, height);
		Load();

		while (graphics.isOpen())
		{
			while (graphics.hasEvents())
			{
				if (graphics.hasClosed()) graphics.close();

				//...
			}

			graphics.clear("#adaaa1");

			Update();
			Draw();
			
			graphics.swap();
		}
	}

	public: virtual void Load() { graphics.initialized(); }

	public: virtual void Update() { }

	public: virtual void Draw() { }
};