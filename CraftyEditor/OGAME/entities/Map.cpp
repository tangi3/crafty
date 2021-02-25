#pragma once
#include "Entity2D.cpp"

struct coord { int i, j; };
struct tile { coord coords; int frame, z; };
struct chunk { vector<tile> tiles; };

class Map : public Entity2D
{
	friend class Entity2D;

	public: int tile_size;
	public: chunk chunk_buffer;
	public: tile tile_buffer;
	public: vector<chunk> chunks;
	public: vector<tile> tiles;
	public: int chunck_width, chunk_height;
	private: int w, h;

	public: bool changes;

	public: RenderTexture renderTexture;
	public: Sprite data;

	public: bool grid = true;

	public: Map()
	{
		chunks = vector<chunk>();

		chunck_width = 16;
		chunk_height = 16;

		tile_size = 32;

		changes = false;
	}

	public: void loadTileset(string path, int unit_size) { loadFromFile("tilesets/" + path, unit_size, unit_size); }

	public: void loadChunkFrom(int i, int j, int unit_size, int screen_width, int screen_height)
	{
		chunk_buffer.tiles = vector<tile>();
		chunks.push_back(chunk_buffer);

		w, h;

		for (h = 0; h < chunk_height; h++)
		{
			for (w = 0; w < chunck_width; w++)
			{
				tile_buffer.coords.i = i + w + (((screen_width / 2) - unit_size) / unit_size);
				tile_buffer.coords.j = j + h + (((screen_height / 2) - unit_size) / unit_size);
				tile_buffer.frame = 0;
				tile_buffer.z = 0;

				chunks[chunks.size() - 1].tiles.push_back(tile_buffer);
			}
		}

		changes = true;
	}

	public: void update()
	{
		tiles = vector<tile>();

		for (int c = 0; c < chunks.size(); c++) {
			for (int t = 0; t < getChunk(c).tiles.size(); t++) {
				tile_buffer = getChunk(c).tiles[t];
				tiles.push_back(tile_buffer);}}

		chunks.clear();
	}

	public: void unloadChunk(int id) { chunks.erase(chunks.begin() + id); }

	public: void unloadLastChunk() { unloadChunk(chunks.size() - 1); }

	public: chunk& getChunk(int i) { return chunks[i]; }
};