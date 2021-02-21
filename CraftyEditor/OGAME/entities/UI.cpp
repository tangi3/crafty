#pragma once
#include "../base/Entity.cpp"
#include "../components/physics/Body.cpp"

class UI : Entity
{
	public: string title;
	public: RenderWindow window;
	public: Body body;

	public: bool initiliazed;

	public: UI() : Entity()
	{
		initiliazed = false;
		body = Body();

		window.create(VideoMode(600, 600), "", Style::Titlebar | Style::Close);
	}

	public: void init(string caption, int width, int height)
	{
		title = caption;
		body.size.width = width;
		body.size.height = height;

		window.setTitle(title);
		window.setSize(Vector2u(body.size.width, body.size.height));

		auto desktop = sf::VideoMode::getDesktopMode();
		window.setPosition(Vector2i(desktop.width / 2 - window.getSize().x / 2, desktop.height / 2 - window.getSize().y / 2));
	}
};