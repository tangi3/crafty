using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

public class Node2D : Node
{
    public Vector2 position;
    private Rectangle rect;

    private Texture2D texture;
    public Vector2 texture_size;

    public int unit;
    private Rectangle part;

    public Color color;
    private Color[] colorData;

    private bool _is_rectangle;

    public Node2D(ref GraphicsDeviceManager graphics)
    {
        color = Color.White;

        unit = 32;

        rect = new Rectangle(0, 0, 1, 1);
        position = new Vector2(0, 0);

        part = new Rectangle(0, 0, unit, unit);
        texture_size = new Vector2(0, 0);

        _is_rectangle = true;

        resize(ref graphics, 1, 1);
        fill(ref graphics);
    }

    public void update()
    {
        if (rect.X != position.X) rect.X = (int)position.X;
        if (rect.Y != position.Y) rect.Y = (int)position.Y;
    }

    public void draw(ref SpriteBatch spriteBatch) { spriteBatch.Draw(texture, rect, color); }

    public void blit(ref SpriteBatch spriteBatch, int i, int x, int y)
    {
        rect.X = x;
        rect.Y = y;

        rect.Width = unit;
        rect.Height = unit;
        part.Width = unit;
        part.Height = unit;

        part.Y = (int)Math.Floor(i / ((texture_size.X/ 10) / unit));
        part.X = (int)(i - (part.Y * ((texture_size.X / 10) / unit)));

        part.X *= unit;
        part.Y *= unit;

        spriteBatch.Draw(texture, rect, part, color);

        rect.Width = (int)texture_size.X;
        rect.Height = (int)texture_size.Y;
    }

    public void resize(ref GraphicsDeviceManager graphics, int width, int height)
    {
        rect.Width = width;
        rect.Height = height;

        texture_size.X = width;
        texture_size.Y = height;

        fill(ref graphics);
    }

    public void fill(ref GraphicsDeviceManager graphics)
    {
        if (_is_rectangle)
        {
            colorData = new Color[rect.Width * rect.Height];
            texture = new Texture2D(graphics.GraphicsDevice, rect.Width, rect.Height);
            for (int i = 0; i < colorData.Length; i++) colorData[i] = color;
            texture.SetData(colorData);
        }
    }
    public void load(ref GraphicsDeviceManager graphics, ContentManager content, string path, int width, int height)
    {
        _is_rectangle = false;
        texture = content.Load<Texture2D>(path);

        resize(ref graphics, width, height);
    }
}