#pragma once
#include <string>
#include <map>
using namespace std;

#pragma once
#include "Component.cpp"

class Entity : Component
{
	private: map<string, Component*> components;

	public: Entity() : Component() { components = map<string, Component*>(); }

	public: Entity(string id) : Component(id) { components = map<string, Component*>(); }

	private: virtual void init_components() { }

	public: void add(Component* component) { components.insert(pair<string, Component*>(component->key, component)); }

	public: Component* get(string id) { return components[id]; }
};