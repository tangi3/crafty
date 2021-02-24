#pragma once
#include <string>
#include <map>
using namespace std;

#pragma once
#include "Component.cpp"

class Entity
{
	private: map<string, Component*> components;

	public: Entity() { components = map<string, Component*>(); }

	public: void add(Component* component) { components.insert(pair<string, Component*>(component->key, component)); }

	public: Component* get(string id) { return components[id]; }
};