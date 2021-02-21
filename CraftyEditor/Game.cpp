#pragma once
#include "OGAME/systems/GraphicHandler.cpp"

class Game : public GraphicHandler
{
	public: Game() : GraphicHandler() { init("Crafty Editor", 1400, 800); }

	public: void Load()
	{
		GraphicHandler::Load();

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