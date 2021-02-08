using Microsoft.Xna.Framework;
using System;

public class Cell : Node
{
	//to avoid memory leak
	private Vector2 buffer;

	//tile index
	public int index = 0;

	public Cell(int id) : base(id) {}

	//tile_size must be stored in tileset node, never in cell !
	public Vector2 get_screen_position(int tile_width, int tile_height)
    {
		buffer.X = this.position.X * tile_width;
		buffer.Y = this.position.Y * tile_height;
		return buffer;
    }
}
