#pragma once
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\base\headers.cpp"
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\base\System.cpp"
#include "../entities/GUI.cpp"
#include "../entities/Unit.cpp"

class GraphicHandler : public System
{
	private: GUI window;
	private: bool initiliazed;

	public: GraphicHandler(string title, int width, int height) : System()
	{
		window = GUI("CraftyEditor", width, height);
		initiliazed = false;
		Initialize();
	}

	public: void load(Unit unit)
	{
		unit.texture.loadFromFile(unit.path);
		unit.sprite.setTexture(unit.texture);
		unit.sprite.setPosition(unit.position.x, unit.position.y);
		unit.sprite.scale(1, unit.scale);
	}

	public: void draw(Unit unit, int frame) { window.data->draw(unit.sprite); }

	public: void Run()
	{
		while (window.data->isOpen())
		{
			if (initiliazed == false) Initialize();
			initiliazed = true;
			Update();
			Draw();
			window.data->display();
		}
	}

	public: virtual void Initialize() { }

	public: virtual void Update()
	{
		Event event;
		while (window.data->pollEvent(event))
		{
			if (event.type == Event::Closed)
				window.data->close();
		}

		window.data->clear(sf::Color::Black);
	}

	public: virtual void Draw() {}
};