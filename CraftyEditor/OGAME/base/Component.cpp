#pragma once
#include <string>
using namespace std;

class Component
{
	public: string key;

	public: Component() { }

	public: Component(string id) { key = id; }

	public: virtual ~Component() { }
};