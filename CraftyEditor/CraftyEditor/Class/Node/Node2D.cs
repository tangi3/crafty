using CraftyEditor;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

public class Node2D : Node
{
    public Texture2D texture;

    public Vector2 position;

    private Rectangle rect;

    public Color[] colorData;
    public Color color;

    public int corner_size;

    //when the UI do not have focus
    public bool sleep;

    public bool allow_user_move;
    public bool allow_user_resize;

    public bool allow_top_left_resize;
    public bool allow_top_right_resize;
    public bool allow_bot_left_resize;
    public bool allow_bot_right_resize;

    private bool _is_corner_top_left_colliding, _is_corner_top_right_colliding, _is_corner_bot_left_colliding, _is_corner_bot_right_colliding;

    private int mouseX, mouseY, previous_frame_mouse_x, previous_frame_mouse_y;

    private int mouseX_to_rectX_distance, mouseY_to_rectY_distance;
    private int mouse_x_speed, mouse_y_speed;

    private bool is_being_drag, is_being_resized, _drag_on_hold, _resize_on_hold;

    private int new_width, new_height;

    private bool mouseCollideOnX, mouseCollideOnY;

    public Node2D(GraphicsDeviceManager graphics) : base()
    {
        position.X = 0;
        position.Y = 0;

        corner_size = 10;

        color = Color.White;

        rect = new Rectangle(0, 0, 1, 1);

        mouseCollideOnX = false;
        mouseCollideOnY = false;

        sleep = false;

        allow_user_move = true;
        allow_user_resize = true;

        allow_top_left_resize = true;
        allow_top_right_resize = true;
        allow_bot_left_resize = true;
        allow_bot_right_resize = true;

        _is_corner_top_left_colliding = false;
        _is_corner_top_right_colliding = false;
        _is_corner_bot_left_colliding = false;
        _is_corner_bot_right_colliding = false;

        is_being_drag = false;
        is_being_resized = false;
        _drag_on_hold = false;
        _resize_on_hold = false;

        _update(graphics);
    }

    public void update(ref GraphicsDeviceManager graphics, ref MouseState mouseState)
    {
        mouseX = mouseState.X;
        mouseY = mouseState.Y;

        mouse_x_speed = previous_frame_mouse_x - mouseX;
        mouse_y_speed = previous_frame_mouse_y - mouseY;

        mouseX_to_rectX_distance = previous_frame_mouse_x - (int)position.X;
        mouseY_to_rectY_distance = previous_frame_mouse_y - (int)position.Y;

        if(sleep == false) _mouse_events(graphics, ref mouseState);

        previous_frame_mouse_x = mouseX;
        previous_frame_mouse_y = mouseY;
    }

    public void draw(ref SpriteBatch spriteBatch)
    {
        rect.X = (int)position.X;
        rect.Y = (int)position.Y;

        spriteBatch.Draw(texture, rect, color);
    }

    public void resize(GraphicsDeviceManager graphics, int width, int height)
    {
        rect.Width = width;
        rect.Height = height;

        _update(graphics);
    }

    public bool click_on_top_left_corner(ref MouseState mouseState) { return _left_click_pressed_on(ref mouseState) && _is_corner_top_left_colliding; }
    
    public bool click_on_top_right_corner(ref MouseState mouseState) { return _left_click_pressed_on(ref mouseState) && _is_corner_top_right_colliding; }
    
    public bool click_on_bot_left_corner(ref MouseState mouseState) { return _left_click_pressed_on(ref mouseState) && _is_corner_bot_left_colliding; }
    
    public bool click_on_bot_right_corner(ref MouseState mouseState) { return _left_click_pressed_on(ref mouseState) && _is_corner_bot_right_colliding; }

    private void _update(GraphicsDeviceManager graphics)
    {
        colorData = new Color[rect.Width * rect.Height];
        texture = new Texture2D(graphics.GraphicsDevice, rect.Width, rect.Height);
        for (int i = 0; i < colorData.Length; i++) colorData[i] = color;
        texture.SetData(colorData);
    }

    private bool _mouse_moved(){ return mouseX != previous_frame_mouse_x | mouseY != previous_frame_mouse_y; }

    private bool _mouse_collide()
    {
        if (mouseX >= position.X && mouseX <= position.X + rect.Width) mouseCollideOnX = true;
        else mouseCollideOnX = false;

        if (mouseY >= position.Y && mouseY <= position.Y + rect.Height) mouseCollideOnY = true;
        else mouseCollideOnY = false;

        return mouseCollideOnX && mouseCollideOnY;
    }

