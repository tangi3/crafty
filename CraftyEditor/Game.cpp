#pragma once
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\systems\GraphicHandler.cpp"
#include "OGAME/entities/Unit.cpp"

class Game : public GraphicHandler
{
	public: Unit test;

	public: Game(string title, int width, int height) : GraphicHandler(title, width, height) { }

	public: void Initialize()
	{
		GraphicHandler::Initialize();

		test = Unit("test");
		load(test);

		//...
	}

	public: void Update()
	{
		GraphicHandler::Update();

		//...
	}

	public: void Draw()
	{
		GraphicHandler::Draw();

		draw(test, 0);
		//...
	}
};