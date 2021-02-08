using Microsoft.Xna.Framework;
using System;

public class Cell : Node
{
	//tile index
	public int index = 0;

	public Cell(int id) : base(id) {}

	//tile_size must be stored in tileset node, never in cell !

	//this gives the position relative to the map
	//this.position is the screen position
	public Vector2 get_cell_position(int tile_width, int tile_height)
    {
		this.position.X = (float)Math.Floor(this.position.X / tile_width);
		this.position.Y = (float)Math.Floor(this.position.Y / tile_height);
		return position;
    }
}
