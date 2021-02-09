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
    public int parent_x, parent_y, parent_width, parent_height;

    public int border_thickness = 2;
    public Color border_color = Color.Gray;

    /* private int previousWidth = 0;
    private int previousHeight = 0;

    private int previousOffsetX = 0;
    private int previousOffsetY = 0;*/

    public int offsetX = 0;
    public int offsetY = 0;

    public bool border_left_visible = true;
    public bool border_right_visible = true;
    public bool border_top_visible = true; 
    public bool border_bottom_visible = true;

    public int left_split = 1;
    public int right_split = 4;

    private int leftRowWidth = 0;
    private int rightRowWidth = 0;
    private int rowLeftOffset = 0;

    private int countBuffer;

    public Container(GraphicsDeviceManager graphics, Node2D parent) : base()
    {
        update_parent(parent); 
        init_border(graphics);
        Fill(graphics);
    }

    public Container(GraphicsDeviceManager graphics) : base()
    {
        update_parent();
        init_border(graphics);
        Fill(graphics);
    }
    public Container(bool ignore) : base() { }

    /* public void updateChanges(GraphicsDeviceManager graphics)
    {
        init_border(graphics);

        if (offsetX != previousOffsetX)
        {
            rect.X = rect.X + offsetX;
            rect.Y = rect.Y = offsetY;
            previousOffsetX = offsetX;
            previousOffsetY = offsetY;
        }

        if (rect.Width != previousWidth)
        {
            parent_width = rect.Width;
            parent_height = rect.Height;
            previousWidth = rect.Height;
            previousHeight = rect.Width;

            Fill(graphics);
            set_border(graphics);
        }
    }*/

    public void update()
    {
        //update all childs..
        //...
    }

    public void render(SpriteBatch spriteBatch)
    {
        draw(ref spriteBatch);

        for (int i = 0; i < left_split + right_split; i++){
            Get<Row>(countBuffer + i).draw(ref spriteBatch);
            Get<Row>(countBuffer + i).renderBorders(spriteBatch);
        }

        if (border_thickness > 0) { renderBorders(spriteBatch); }
    }

    public void renderBorders(SpriteBatch spriteBatch)
    {
        if (border_left_visible) { Get<Node2D>(0).draw(ref spriteBatch); }
        if (border_right_visible) { Get<Node2D>(1).draw(ref spriteBatch); }
        if (border_top_visible) { Get<Node2D>(2).draw(ref spriteBatch); }
        if (border_bottom_visible) { Get<Node2D>(3).draw(ref spriteBatch); }
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
        parent_height = parent.rect.Height;
    }

    public void set_border(GraphicsDeviceManager graphics)
    {
        if (border_thickness > 0)
        {
            Get<Node2D>(0).move(parent_x + offsetX, parent_y + offsetY);
            Get<Node2D>(0).resize(parent_width, border_thickness);
            Get<Node2D>(0).fill(graphics, border_color);

            Get<Node2D>(1).move(parent_x + offsetX, parent_y + offsetY);
            Get<Node2D>(1).resize(border_thickness, parent_height);
            Get<Node2D>(1).fill(graphics, border_color);

            Get<Node2D>(2).move(parent_x + offsetX + parent_width - border_thickness, parent_y + offsetY);
            Get<Node2D>(2).resize(border_thickness, parent_height);
            Get<Node2D>(2).fill(graphics, border_color);

            Get<Node2D>(3).move(parent_x + offsetX, parent_y + offsetY + parent_height - border_thickness);
            Get<Node2D>(3).resize(parent_width, border_thickness);
            Get<Node2D>(3).fill(graphics, border_color);
        }
    }

    public void init_border(GraphicsDeviceManager graphics)
    {
        Add(new Node2D());//TOP    : 0
        Add(new Node2D());//LEFT   : 1
        Add(new Node2D());//RIGHT  : 2
        Add(new Node2D());//BOTTOM : 3

        set_border(graphics);

        countBuffer = Count;
    }

    public void Fill(GraphicsDeviceManager graphics)
    {
        resize(parent_width, parent_height);
        fill(graphics);

        init_rows(graphics);
    }

    public void init_rows(GraphicsDeviceManager graphics, bool horizontal = true)
    {
        //TO DO : when already added

        if(left_split > 0 && right_split > 0)
        {
            leftRowWidth = (parent_width / 2) / left_split;
            rightRowWidth = (parent_width / 2) / right_split;
            rowLeftOffset = 0;

            if (horizontal)
            {
                for (int i = 0; i < left_split; i++)
                {
                    Add(new Row(this, graphics, leftRowWidth, rect.Height - (border_thickness * 2), i, new Color(237, 28, 36)));
                    rowLeftOffset += leftRowWidth + border_thickness;
                }

                for (int i = 0; i < right_split; i++)
                {
                    Add(new Row(this, graphics, rightRowWidth, rect.Height - (border_thickness * 2), i, new Color(0, 162, 232), rowLeftOffset));
                    rowLeftOffset += rightRowWidth + border_thickness;
                }
            }
            else
            {
                    //...
            }
        }
    }
}