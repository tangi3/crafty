#pragma once
#include <SFML/Graphics.hpp>
#include <iostream>
#include "entities/Map.cpp"
#include "components/Camera.cpp"
using namespace sf;
using namespace std;

class Renderer
{
	public: RenderWindow data;
	public: bool initiliazed;
	public: Event event;

	public: int width, height;
	public: Vector2f mouse;
	public: Vector2f mouseTile;

	public: View view;

	public: Renderer() { initiliazed = false; }

	public: void load(string caption, int w, int h)
	{
		data.create(VideoMode(w, h), caption, Style::Titlebar | Style::Close);

		auto desktop = sf::VideoMode::getDesktopMode();
		data.setPosition(Vector2i(desktop.width / 2 - data.getSize().x / 2, desktop.height / 2 - data.getSize().y / 2));

		view = View(FloatRect(0, 0, w, h));
		data.setView(view);

		width = w;
		height = h;
	}

	public: void Run(Camera& camera, Map& map)
	{
		while (data.isOpen())
		{
			if (!initiliazed) Initialize();
			initiliazed = true;

			Update(camera, map);
			Draw();

			//cursor
			blitTile(map, 2, mouseTile.x, mouseTile.y);

			data.display();
		}
	}

	public: virtual void Initialize() { }

	public: virtual void Update(Camera& camera, Map& map)
	{
		event = Event();

		while (data.pollEvent(event))
		{
			mouse = data.mapPixelToCoords(sf::Mouse::getPosition(data));
			mouseTile.x = floor(mouse.x / map.tile_size) * map.tile_size;
			mouseTile.y = floor(mouse.y / map.tile_size) * map.tile_size;

			if (event.type == Event::Closed) data.close();

			if (event.type == Event::KeyPressed)
			{
				switch (event.key.code)
				{
					case sf::Keyboard::Left: camera.move(map, -1, 0); break;
					case sf::Keyboard::Right: camera.move(map, 1, 0); break;
					case sf::Keyboard::Up: camera.move(map, 0, -1); break;
					case sf::Keyboard::Down: camera.move(map, 0, 1); break;
				}
			}
			//...
		}

		data.clear(Color::Black);

		updateMap(camera, map);
	}

	public: virtual void Draw() { }

	public: void draw(Entity2D& entity, bool rect = false)
	{
		if (rect) data.draw(entity.rectangle());
		data.draw(entity.sprite());
	}

	public: void draw(Map& map)
	{
		data.draw(map.data);
	}

	private: void updateMap(Camera& camera, Map& map)
	{
		if (map.changes)
		{
			map.data.setPosition(Vector2f(0, 0));
			map.renderTexture.clear(sf::Color::Red);

			map.renderTexture.create((map.chunks.size() * map.chunck_width) * map.tile_size, (map.chunks.size() * map.chunk_height) * map.tile_size);
			map.update();
			
			for (int t = 0; t < map.tiles.size(); t++)
			{ blit(map, map.tiles[t].frame, map.tiles[t].coords.i * reinterpret_cast<Body*>(map.get("body"))->unit_width,
				map.tiles[t].coords.j * reinterpret_cast<Body*>(map.get("body"))->unit_height); }

			if (map.grid)
			{ for (int t = 0; t < map.tiles.size(); t++)
				{ blit(map, 1, map.tiles[t].coords.i * reinterpret_cast<Body*>(map.get("body"))->unit_width,
						map.tiles[t].coords.j * reinterpret_cast<Body*>(map.get("body"))->unit_height); } }

			map.renderTexture.display();

			map.data = Sprite(map.renderTexture.getTexture());

			map.changes = false;
		}
	}

	public: void blit(Entity2D& entity, int frame, float x, float y)
	{
		entity.move(frame, x, y);
		data.draw(entity.sprite());
	}

	public: void blit(Map& map, int frame, float x, float y)
	{
		map.move(frame, x, y);
		map.renderTexture.draw(map.sprite());
	}

	public: void blitTile(Map& map, int frame, float x, float y)
	{
		map.move(frame, x, y);
		data.draw(map.sprite());
	}
};