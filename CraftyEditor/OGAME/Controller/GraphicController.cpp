#pragma once
#include <SFML/Graphics.hpp>
using namespace sf;
using namespace std;

#pragma once
#include "../../OGAME/base/BaseController.cpp"
#include "../View/GraphicView.cpp"

class GraphicController : BaseController
{
	private: GraphicView view;

	public: GraphicController()
	{
		//...
	}

	public: void initialize(string caption, int width, int height)
	{
		if (!view.initialized)
		{
			view.body.width = width;
			view.body.height = height;

			view.window.setTitle(caption);
			view.window.setSize(Vector2u(view.body.width, view.body.height));
		}
	}

	public: void initialized() { view.initialized = true; }

	public: void clear(string hexa)
	{
		view.a = 1;

		hexa.substr(1);
		hexa.replace(0, 1, "");
		sscanf_s(hexa.c_str(), "%02x%02x%02x", &view.r, &view.g, &view.b);

		view.window.clear(Color(view.r, view.g, view.b, view.a));
	}

	public: void swap(){ view.window.display(); }

	public: void close() { view.window.close();  }

	public: bool hasEvents() { return view.window.pollEvent(view.events); }

	public: bool isOpen() { return view.window.isOpen(); }

	public: bool hasClosed() { return view.events.type == Event::Closed; }
};