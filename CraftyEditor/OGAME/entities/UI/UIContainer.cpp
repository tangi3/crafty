#pragma once
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\base\headers.cpp"
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\entities\Unit.cpp"

class UIContainer : public Unit
{
	public: bool fillParent, fillVertical, fillHorizontal;

	public: UIContainer() : Unit()
	{
		fillParent = true; 

		fillHorizontal = true;
		fillVertical = true;
	}

	public: UIContainer(int parent_width, int parent_height, float parent_x, float parent_y, float xOffset, float yOffset, int widthOffset, int heightOffset) : Unit()
	{
		update(parent_width, parent_height, parent_x, parent_y, xOffset, yOffset, widthOffset, heightOffset);
	}

	public: void update(int parent_width, int parent_height, float parent_x, float parent_y, float xOffset, float yOffset, int widthOffset, int heightOffset)
	{
		if (fillParent)
		{
			move(parent_x + xOffset, parent_y + yOffset);

			if (fillHorizontal) resize(parent_width - widthOffset, size.height);
			if (fillVertical) resize(size.width, parent_height - heightOffset);
		}
	}
};