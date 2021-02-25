#pragma once
#include "../../OGAME/base/Component.cpp"
#include "../entities/Map.cpp"

class Camera : public Component
{
	public: float x, y;
	public: int i, j;
	public: int screen_width, screen_height, unit_size;
	public: bool load;

	public: Camera() : Component("camera") {}

	public: Camera(Map& map, int w, int h, int u) : Component("camera")
	{
		screen_width = w;
		screen_height = h;
		unit_size = u;

		x = 0;
		y = 0;

		load = false;

		updateChunks(map);
	}

	public: void move(Map& map, float xAxis, float yAxis)
	{
		x += xAxis;
		y += yAxis;

		updateChunks(map);
	}

	public: void updateChunks(Map& map)
	{
		i = floor(x / unit_size);
		j = floor(y / unit_size);

		if (map.chunks.size() > 0)
			if (map.chunks[3].tiles[0].coords.i != i || map.chunks[3].tiles[0].coords.j != j) load = true;
			else load = false;
		else load = true;

		if (load)
		{
			map.chunks.clear();
			map.tiles.clear();

			map.loadChunkFrom(i - map.chunck_width * 3, j, unit_size, screen_width, screen_height);
			map.loadChunkFrom(i - map.chunck_width * 2, j, unit_size, screen_width, screen_height);
			map.loadChunkFrom(i - map.chunck_width, j, unit_size, screen_width, screen_height);

			//origin chunk
			map.loadChunkFrom(i, j, unit_size, screen_width, screen_height);

			map.loadChunkFrom(i + map.chunck_width, j, unit_size, screen_width, screen_height);
			map.loadChunkFrom(i + map.chunck_width * 2, j, unit_size, screen_width, screen_height);
			map.loadChunkFrom(i + map.chunck_width * 3, j, unit_size, screen_width, screen_height);

			map.loadChunkFrom(i - map.chunck_width * 3, j - map.chunk_height, unit_size, screen_width, screen_height);
			map.loadChunkFrom(i - map.chunck_width * 2, j - map.chunk_height, unit_size, screen_width, screen_height);
			map.loadChunkFrom(i - map.chunck_width, j - map.chunk_height, unit_size, screen_width, screen_height);
			map.loadChunkFrom(i, j - map.chunk_height, unit_size, screen_width, screen_height);
			map.loadChunkFrom(i + map.chunck_width, j - map.chunk_height, unit_size, screen_width, screen_height);
			map.loadChunkFrom(i + map.chunck_width * 2, j - map.chunk_height, unit_size, screen_width, screen_height);
			map.loadChunkFrom(i + map.chunck_width * 3, j - map.chunk_height, unit_size, screen_width, screen_height);

			load = false;
		}
	}
};