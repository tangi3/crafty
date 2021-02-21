#pragma once
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\base\headers.cpp"
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\entities\UI\UIContainer.cpp"

class Clickable : public UIContainer
{
	public: bool inactive, hover, click;

	public: Color inactive_color, hover_color, click_color;

	public: Clickable() : UIContainer()
	{
		fillParent = false;

		inactive_color = Color::Blue;
		hover_color = Color::Green;
		click_color = Color::Cyan;

		move(0, 0);
		resize(150, 50);

		updateState(-1, -1, false);
	}

	public: Clickable(int width, int height) : UIContainer()
	{
		fillParent = false;

		inactive_color = Color::Blue;
		hover_color = Color::Green;
		click_color = Color::Cyan;

		move(0, 0);
		resize(width, height);

		updateState(-1, -1, false);
	}

	public: Clickable(int width, int height, float x, float y) : UIContainer()
	{
		fillParent = false;

		inactive_color = Color::Blue;
		hover_color = Color::Green;
		click_color = Color::Cyan;

		move(x, y);
		resize(width, height);

		updateState(-1, -1, false);
	}

	public: void updateState(float mouseX, float mouseY, bool mouseClick)
	{
		if (mouseX >= position.x && mouseX <= position.x + size.width && mouseY >= position.y && mouseY <= position.y + size.height)
		{
			inactive = false;

			if (mouseClick)
			{
				hover = false;
				click = true;
				fill(click_color);
			}
			else
			{
				hover = true;
				click = false;
				fill(hover_color);
			}
		}
		else
		{
			inactive = true;
			hover = false;
			click = false;
			fill(inactive_color);
		}
	}
};