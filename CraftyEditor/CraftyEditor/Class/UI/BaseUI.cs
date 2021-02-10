using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BaseUI : Node2D
{
    public int x, y;

    public StateMachine state;
    private Dictionary<string, bool> events;

    private Vector2 base_size;
    private Vector2 real_size;

    public bool toolbar, border;
    public int toolbar_thickness, border_thickness;

    private int available_space_offset_X, available_space_offset_Y;//will contain child related offsets

    public Rectangle toolbar_collision, available_space_collision;

    public BaseUI(ref GraphicsDeviceManager graphics) : base(ref graphics)
    {
        x = 0;
        y = 0;

        state = new StateMachine();
        events = new Dictionary<string, bool>();

        toolbar = true;
        border = true;

        toolbar_thickness = 10;
        border_thickness = 4;

        available_space_offset_X = 0;
        available_space_offset_Y = 0;

        base_size = new Vector2(1, 1);
        real_size = new Vector2(1, 1);
    }

    //if mouse enter, object collision, etc...
    public void giveFocus(Node2D obj) { if (state.state == StateMachine.inactive && collide(obj)) state.Next(); }
    public void giveFocus(ref MouseState mouseState) { if (state.state == StateMachine.inactive && collide(ref mouseState)) state.Next(); }

    public new void update()
    {
        position.X = x;
        position.Y = y;

        _listen();

        base.update();
    }

    public void AddEvent(string evt) { events.Add(evt, false); }

    //this need to be overrided : you will handle all events here :
    public void _listen() { }

    public bool is_(string evt) { return events[evt]; }

    public new void resize(ref GraphicsDeviceManager graphics, int width, int height)
    {
        base_size.X = width;
        base_size.Y = height;

        toolbar_collision.X = (int)position.X;
        toolbar_collision.Y = (int)position.Y;
        toolbar_collision.Width = (int)base_size.X;
        toolbar_collision.Height = toolbar_thickness;

        available_space_collision.X = (int)position.X;

        if (toolbar && border)
        {
            available_space_collision.Y = (int)position.Y + toolbar_thickness + border_thickness;

            real_size.X = base_size.X;
            real_size.Y = (int)base_size.Y + toolbar_thickness + (border_thickness * 2);
        }
        else if(toolbar && border == false)
        {
            available_space_collision.Y = (int)position.Y + toolbar_thickness;

            real_size.X = base_size.X;
            real_size.Y = (int)base_size.Y + toolbar_thickness;
        }
        else if(toolbar == false && border)
        {
            available_space_collision.Y = (int)position.Y + border_thickness;

            real_size.X = base_size.X;
            real_size.Y = (int)base_size.Y + (border_thickness * 2);
        }
        else
        {
            available_space_collision.Y = (int)position.Y;

            real_size.X = base_size.X;
            real_size.Y = (int)base_size.Y;
        }

        available_space_collision.X += available_space_offset_X;
        available_space_collision.Y += available_space_offset_Y;

        base.resize(ref graphics, (int)real_size.X, (int)real_size.Y);
    }

    public bool collide(Node2D obj) { return obj.position.X >= x && obj.position.X <= x + real_size.X && obj.position.Y >= y && obj.position.Y <= y + real_size.Y; }

    public bool collide(ref MouseState mouseState) { return mouseState.X >= x && mouseState.X <= x + real_size.X && mouseState.Y >= y && mouseState.Y <= y + real_size.Y; }
}
