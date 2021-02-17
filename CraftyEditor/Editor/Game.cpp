#pragma once
#include "Ogame/Ogame.cpp"

class Game : public Ogame
{
	private: Rectangle test;

	public: Game(string title, int width, int height): Ogame(title, width, height) { }

	public: void Load()
	{
		test = Rectangle(200, 200, 100, 120, "#3486eb");

		//...
	}

	public: void Update()
	{
		//....
	}

	public: void Draw()
	{
		render.draw(test);
	}
};