#include "../ECS/Component.cpp"

class Position : Component
{
	public: float x, y, z, parent_x, parent_y, parent_z, offsetX, offsetY;

	public: Position() : Component()
	{
		key = "position";

		x = 0;
		y = 0;
		z = 0;

		parent_x = 0;
		parent_y = 0;
		parent_z = 0;

		offsetX = 0;
		offsetY = 0;
	}
};