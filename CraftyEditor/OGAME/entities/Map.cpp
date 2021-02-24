#pragma once
#include "Entity2D.cpp"
#include "../components/Camera.cpp"

struct coord { int i, j; };
struct tile { coord coords; int frame, z; };
struct chunk { coord start_tile; int nbTilePerRow, nbRows; vector<tile> tiles; };

class Map : public Entity2D
{
	friend class Entity2D;

	public: chunk chunk_buffer;
	public: tile tile_buffer;
	public: vector<chunk> chunks;
	public: int chunck_width, chunk_height;

	public: Map()
	{
		add(reinterpret_cast<Camera::Component*>(new Camera()));
		chunks = vector<chunk>();

		chunck_width = 16;
		chunk_height = 16;
	}

	public: void loadTileset(string path, int unit_size) { loadFromFile("tilesets/" + path, unit_size, unit_size); }

	public: void loadChunkFrom(int i, int j)
	{
		chunk_buffer.tiles = vector<tile>();
		chunks.push_back(chunk_buffer);

		for (int h = j; h < chunk_height; h++)
		{
			for (int w = i; w < chunck_width; w++)
			{
				tile_buffer.coords.i = w;
				tile_buffer.coords.j = h;
				tile_buffer.frame = 0;
				tile_buffer.z = 0;

				chunks[chunks.size() - 1].tiles.push_back(tile_buffer);
			}
		}
	}

	public: chunk& getChunk(int i) { return chunks[i]; }
};