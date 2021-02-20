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

	public: Unit() : Entity2D() { initialize(); }

	public: Unit(string id) : Entity2D(id) { initialize(); }

	public: Unit(string id, string t) : Entity2D(id) { initialize(t); }

	private: void initialize(string t = "tilesets")
	{
		type = t;
		path = "C:\\Users\\tangi\\Desktop\\crafty\\CraftyEditor\\OGAME\\assets\\" + type + "\\" + key + ".png";

		tile = Size();
		tile.width = 64;
		tile.height = 32;
	}
};