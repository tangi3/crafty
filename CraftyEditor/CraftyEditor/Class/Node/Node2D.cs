using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Node2D : Node
{
    public Texture2D texture;

    public Vector2 position;

    private Rectangle rect;

    public Color[] colorData;
    public Color color;

    public int corner_size;

    public bool allow_user_move;
    public bool allow_user_resize;

    private bool _is_corner_top_left_colliding, _is_corner_top_right_colliding, _is_corner_bot_left_colliding, _is_corner_bot_right_colliding;

    private int mouseX, mouseY, previous_frame_mouse_x, previous_frame_mouse_y;

    private int mouseX_to_rectX_distance, mouseY_to_rectY_distance;
    private int mouse_x_speed, mouse_y_speed;

    private bool is_being_drag, is_being_resized;

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

        allow_user_move = true;
        allow_user_resize = true;

        _is_corner_top_left_colliding = false;
        _is_corner_top_right_colliding = false;
        _is_corner_bot_left_colliding = false;
        _is_corner_bot_right_colliding = false;

        is_being_drag = false;
        is_being_resized = false;

        _update(graphics);
    }

    public void update(ref MouseState mouseState)
    {
        mouseX = mouseState.X;
        mouseY = mouseState.Y;

        mouse_x_speed = previous_frame_mouse_x - mouseX;
        mouse_y_speed = previous_frame_mouse_y - mouseY;

        mouseX_to_rectX_distance = previous_frame_mouse_x - (int)position.X;
        mouseY_to_rectY_distance = previous_frame_mouse_y - (int)position.Y;

        _mouse_events(ref mouseState);

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
            if (_left_click_pressed_on(ref mouseState) && _mouse_moved())
            {
                if (mouseX >= position.X && mouseX <= position.X + corner_size && mouseY >= position.Y && mouseY <= position.Y + corner_size) _is_corner_top_left_colliding = true;
                else _is_corner_top_left_colliding = false;

                if (mouseX >= position.X + rect.Width - corner_size && mouseX <= position.X + rect.Width && mouseY >= position.Y && mouseY <= position.Y + corner_size) _is_corner_top_right_colliding = true;
                else _is_corner_top_right_colliding = false;

                if (mouseX >= position.X && mouseX <= position.X + corner_size && mouseY >= position.Y + rect.Height - corner_size && mouseY <= position.Y + rect.Height) _is_corner_bot_left_colliding = true;
                else _is_corner_bot_left_colliding = false;

                if (mouseX >= position.X + rect.Width - corner_size && mouseX <= position.X + rect.Width && mouseY >= position.Y + rect.Height - corner_size && mouseY <= position.Y + rect.Height) _is_corner_bot_right_colliding = true;
                else _is_corner_bot_right_colliding = false;

                is_being_resized = _is_corner_top_left_colliding | _is_corner_top_right_colliding | _is_corner_bot_left_colliding | _is_corner_bot_right_colliding;
            }

            if (mouseState.LeftButton == ButtonState.Released && is_being_resized) is_being_resized = false;
        }
        else is_being_resized = false;

        return is_being_resized;
    }

    private bool _drag(ref MouseState mouseState)
    {
        if (allow_user_move)
        {
            if (_left_click_pressed_on(ref mouseState) && _mouse_moved()) is_being_drag = true;
            if (mouseState.LeftButton == ButtonState.Released && is_being_drag) is_being_drag = false;
        }
        else is_being_drag = false;

        return is_being_drag;
    }

    private void _mouse_events(ref MouseState mouseState)
    {
        if (_resize(ref mouseState))
        {
            if (_is_corner_top_left_colliding)
            {
                Console.WriteLine("resizing from top left corner");
            }
            else if (_is_corner_top_right_colliding)
            {
                Console.WriteLine("resizing from top right corner");
            }
            else if (_is_corner_bot_left_colliding)
            {
                Console.WriteLine("resizing from bot left corner");
            }
            else if (_is_corner_bot_right_colliding)
            {
                Console.WriteLine("resizing from top left corner");
            }
        }

        if (_drag(ref mouseState))
        {
            position.X = mouseX - mouseX_to_rectX_distance;
            position.Y = mouseY - mouseY_to_rectY_distance;
        }
    }
}