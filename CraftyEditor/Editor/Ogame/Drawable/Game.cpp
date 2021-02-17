#pragma once
#include "../Ogame.cpp"

class Game : public Ogame
{
public: Game(string title, int width, int height) : Ogame(title, width, height) {}

	public: void load()
	{
		//...
	}

	public: void running_time()
	{
		Window::running_time();

		//...
	}

	public: void Update()
	{
		cout << "test" << endl;
	}

	public: void Draw()
	{
		//...
	}
};