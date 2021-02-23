#include "../../OGAME/base/Component.cpp"

class Position : public Component
{
	friend class Component;

	public: float x, y;

	public: Position() : Component("position")
	{
		x = 0;
		y = 0;
	}

	public: Position(float xInput, float yInput) : Component("position")
	{
		x = xInput;
		y = yInput;
	}
};