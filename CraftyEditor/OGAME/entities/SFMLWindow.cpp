#pragma once
#include "../../OGAME/base/Entity.cpp"
#include "../../OGAME/components/SFMLView.cpp"
#include "../../OGAME/components/Mouse.cpp"

using namespace Ogame;

namespace Ogame
{
	class SFMLWindow : public Entity
	{
		public: int width, height, tile_size;
		public: bool initiliazed;

		public: int cursor_state;

		public: SFMLWindow() : Entity()
		{
			add(reinterpret_cast<SFMLView::Component*>(new SFMLView()));
			add(reinterpret_cast<Ogame::Mouse::Component*>(new Mouse()));

			cursor_state = 0;
		}

		public: void load(string caption, int w, int h, int tileSize)
		{
			view()->data.create(VideoMode(w, h), caption, Style::Titlebar | Style::Close);

			auto desktop = sf::VideoMode::getDesktopMode();
			view()->data.setPosition(Vector2i(desktop.width / 2 - view()->data.getSize().x / 2, desktop.height / 2 - view()->data.getSize().y / 2));

			view()->sfmlview = sf::View(FloatRect(0, 0, w, h));
			view()->data.setView(view()->sfmlview);

			width = w;
			height = h;

			tile_size = tileSize;
		}

		public: virtual void Update()
		{
			view()->event = Event();

			while (view()->data.pollEvent(view()->event))
			{
				mouse()->update(view()->data, tile_size);

				if (view()->event.type == Event::Closed) view()->data.close();

				if (view()->event.type == Event::KeyPressed)
				{
					switch (view()->event.key.code)
					{
						//...
					}
				}

				if (view()->event.type == Event::MouseButtonPressed)
				{
					if (view()->event.mouseButton.button == sf::Mouse::Left)
					{
						cursor_state = 1;
						mouse()->leftClick = true;
					}
					else if (view()->event.mouseButton.button == sf::Mouse::Right)
					{
						cursor_state = 2;
						mouse()->rightClick = true;
					}

					mouse()->click = true;
				}
				else if (view()->event.type == Event::MouseButtonReleased)
				{
					cursor_state = 0;
					mouse()->click = false;
					mouse()->leftClick = false;
					mouse()->rightClick = false;
				}
			}
		}

		public: virtual void Initialize() { }

		public: virtual void Draw() { }

		public: void Run()
		{
			while (view()->data.isOpen())
			{
				if (!initiliazed) Initialize();
				initiliazed = true;

				Update();

				view()->data.clear(Color::Black);

				Draw();

				view()->data.display();
			}
		}

		public: Ogame::Mouse* mouse() { return reinterpret_cast<Ogame::Mouse*>(get("mouse")); }

		private: SFMLView* view() { return reinterpret_cast<SFMLView*>(get("view")); }

		public: RenderWindow& window() { return view()->data; }
	};
}