using Microsoft.Xna.Framework;
using System;

public class Tileset : Node
{
	//tilesets will automatically be splitted into a cell collection

	int tile_width, tile_height;

	//sprite here...

	public Tileset(int id, int tileW, int tileH) : base(id)
	{
		tile_width = tileW;
		tile_height = tileH;
	}

	public void split()
    {
		//...
    }
}
