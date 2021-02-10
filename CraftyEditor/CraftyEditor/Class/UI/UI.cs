using CraftyEditor;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UI : BaseUI
{
    public bool visible;

    public bool allow_drag;

    private bool previous_toolbar, previous_border;
    private int previous_border_thickness, previous_border_toolbar;
    private int previous_base_width, previous_base_height, previous_x, previous_y;

    private bool horizontal;
    private bool vertical;
    private bool available_space_offset;

    public bool left_click, right_click, left_click_released, right_click_released, mouse_hover;
    public bool mouse_move, on_drag, on_resize;

    private bool on_drag_hold;

    private int previous_frame_mouse_x, previous_frame_mouse_y;
    private int mouseX_to_rectX_distance, mouseY_to_rectY_distance;

    public bool full;
    public int reduced_width, reduced_height;

    public UI(ref GraphicsDeviceManager graphics) : base(ref graphics)
    {
        available_space_offset = true;

        visible = true;

        previous_border = border;
        previous_toolbar = toolbar;

        horizontal = true;
        vertical = true;

        mouse_move = false;

        on_drag = false;
        on_drag_hold = false;
        allow_drag = true;

        reduced_width = Game1.width / 50;
        reduced_height = 20;

        full = true;
    }

    public void update(ref GraphicsDeviceManager graphics, ref MouseState mouseState, int reduce_offset, UI parent = null)
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

        listen(ref graphics, ref mouseState, reduce_offset, parent);
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

    public void listen(ref GraphicsDeviceManager graphics, ref MouseState mouseState, int reduce_offset, UI parent = null)
    {
        if (mouse_hover) giveFocus(ref mouseState);
        if (on_drag_hold == false && mouse_hover == false) unfocus();

        if (state.state == StateMachine.active)
        {
            drag(ref mouseState);

            reduce(ref graphics, ref mouseState, reduce_offset, parent);

            enlarge(ref graphics, ref mouseState);

            quit(ref mouseState);
        }
        else if(state.state == StateMachine.inactive)
        {
            //...
        }

        base._listen();
    }

    private void drag(ref MouseState mouseState)
    {
        if (allow_drag && on_drag | on_drag_hold)
        {
            x = mouseState.X - mouseX_to_rectX_distance;
            y = mouseState.Y - mouseY_to_rectY_distance;

            if (on_drag_hold == false) on_drag_hold = true;
        }
        if (on_drag_hold && left_click_released) { on_drag = false; on_drag_hold = false; }
    }

    private void quit(ref MouseState mouseState) { if (left_click && collide_button_3(ref mouseState)) _quit(); }

    private void reduce(ref GraphicsDeviceManager graphics, ref MouseState mouseState, int reduce_offset, UI parent = null)
    {
        if (left_click && collide_button_2(ref mouseState) && full)
        {
            previous_toolbar = toolbar;
            previous_border = border;

            previous_border_thickness = border_thickness;
            previous_border_toolbar = toolbar_thickness;

            toolbar = false;
            border = false;

            previous_x = x;
            previous_y = y;

            if (parent != null)
            {
                x = parent.x + reduce_offset;
                y = parent.y + (int)parent.real_size.Y - reduced_height;
                reduced_width = (int)parent.real_size.X / 10;
            }
            else
            {
                x = reduce_offset;
                y = Game1.height - reduced_height;
                reduced_width = Game1.width / 10;
            }

            previous_base_width = (int)base_size.X;
            previous_base_height = (int)base_size.Y;

            resize(ref graphics, reduced_width, reduced_height);

            unfocus();
            full = false;
            allow_drag = false;
        }
    }

    private void enlarge(ref GraphicsDeviceManager graphics, ref MouseState mouseState)
    {
        if(left_click && collide(ref mouseState) && full == false)
        {
            toolbar = previous_toolbar;
            border = previous_border;

            x = previous_x;
            y = previous_y;

            border_thickness = previous_border_thickness;
            toolbar_thickness = previous_border_toolbar;

            resize(ref graphics, previous_base_width, previous_base_height);
            giveFocus(ref mouseState);

            full = true;
            allow_drag = true;
        }
    }

    //override function
    public void _quit()
    {
        //...
    }
}
