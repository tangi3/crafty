#pragma once
#include "../../OGAME/base/Component.cpp"
#include <SFML/System/Vector2.hpp>
#include <SFML/Graphics.hpp>

using namespace sf;

namespace Ogame
{
	class Mouse : public Component
	{
		friend class Component;

		public: Vector2f world;
		public: Vector2f previous_tile;
		public: Vector2f tile;


		public: bool changedTile;
		public: bool click, leftClick, rightClick;

		public: Mouse() : Component("mouse")
		{
			changedTile = false;

			click = false;
			leftClick = false;
			rightClick = false;
		}

		public: void update(RenderWindow& data, int tile_size)
		{
			world = data.mapPixelToCoords(sf::Mouse::getPosition(data));

			tile.x = floor(world.x / tile_size);
			tile.y = floor(world.y / tile_size);

			if (tile.x != previous_tile.x || tile.y != previous_tile.y) changedTile = true;
			else changedTile = false;

			previous_tile = tile;
		}
	};
}