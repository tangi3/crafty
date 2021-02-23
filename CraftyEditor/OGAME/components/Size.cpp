#include "../../OGAME/base/Component.cpp"

class Size : public Component
{
public: int width, height;

	public: Size() : Component("size")
	{
		width = 1;
		height = 1;
	}

	public: Size(int widthInput, int heightInput) : Component("size")
	{
		width = widthInput;
		height = heightInput;
	}
};