using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UI : BaseUI
{
    //visibility, etc. ...
    private bool horizontal;
    private bool vertical;
    private bool available_space_offset;

    public bool left_click, right_click, left_click_released, right_click_released, mouse_hover;
    public bool mouse_move, on_drag, on_resize;

    private bool on_drag_hold, on_resize_hold;

    private int previous_frame_mouse_x, previous_frame_mouse_y;
    private int mouseX_to_rectX_distance, mouseY_to_rectY_distance;

    public UI(ref GraphicsDeviceManager graphics) : base(ref graphics)
    {
        available_space_offset = true;

        horizontal = true;
        vertical = true;

        mouse_move = false;

        on_drag = false;
        on_resize = false;

        on_drag_hold = false;
        on_resize_hold = false;

        AddEvent("move");
        AddEvent("resize");
        AddEvent("reduce");
        AddEvent("enlarge");
        AddEvent("show");
        AddEvent("hide");
        AddEvent("quit");
    }

    public void update(ref MouseState mouseState, UI parent = null)
    {
        mouseX_to_rectX_distance = previous_frame_mouse_x - x;
        mouseY_to_rectY_distance = previous_frame_mouse_y - y;

        if (collide(ref mouseState)) mouse_hover = true;
        else mouse_hover = false;

        if (mouse_hover && mouseState.LeftButton == ButtonState.Pressed) left_click = true;
        else left_click = false;

        if (mouse_hover && mouseState.RightButton == ButtonState.Pressed) right_click = true;
        else right_click = false;

        if (mouse_hover && mouseState.LeftButton == ButtonState.Released) left_click_released = true;
        else left_click_released = false;

        if (mouse_hover && mouseState.RightButton == ButtonState.Released) right_click_released = true;
        else right_click_released = false;

        if (mouse_hover && mouseState.X != previous_frame_mouse_x | mouseState.Y != previous_frame_mouse_y) mouse_move = true;
        else mouse_move = false;

        if (mouse_move && left_click) on_drag = true;
        else on_drag = false;

        listen(ref mouseState);
        base.update(ref mouseState);

        if (parent != null)
        {
            if(available_space_offset)
            {
                parent.available_space_offset_X += (int)real_size.X;
                parent.available_space_offset_Y += (int)real_size.Y;

                available_space_offset = false;
            }

            if (horizontal)
            {
                x = parent.available_space_collision.X + available_space_offset_X - (int)real_size.X; ;
                y = parent.available_space_collision.Y + available_space_offset_Y - (int)real_size.Y; ;
            }
            else if (vertical)
            {
                //...
            }
        }

        previous_frame_mouse_x = mouseState.X;
        previous_frame_mouse_y = mouseState.Y;
    }

    public new void resize(ref GraphicsDeviceManager graphics, int width, int height)
    {
        available_space_offset = true;
        base.resize(ref graphics, width, height);
    }

    public void listen(ref MouseState mouseState)
    {
        if (on_drag | on_drag_hold)
        {
            x = mouseState.X - mouseX_to_rectX_distance;
            y = mouseState.Y - mouseY_to_rectY_distance;

            if(on_drag_hold == false) on_drag_hold = true;
        }
        if (on_drag_hold && left_click_released) { on_drag = false;  on_drag_hold = false; }

        base._listen();
    }
}
