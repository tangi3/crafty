using CraftyEditor;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Camera : Node
{
    public int unit;

    public Rectangle origin;
    public Rectangle viewport;

    public int zoom_ratio;

    public Camera(): base()
    {
        unit = 1;

        origin = new Rectangle(0, 0, 1, 1);
        viewport = new Rectangle(0, 0, 1, 1);

        zoom_ratio = 0;
    }

    public void update(int width, int height)
    {
        viewport.X = origin.X - ((origin.Width / 2) - (unit / 2));
        viewport.Y = origin.Y - ((origin.Height / 2) - (unit / 2));
        viewport.Width = width;
        viewport.Height = height;
    }

    public void setOrigin(int x, int y, int width, int height)
    {
        origin.X = (((int)Math.Floor(x / (double)unit)) * unit) - (unit / 2);
        origin.Y = (((int)Math.Floor(y / (double)unit)) *unit) -(unit / 2);
        origin.Width = width;
        origin.Height = height;

        reset();
    }
    
    public void reset() { viewport = origin; zoom_ratio = 0; }

    public void zoom() { zoom_ratio += 1; }

    public void move(int x, int y)
    {
        //...
    }
}
