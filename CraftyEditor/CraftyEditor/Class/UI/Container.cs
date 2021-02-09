using CraftyEditor;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Container : Node2D
{
    private int parent_x, parent_y, parent_width, parent_height;

    private int border_thickness;
    private Color border_color = Color.Gray;

    public Container(GraphicsDeviceManager graphics, Node2D parent) : base()
    {
        update_parent(parent);
        init_border(graphics, 4);
        Fill(graphics);
    }

    public Container(GraphicsDeviceManager graphics) : base()
    {
        update_parent();
        init_border(graphics, 4);
        Fill(graphics);
    }

    public void update()
    {
        //update all childs..
        //...
    }

    public void render(SpriteBatch spriteBatch)
    {
        draw(ref spriteBatch);

        //...
        //render all childs..
        //...

        if (border_thickness > 0)
        {
            Get<Node2D>(0).draw(ref spriteBatch);
            Get<Node2D>(1).draw(ref spriteBatch);
            Get<Node2D>(2).draw(ref spriteBatch);
            Get<Node2D>(3).draw(ref spriteBatch);
        }
    }

    public void update_parent()
    {
        parent_x = 0;
        parent_y = 0;
        parent_width = Game1.width;
        parent_height = Game1.height;
    }

    public void update_parent(Node2D parent)
    {
        parent_x = parent.rect.X;
        parent_y = parent.rect.Y;
        parent_width = parent.rect.Width;
        parent_height = parent.rect.Width;
    }

    public void set_border(GraphicsDeviceManager graphics, int thickness)
    {
        border_thickness = thickness;

        if (border_thickness > 0)
        {
            Get<Node2D>(0).resize(parent_width, border_thickness);
            Get<Node2D>(0).move(parent_x, parent_y);
            Get<Node2D>(0).fill(graphics, border_color);

            Get<Node2D>(1).resize(border_thickness, parent_height);
            Get<Node2D>(1).move(parent_x, parent_y);
            Get<Node2D>(1).fill(graphics, border_color);

            Get<Node2D>(2).resize(border_thickness, parent_height);
            Get<Node2D>(2).move(parent_x + parent_width - border_thickness, parent_y);
            Get<Node2D>(2).fill(graphics, border_color);

            Get<Node2D>(3).resize(parent_width, border_thickness);
            Get<Node2D>(3).move(parent_x, parent_y + parent_height - border_thickness);
            Get<Node2D>(3).fill(graphics, border_color);
        }
    }

    private void init_border(GraphicsDeviceManager graphics, int thickness)
    {
        Add(new Node2D());//TOP    : 0
        Add(new Node2D());//LEFT   : 1
        Add(new Node2D());//RIGHT  : 2
        Add(new Node2D());//BOTTOM : 3

        set_border(graphics, thickness);
    }

    private void Fill(GraphicsDeviceManager graphics)
    {
        resize(parent_width, parent_height);
        fill(graphics);
    }
}