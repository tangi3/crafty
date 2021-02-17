#pragma once
#include "../ECS/Headers.cpp"

class Component
{
	public: string key;

	public: Component()
	{
		//...
	}

	public: virtual void update(){}
};