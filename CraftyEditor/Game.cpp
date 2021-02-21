#pragma once
#include "OGAME/Ogame.cpp"

class Game : public Ogame
{
	public: Game() : Ogame() {}

	public: void Load()
	{
		Ogame::Load();

		//...
	}

	public: void Update()
	{
		Ogame::Update();

		//...
	}

	public: void Draw()
	{
		Ogame::Draw();

		//...
	}
};