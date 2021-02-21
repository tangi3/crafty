#pragma once
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\base\headers.cpp"
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\base\System.cpp"
#include "../entities/Unit.cpp"
#include "../entities/UI/GUI.cpp"
#include "../entities/UI/Clickable.cpp"

class GraphicHandler : public System
{
	private: GUI window;
	private: bool initiliazed;

	public: float mouseX, mouseY;

	public: bool leftClick;
	//...

	public: GraphicHandler(string title, int width, int height) : System()
	{
		window.set(title, width, height);
		initiliazed = false;
		Initialize();
	}

	public: void load(Unit& unit)
	{
		unit.texture.loadFromFile(unit.path);
		unit.size.width = unit.texture.getSize().x;
		unit.size.height = unit.texture.getSize().y;

		unit.sprite.setTexture(unit.texture);
		unit.sprite.setPosition(unit.position.x, unit.position.y);
		unit.loadTiles();
	}

	public: void update(Clickable& button)
	{
		button.updateState(mouseX, mouseY, leftClick);
	}

	public: void update(Clickable& button, int parent_width, int parent_height, float parent_x, float parent_y, float xOffset, float yOffset, int widthOffset, int heightOffset)
	{
		button.updateState(mouseX, mouseY, leftClick);
		button.update(parent_width, parent_height, parent_x, parent_y, xOffset, yOffset, widthOffset, heightOffset);
	}

	public: void draw(Unit& unit) { window.data.draw(unit.sprite); }

	public: void draw(Unit& unit, int index)
	{
		unit.setTile(index);
		window.data.draw(unit.sprite);
	}

	public: void draw(Unit& unit, int index, float x, float y)
	{
		unit.setTile(index);
		unit.move(x, y);
		window.data.draw(unit.sprite);
	}

	public: void draw(UIContainer& ui)
	{
		window.data.draw(ui.rectangle);

		//...
	}

	public: void draw(Clickable& clickable) { window.data.draw(clickable.rectangle); }

	public: void Run()
	{
		while (window.data.isOpen())
		{
			if (initiliazed == false) Initialize();
			initiliazed = true;
			Update();
			Draw();
			window.data.display();
		}
	}

	public: virtual void Initialize() { }

	public: virtual void Update()
	{
		Event event;
		while (window.data.pollEvent(event))
		{
			if (event.type == Event::Closed)
				window.data.close();
		}

		mouseX = Mouse::getPosition(window.data).x;
		mouseY = Mouse::getPosition(window.data).y;

		leftClick = Mouse::isButtonPressed(sf::Mouse::Left);
		//...

		window.data.clear(sf::Color::Black);

		window.mainContainer.update(window.size.width, window.size.height, window.position.x, window.position.y, window.position.xOffset, window.position.yOffset, window.size.widthOffset, window.size.heightOffset);
	}

	public: virtual void Draw() { draw(window.mainContainer); }

	public: void fill(Color c) { window.fill(c); }
};