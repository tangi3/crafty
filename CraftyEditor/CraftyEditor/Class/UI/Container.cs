using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Container : Node
{
    public int border_thickness = 0;
    public Color color = Color.White;

    private bool has_parent_changed = false;
    private bool has_been_changed = false;

    public bool background_visibility = true;

    public Container(int ID, float x, float y, int width, int height) : base(ID)
    {
        _set(x, y, width, height);
        has_been_changed = true;
    }

    public void Update(Node parent)
    {
        _update(parent);

        foreach(Node item in childs.Values)
        {
            item._update(parent);
        }
    }

    public override void _update(Node parent)
    {
        if(has_parent_changed)
        {
            _set(parent.position.X + border_thickness, parent.position.Y + border_thickness, parent.destination.Width - border_thickness, parent.destination.Height - border_thickness);
            has_parent_changed = false;
        }
            
    }

    public void Render(GraphicsDevice graphics, SpriteBatch spritebatch)
    {
        if (background_visibility)
        {
            if (has_been_changed)
            {
                texture = new Texture2D(graphics, destination.Width, destination.Height);
                data = new Color[destination.Width * destination.Height];

                for (int i = 0; i < data.Length; i++) data[i] = color;
                texture.SetData(data);

                has_been_changed = false;
            }

            Draw(ref spritebatch);
        }
    }

    public override void _set(float x, float y, int width, int height)
    {
        position.X = x;
        position.Y = y;
        destination.X = (int)x;
        destination.Y = (int)y;

        destination.Width = width;
        destination.Height = height;
    }
}
