#pragma once
#include "C:\Users\tangi\Desktop\crafty\CraftyEditor\OGAME\systems\GraphicHandler.cpp"

class Game : public GraphicHandler
{
	public: Game(string title, int width, int height) : GraphicHandler(title, width, height) { }

	public: void Initialize()
	{
		GraphicHandler::Initialize();

		fill(Color(173, 168, 153));

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

		//...
	}
};