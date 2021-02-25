#pragma once
#include "OGAME/Renderer.cpp"
#include <iostream>

class Game : public Renderer
{
	public: Map map;
	public: Camera camera;

	public: Game() : Renderer() {}

	public: void Initialize()
	{
		Renderer::Initialize();

		map.loadTileset("test", map.tile_size);
		camera = Camera(map, width, height, map.tile_size);
	}

	public: void Update()
	{
		Renderer::Update(camera, map);

		//...
	}

	public: void Draw()
	{
		Renderer::Draw();

		draw(map);
	}

	public: void run()
	{
		Renderer::Run(camera, map);

		//...
	}
};