    private bool _left_click_pressed_on(ref MouseState mouseState) { return mouseState.LeftButton == ButtonState.Pressed && _mouse_collide(); }

    private bool _resize(ref MouseState mouseState)
    {
        if (allow_user_resize)
        {
            if (_resize_on_hold)
            {
                is_being_resized = true;
            }
            else if (_left_click_pressed_on(ref mouseState) && _mouse_moved())
            {
                if (mouseX >= position.X && mouseX <= position.X + corner_size && mouseY >= position.Y && mouseY <= position.Y + corner_size) _is_corner_top_left_colliding = true;
                else _is_corner_top_left_colliding = false;

                if (mouseX >= position.X + rect.Width - corner_size && mouseX <= position.X + rect.Width && mouseY >= position.Y && mouseY <= position.Y + corner_size) _is_corner_top_right_colliding = true;
                else _is_corner_top_right_colliding = false;

                if (mouseX >= position.X && mouseX <= position.X + corner_size && mouseY >= position.Y + rect.Height - corner_size && mouseY <= position.Y + rect.Height) _is_corner_bot_left_colliding = true;
                else _is_corner_bot_left_colliding = false;

                if (mouseX >= position.X + rect.Width - corner_size && mouseX <= position.X + rect.Width && mouseY >= position.Y + rect.Height - corner_size && mouseY <= position.Y + rect.Height) _is_corner_bot_right_colliding = true;
                else _is_corner_bot_right_colliding = false;

                is_being_resized = _is_corner_top_left_colliding | _is_corner_top_right_colliding | _is_corner_bot_left_colliding | _is_corner_bot_right_colliding | _resize_on_hold;
            
                if (is_being_resized)
                {
                    _resize_on_hold = true;
                    allow_user_move = false;
                }
            }

            if (mouseState.LeftButton == ButtonState.Released && is_being_resized)
            {
                is_being_resized = false;
                _resize_on_hold = false;
                allow_user_move = true;
            }
        }
        else
        {
            is_being_resized = false;
            _resize_on_hold = false;
            allow_user_move = true;
        }

        return is_being_resized | _resize_on_hold;
    }

    private bool _drag(ref MouseState mouseState)
    {
        if (allow_user_move)
        {
            if (_left_click_pressed_on(ref mouseState) && _mouse_moved()) is_being_drag = true;
            if (is_being_drag) _drag_on_hold = true;
            if (mouseState.LeftButton == ButtonState.Released && is_being_drag)
            {
                is_being_drag = false;
                _drag_on_hold = false;
            }
        }
        else is_being_drag = false;

        return is_being_drag | _drag_on_hold;
    }

    private bool _mouse_out_of_boundaries() { return mouseX < 0 | mouseY > Game1.height | mouseY < 0 | mouseX > Game1.width; }

    private void _mouse_events(GraphicsDeviceManager graphics, ref MouseState mouseState)
    {
        if (_resize(ref mouseState))
        {
            new_width = rect.Width;
            new_height = rect.Height;

            if (_is_corner_top_left_colliding && allow_top_left_resize)
            {
                new_width = rect.Width + (previous_frame_mouse_x - mouseX);
                new_height = rect.Height + (previous_frame_mouse_y - mouseY);

                position.X -= new_width - rect.Width;
                position.Y -= new_height - rect.Height;
            }
            else if (_is_corner_top_right_colliding && allow_top_right_resize)
            {
                new_width = rect.Width + ((previous_frame_mouse_x - mouseX)*-1);
                new_height = rect.Height + (previous_frame_mouse_y - mouseY);

                position.Y += (new_height - rect.Height) * -1;
            }
            else if (_is_corner_bot_left_colliding && allow_bot_left_resize)
            {
                new_width = rect.Width + (previous_frame_mouse_x - mouseX);
                new_height = rect.Height - (previous_frame_mouse_y - mouseY);

                position.X -= new_width - rect.Width;
            }
            else if (_is_corner_bot_right_colliding && allow_bot_right_resize)
            {
                new_width = rect.Width - (previous_frame_mouse_x - mouseX);
                new_height = rect.Height - (previous_frame_mouse_y - mouseY);
            }

            if (new_width > 0 && new_height > 0) resize(graphics, new_width, new_height);
        }

        if (_drag(ref mouseState))
        {
            position.X = mouseX - mouseX_to_rectX_distance;
            position.Y = mouseY - mouseY_to_rectY_distance;
        }

        if (_mouse_out_of_boundaries())
        {
            _drag_on_hold = false;
            _resize_on_hold = false;
        }
    }
}