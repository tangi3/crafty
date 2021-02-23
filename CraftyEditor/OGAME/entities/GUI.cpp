#pragma once
#include "Entity2D.cpp"

class GUI : public Entity2D
{
	public:  RenderWindow data;
	public: Event event;
	public: bool initiliazed;

	public: GUI() : Entity2D("GUI", 0, 0) { initiliazed = false; }

	public: void load(string title, int w, int h)
	{
		move(0, 0);
		resize(w, h);
		fill("#d1d1d1");

		data.create(VideoMode(w, h), title, Style::Titlebar | Style::Close);

		auto desktop = sf::VideoMode::getDesktopMode();
		data.setPosition(Vector2i(desktop.width / 2 - data.getSize().x / 2, desktop.height / 2 - data.getSize().y / 2));
	}

	public: void run()
	{
		while (data.isOpen())
		{
			if (initiliazed == false) Initialize();
			initiliazed = true;

			Update();
			Draw();

			data.display();
		}
	}

	public: virtual void Initialize(){}

	public: virtual void Update()
	{
		event = Event();

		while (data.pollEvent(event))
		{
			if (event.type == Event::Closed) data.close();

			//...
		}

		data.clear(color());
	}

	public: virtual void Draw() {}

	public: void draw(Shape& shape) { data.draw(shape); }

	public: void draw(Sprite& sprite) { data.draw(sprite); }
};