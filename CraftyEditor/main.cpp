#pragma once
#include <iostream>
using namespace std;

#pragma once
#include "Game.cpp"

int main()
{
	Game game;
	game.load("CraftyEditor", 1400, 800);
	game.run();
}