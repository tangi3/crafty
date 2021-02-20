#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\base\headers.cpp"
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\entities\Entity2D.cpp"

class GUI : public Entity2D
{
	public:  RenderWindow* data;

	public: GUI() : Entity2D("Window") {}

	public: GUI(string title, int w, int h) : Entity2D()
	{
		key = title;
		size.width = w;
		size.height = h;

		data = new RenderWindow(VideoMode(w, h), title);
		auto desktop = sf::VideoMode::getDesktopMode();
		data->setPosition(Vector2i(desktop.width / 2 - data->getSize().x / 2, desktop.height / 2 - data->getSize().y / 2));
	}
};