#pragma once
#include "../../OGAME/base/System.cpp"
#include "../entities/UI.cpp"

class GraphicHandler : System
{
	public: UI gui;

	public: GraphicHandler() : System() {}

	public: void init(string title, int width, int height) { gui.init(title, width, height); }

	public: void run()
	{
		while (gui.window.isOpen())
		{
			if (gui.initiliazed == false) Load();
			gui.initiliazed = true;

			Update();
			Draw();

			gui.window.display();
		}
	}

	public: virtual void Load() { }

	public: virtual void Update()
	{
		Event event;
		while (gui.window.pollEvent(event))
		{
			if (event.type == Event::Closed)
				gui.window.close();
		}
	}

	public: virtual void Draw() { }
};