#pragma once
#include <string>
using namespace std;

namespace Ogame
{
	class Component
	{
		public: string key;

		public: Component() { }

		public: Component(string id) { key = id; }

		public: virtual ~Component() { }
	};
}