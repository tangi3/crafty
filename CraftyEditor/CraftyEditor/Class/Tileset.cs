using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class Tileset : Node
{
	//tilesets will automatically be splitted into a cell collection

	int tile_size;
	int width, height;

	//to avoid memory leaks:
	int bufferSourceX, bufferSourceY;

	public Tileset(int id, int w, int h, int tileSize) : base(id)
	{
		tile_size = tileSize;

		width = w;
		height = h;
	}

	public void DrawTile(SpriteBatch spriteBatch, float x, float y, int tile_index)
    {
		bufferSourceY = (int)Math.Floor((float)tile_index / ((float)height / (float)tile_size));
		bufferSourceX = tile_index - (bufferSourceY * (width / tile_size));

		bufferSourceX *= tile_size;
		bufferSourceY *= tile_size;

		this.Draw(ref spriteBatch, x, y, bufferSourceX, bufferSourceY, tile_size, tile_size);
	}
}
