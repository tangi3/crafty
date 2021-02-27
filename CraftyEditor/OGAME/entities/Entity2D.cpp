#pragma once
#include "../../OGAME/base/Entity.cpp"
#include "../../OGAME/components/Body.cpp"
#include "../../OGAME/components/View.cpp"

using namespace Ogame;

namespace Ogame
{
	class Entity2D : public Entity
	{
		friend class Entity;

		public: string path;

		public: vector<IntRect> tiles;
		public: int frame;

		public: IntRect intrect_buffer;
		public: Vector2f vector2f_buffer;

		public: bool changes, coordsChanged, sizeChanged;

		public: Entity2D() : Entity()
		{
			add(reinterpret_cast<Body::Component*>(new Body()));
			add(reinterpret_cast<View::Component*>(new View()));

			changes = false;
			coordsChanged = false;
			sizeChanged = false;

			intrect_buffer = IntRect(0, 0, 0, 0);
			vector2f_buffer = Vector2f(0, 0);

			frame = 0;
		}

		public: Entity2D(string id) : Entity(id)
		{
			add(reinterpret_cast<Body::Component*>(new Body()));
			add(reinterpret_cast<View::Component*>(new View()));

			changes = false;
			coordsChanged = false;
			sizeChanged = false;

			intrect_buffer = IntRect(0, 0, 0, 0);
			vector2f_buffer = Vector2f(0, 0);

			frame = 0;
		}

		public: void loadFromFile(string type, string name)
		{
			path = "C:/Users/tangi/Desktop/crafty/CraftyEditor/OGAME/assets/" + type + "s/" + name + ".png";
			view()->texture.loadFromFile(path);
			view()->sprite.setTexture(view()->texture);
		}

		public: void setFrame(int f) { frame = f; view()->sprite.setTextureRect(tiles[frame]); }

		public: void loadTiles(int tile_size)
		{
			tiles = vector<IntRect>();

			for (int j = 0; j < view()->texture.getSize().y / tile_size; j++)
			{
				for (int i = 0; i < view()->texture.getSize().x / tile_size; i++)
				{
					intrect_buffer.left = i * tile_size;
					intrect_buffer.top = j * tile_size;
					intrect_buffer.width = tile_size;
					intrect_buffer.height = tile_size;

					tiles.push_back(intrect_buffer);
				}
			}
		}

		public: void move(int i, int j)
		{
			body()->coord.i = i;
			body()->coord.j = j;

			changes = true;
			coordsChanged = true;
		}

		public: void resize(int i, int j, int tile_size)
		{
			body()->size.i = i;
			body()->size.j = j;

			changes = true;
			sizeChanged = true;
		}

		public: void update(int tile_size)
		{
			if (changes)
			{
				if (sizeChanged)
				{
					vector2f_buffer.x = body()->size.i * tile_size;
					vector2f_buffer.y = body()->size.j * tile_size;

					sizeChanged = false;
				}

				if (coordsChanged)
				{
					vector2f_buffer.x = body()->coord.i * tile_size;
					vector2f_buffer.y = body()->coord.j * tile_size;

					view()->sprite.setPosition(vector2f_buffer);

					coordsChanged = false;
				}

				changes = false;
			}
		}

		private: Body* body() { return reinterpret_cast<Body*>(get("body")); }

		public: View* view() { return reinterpret_cast<View*>(get("view")); }

		public: Sprite& sprite(){ return view()->sprite; }
	};
}