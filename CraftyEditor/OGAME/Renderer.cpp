#pragma once
#include <SFML/Graphics.hpp>
#include <iostream>
#include "entities/Entity2D.cpp"
#include "entities/Map.cpp"
using namespace sf;
using namespace std;

class Renderer
{
	public: RenderWindow data;
	public: bool initiliazed;
	public: Event event;

	public: View view;

	public: Renderer() { initiliazed = false; }

	public: void load(string caption, int w, int h)
	{
		data.create(VideoMode(w, h), caption, Style::Titlebar | Style::Close);

		auto desktop = sf::VideoMode::getDesktopMode();
		data.setPosition(Vector2i(desktop.width / 2 - data.getSize().x / 2, desktop.height / 2 - data.getSize().y / 2));

		view = View(FloatRect(0, 0, w, h));
		data.setView(view);
	}

	public: void run()
	{
		while (data.isOpen())
		{
			if (!initiliazed) Initialize();
			initiliazed = true;

			Update();
			Draw();

			data.display();
		}
	}

	public: virtual void Initialize() { }

	public: virtual void Update()
	{
		event = Event();

		while (data.pollEvent(event))
		{
			if (event.type == Event::Closed) data.close();

			//...
		}

		data.clear(Color::Black);
	}

	public: virtual void Draw() { }

	public: void draw(Entity2D& entity, bool rect = false)
	{
		if (rect) data.draw(entity.rectangle());
		data.draw(entity.sprite());
	}

	public: void draw(Map& map)
	{
		for (int t = 0; t < map.getChunk(0).tiles.size(); t++)
		{
			blit(map, map.getChunk(0).tiles[t].frame, map.getChunk(0).tiles[t].coords.i * reinterpret_cast<Body*>(map.get("body"))->unit_width, map.getChunk(0).tiles[t].coords.j * reinterpret_cast<Body*>(map.get("body"))->unit_height);
		}
	}

	public: void update(Map& map)
	{
		//...
	}

	public: void blit(Entity2D& entity, int frame, float x, float y)
	{
		entity.move(frame, x, y);
		data.draw(entity.sprite());
	}
};