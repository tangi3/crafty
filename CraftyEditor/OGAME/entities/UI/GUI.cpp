#pragma once
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\base\headers.cpp"
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\entities\Entity2D.cpp"
#include "UIContainer.cpp"

class GUI : public Entity2D
{
	public:  RenderWindow data;

	public: UIContainer mainContainer;

	public: GUI() : Entity2D("Window") {}

	public: void set(string title, int w, int h)
	{
		data.create(VideoMode(w, h), title, Style::Titlebar | Style::Close);

		mainContainer = UIContainer(size.width, size.height, position.x, position.y, position.xOffset, position.yOffset, size.widthOffset, size.heightOffset);
		mainContainer.fill(sf::Color::Blue);

		key = title;
		size.width = w;
		size.height = h;

		auto desktop = sf::VideoMode::getDesktopMode();
		data.setPosition(Vector2i(desktop.width / 2 - data.getSize().x / 2, desktop.height / 2 - data.getSize().y / 2));
	}

	public: void fill(Color c) { mainContainer.fill(c); }
};