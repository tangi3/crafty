#pragma once
#include "headers.cpp"

class Component
{
	public: string key;

	public: Component() { key = ""; }

	public: Component(string id) { key = id; }
};