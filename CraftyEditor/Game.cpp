#pragma once
#include "OGAME/entities/Map.cpp"
using namespace Ogame;

class Game : public SFMLWindow
{
	public: Entity2D cursor;
	public: Map map;
		 
	public: bool grid;

	public: Game(string caption, int w, int h, int tileSize) : SFMLWindow() { load(caption, w, h, tileSize); }

	public: void Initialize()
	{
		SFMLWindow::Initialize();

		map.load("test", tile_size, width, height);

		grid = true;

		cursor.loadFromFile("tileset", "cursor");
		cursor.loadTiles(tile_size);
		cursor.setFrame(cursor_state);

		//...
	}
	public: void Update()
	{
		SFMLWindow::Update();

		if (mouse()->changedTile) cursor.move(mouse()->tile.x, mouse()->tile.y);
		if (cursor.frame != cursor_state) cursor.setFrame(cursor_state);

		cursor.update(tile_size);

		//...
	}

	public: void Draw()
	{
		SFMLWindow::Draw();

		if (grid) window().draw(map.grid());

		window().draw(cursor.sprite());

		//...
	}
};