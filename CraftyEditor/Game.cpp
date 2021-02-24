#pragma once
#include "OGAME/GUI.cpp"
#include <iostream>
#include "OGAME/entities/Entity2D.cpp"

class Game : public GUI
{
	public: Entity2D test;

	public: Game() : GUI() {}

	public: void Initialize()
	{
		GUI::Initialize();

		test = Entity2D();
		test.loadFromFile("tilesets/test", 32, 32);

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

		blit(test, 0, 32, 32);
		blit(test, 0, 64, 32);
		blit(test, 0, 96, 32);
		blit(test, 0, 128, 32);
		blit(test, 0, 160, 32);
	}
};