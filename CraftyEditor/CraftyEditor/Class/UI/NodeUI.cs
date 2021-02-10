using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

public class NodeUI : UI
{
    private int cornerless_unit_width, cornerless_unit_height;

    public NodeUI(ref GraphicsDeviceManager graphics, ContentManager content, string theme) : base(ref graphics)
    {
        unit = 16;

        load(ref graphics, content, "theme_" + theme, 48, 64);
    }

    public new void update(ref GraphicsDeviceManager graphics, ref MouseState mouseState, int reduce_offset, UI parent = null)
    {
        cornerless_unit_width = (int)(real_size.X - (unit * 2)) / unit;
        cornerless_unit_height = (int)(real_size.Y - (unit * 2)) / unit;

        base.update(ref graphics, ref mouseState, reduce_offset, parent);
    }

    public void render(ref SpriteBatch spriteBatch)
    {
        if(full)
        {
            if(border)
            {
                blit(ref spriteBatch, 0, x, y);

                for (int i = 0; i < cornerless_unit_width; i++)
                {
                    blit(ref spriteBatch, 1, x + ((i + 1) * unit), y);
                }

                blit(ref spriteBatch, 2, x + (cornerless_unit_width + 1) * unit, y);

                for (int o = 0; o < cornerless_unit_height; o++)
                {
                    blit(ref spriteBatch, 3, x, y + ((o + 1) * unit));

                    for (int i = 0; i < cornerless_unit_width; i++)
                    {
                        blit(ref spriteBatch, 4, x + ((i + 1) * unit), y + ((o + 1) * unit));
                    }

                    blit(ref spriteBatch, 5, x + (int)real_size.X - unit, y + ((o + 1) * unit));
                }

                blit(ref spriteBatch, 5, x + (cornerless_unit_width + 1) * unit, y + unit);

                blit(ref spriteBatch, 6, x, y + (int)real_size.Y - unit);

                for (int i = 0; i < cornerless_unit_width; i++)
                {
                    blit(ref spriteBatch, 7, x + ((i + 1) * unit), y + (int)real_size.Y - unit);
                }

                blit(ref spriteBatch, 8, x + (cornerless_unit_width + 1) * unit, y + (int)real_size.Y - unit);
            }
            else
            {
                for (int o = 0; o < real_size.Y / unit; o++)
                {
                    blit(ref spriteBatch, 4, x, y + (o * unit));

                    for (int i = 0; i < real_size.X / unit; i++)
                    {
                        blit(ref spriteBatch, 4, x + (i * unit), y + (o * unit));
                    }

                    blit(ref spriteBatch, 4, x + (int)real_size.X - unit, y + (o * unit));
                }
            }
        }
        else
        {
            if(border)
            {
                for (int i = 0; i < real_size.X / unit; i++)
                {
                    blit(ref spriteBatch, 9, x + (i * unit), y);
                    blit(ref spriteBatch, 9, x + (i * unit), y + unit);
                }
            }
            else
            {
                for (int i = 0; i < real_size.X / unit; i++)
                {
                    blit(ref spriteBatch, 4, x + (i * unit), y);
                    blit(ref spriteBatch, 4, x + (i * unit), y + unit);
                }
            }
        }
    }
}