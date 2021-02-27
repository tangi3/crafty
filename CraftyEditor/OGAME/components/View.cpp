#pragma once
#include "../../OGAME/base/Component.cpp"
#include <SFML/Graphics.hpp>
using namespace sf;

namespace Ogame
{
	class View : public Component
	{
		public: Sprite sprite;
		public: Texture texture;

		public: View() : Component("view") {}
	};
}