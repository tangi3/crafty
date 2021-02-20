#include <SFML/Graphics.hpp>
using namespace sf;
using namespace std;

int main()
{
    RenderWindow window(VideoMode(200, 200), "SFML works!");
    auto desktop = sf::VideoMode::getDesktopMode();
    window.setPosition(Vector2i(desktop.width / 2 - window.getSize().x / 2, desktop.height / 2 - window.getSize().y / 2));

    CircleShape shape(100.f);
    shape.setFillColor(Color::Green);

    while (window.isOpen())
    {
        Event event;
        while (window.pollEvent(event))
        {
            if (event.type == Event::Closed)
                window.close();
        }

        window.clear();
        window.draw(shape);
        window.display();
    }

    return 0;
}