#pragma once
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\base\headers.cpp"
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\entities\Entity2D.cpp"

class Unit : public Entity2D
{
	public: string type;

	public: Image image;
	public: Texture texture;
	public: Sprite sprite;
	public: Color color;

	public: string path;

	public: float scale = 1.5;

	public: Size tile;
	public: vector<IntRect> tiles;
	public: int current = -1;

	public: Unit() : Entity2D() { initialize(); }

	public: Unit(string id) : Entity2D(id) { initialize(); }

	public: Unit(string id, string t) : Entity2D(id) { initialize(t); }

	private: void initialize(string t = "tilesets", int tile_width = 64, int tile_height = 64)
	{
		type = t;
		path = "C:\\Users\\tangi\\Desktop\\crafty\\CraftyEditor\\OGAME\\assets\\" + type + "\\" + key + ".png";

		tile = Size();
		tile.width = tile_width;
		tile.height = tile_height;
	}

	public: void loadTiles()
	{
		int i = 0;
		int tilePerHeight = size.height / tile.height;
		int tilePerWidth = size.width / tile.width;

		tiles = vector<IntRect>();

		for (int y = 0; y < tilePerHeight; y++) { for (int x = 0; x < tilePerWidth; x++) { tiles.push_back(IntRect(x, y, tile.width, tile.height)); } }
	}

	public: void setTile(int index)
	{
		if (index != current)
		{
			sprite.setTextureRect(tiles[index]);
			current = index;
		}
	}

	public: void move(float x, float y)
	{
		Entity2D::move(x, y);
		sprite.setPosition(x, y);
		rectangle.setPosition(x, y);
	}
};