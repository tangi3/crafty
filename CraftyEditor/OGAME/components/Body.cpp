#pragma once
#include "../../OGAME/base/Component.cpp"
namespace Ogame
{
	struct Size { int i, j; };
	struct Coords { int i, j; };

	class Body : public Component
	{
		public: Size size;
		public: Coords coord;
		public: int z;

		public: Body() : Component("body")
		{
			size.i = 0;
			size.j = 0;

			coord.i = 0;
			coord.j = 0;

			z = 0;
		}
	};
}