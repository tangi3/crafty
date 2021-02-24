#pragma once
#include "OGAME/Renderer.cpp"
#include <iostream>
#include "OGAME/entities/Map.cpp"

class Game : public Renderer
{
	public: Map map;

	public: Game() : Renderer() {}

	public: void Initialize()
	{
		Renderer::Initialize();

		map = Map();
		map.loadTileset("test", 32);
		map.loadChunkFrom(0, 0);
	}

	public: void Update()
	{
		Renderer::Update();

		update(map);
	}

	public: void Draw()
	{
		Renderer::Draw();

		draw(map);
	}
};