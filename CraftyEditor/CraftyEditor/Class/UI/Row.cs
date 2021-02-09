using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Row : Container
{
    public Row(Container parent, GraphicsDeviceManager graphics, int width, int height, int index, Color c, int leftOffset = 0) : base(false)
    {
        border_right_visible = true;
        border_left_visible = false;
        border_top_visible = false;
        border_bottom_visible = false;

        color = c;
        
        update_parent(parent);

        move(leftOffset + parent_x + parent.border_thickness, parent_y + parent.border_thickness);

        resize(width, height);
        init_border(graphics);
        fill(graphics);
    }
    public Row(Container parent, GraphicsDeviceManager graphics, int width, int height, int index, int leftOffset = 0) : base(false)
    {
        border_left_visible = false;
        border_top_visible = false;
        border_bottom_visible = false;

        update_parent(parent);

        move(leftOffset + ((parent_x + parent.border_thickness) * (index + 1)), parent_y + parent.border_thickness);

        resize(width, height);
        init_border(graphics);
        fill(graphics);
    }
}
