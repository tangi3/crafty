#pragma once
#include "../../OGAME/base/Component.cpp"
#include <SFML/Graphics.hpp>
using namespace sf;

namespace Ogame
{
	class RenderView : public Component
	{
		public: Sprite sprite;
		public: RenderTexture texture;

		public: RenderView() : Component("view") {}

		public: RenderView(string id) : Component(id) {}
	};
}