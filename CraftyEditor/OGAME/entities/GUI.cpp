#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\base\headers.cpp"
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\entities\Entity2D.cpp"

class GUI : public Entity2D
{
	public:  RenderWindow data;

	public: GUI() : Entity2D("Window") {}

	public: void set(string title, int w, int h)
	{
		data.create(VideoMode(w, h), title);

		key = title;
		size.width = w;
		size.height = h;

		auto desktop = sf::VideoMode::getDesktopMode();
		data.setPosition(Vector2i(desktop.width / 2 - data.getSize().x / 2, desktop.height / 2 - data.getSize().y / 2));
	}
};