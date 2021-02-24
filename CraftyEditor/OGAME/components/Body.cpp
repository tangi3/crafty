#pragma once
#include "../../OGAME/base/Component.cpp"

class Body : public Component
{
	friend class Component;

	public: float x, y;
	public: float previous_x, previous_y;

	public: int width, height;
	public: int previous_width, previous_height;

	public: int texture_width, texture_height;
	public: int unit_width, unit_height, previous_frame, frame;

	public: Body() : Component("body")
	{
		x = 0;
		y = 0;

		previous_x = 0;
		previous_y = 0;

		width = 0;
		height = 0;

		previous_width = 0;
		previous_height = 0;

		texture_width = 0;
		texture_height = 0;

		unit_width = 32;
		unit_height = 32;

		previous_frame = -1;
		frame = -1;
	}
};