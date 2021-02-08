using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class UIManager : Container
{
	public Dictionary<int, Container> containers;

	public UIManager(int screen_width, int screen_height) : base(0, 0, 0, screen_width, screen_height)
	{
		position.X = 0;
		position.Y = 0;
		destination.X = (int)position.X;
		destination.Y = (int)position.Y;
		destination.Width = screen_width;
		destination.Height = screen_height;
		containers = new Dictionary<int, Container>();
	}
	public void UpdateUI() { foreach(Container item in containers.Values) { item.Update(this); } }

	public void RenderSelf(GraphicsDevice graphics, SpriteBatch spriteBatch) { Render(graphics, spriteBatch); }

	public void RenderUI(GraphicsDevice graphics, SpriteBatch spriteBatch) { foreach (Container item in containers.Values) { item.Render(graphics, spriteBatch); } }
}
