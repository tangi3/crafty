using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Node2D : Node
{
    private Texture2D texture;

    private Rectangle rect;
    private Rectangle part;

    private Color color;
    private Color[] colorData;

    public Node2D() : base()
    {
        color = Color.White;

        move(0, 0);
        resize(1, 1);
    }

    public T Get<T>(int key){ return (T)base.childs[key]; }
    
    public void broadcast(string msg)
    {
        for (int key = 0; key < childs.Length; key++)
        {
            Node2D tmp = (Node2D)childs[key];
            tmp.callback_send(msg);
        }
    }

    public void move(int x, int y)
    {
        rect.X = x;
        rect.Y = y;
    }

    public void resize(int width, int height)
    {
        rect.Width = width;
        rect.Height = height;
    }

    public void loadFromPipeline(ContentManager content, string type, string path, int width, int height)
    {
        texture = content.Load<Texture2D>(type + "s/" + path);
        resize(width, height);
    }

    public void fill(GraphicsDeviceManager graphics)
    {
        texture = new Texture2D(graphics.GraphicsDevice, rect.Width, rect.Height);
        colorData = new Color[rect.Width * rect.Height];
        for (int i = 0; i < colorData.Length; i++) colorData[i] = color;
        texture.SetData(colorData);
    }
    public void fill(GraphicsDeviceManager graphics, Color c)
    {
        color = c;
        texture = new Texture2D(graphics.GraphicsDevice, rect.Width, rect.Height);
        colorData = new Color[rect.Width * rect.Height];
        for (int i = 0; i < colorData.Length; i++) colorData[i] = color;
        texture.SetData(colorData);
    }

    public void draw(ref SpriteBatch spriteBatch) { spriteBatch.Draw(texture, rect, color); }

    public void blit(ref SpriteBatch spriteBatch, int x, int y, int width, int height)
    {
        rect.Width = width;
        rect.Height = height;

        part.X = x;
        part.Y = y;
        part.Width = width;
        part.Height = height;

        spriteBatch.Draw(texture, rect, part, color);
    }
}
