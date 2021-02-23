#pragma once
#include "OGAME/entities/GUI.cpp"
#include <iostream>

class Game : public GUI
{
	public: Entity2D test;

	public: Game() : GUI() {}

	public: void Initilize()
	{
		GUI::Initialize();

		test = Entity2D();

		test.move(20, 100);
		test.resize(32, 32);
		test.fill("#692e2e");

		cout << "test" << endl;

		//...
	}

	public: void Update()
	{
		GUI::Update();

		//...
	}

	public: void Draw()
	{
		GUI::Draw();

		draw(test.sprite());
		//...
	}
};