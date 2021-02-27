#pragma once
#include "../../OGAME/base/Component.cpp"
#include <SFML/Graphics.hpp>
using namespace sf;

namespace Ogame
{
	class SFMLView : public Component
	{
		public: RenderWindow data;
		public: sf::View sfmlview;
		public: Event event;

		public: SFMLView() : Component("view") {}
	};
}