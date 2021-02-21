#pragma once
#include <SFML/Graphics.hpp>
using namespace sf;

#pragma once
#include "../../OGAME/base/BaseView.cpp"
#include "Components/Body.cpp"

class GraphicView : BaseView
{
	public: Body body;

	public: bool initialized = false;

	public: RenderWindow window;
	public: Event events;

	public: int r, g, b, a;

	public: GraphicView() : BaseView()
	{
		body = Body();
		window.create(VideoMode(600, 600), "default", Style::Titlebar | Style::Close);
	}
};