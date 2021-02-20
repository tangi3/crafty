#pragma once
#include "OGAME/base/headers.cpp"
#include "Game.cpp"

int main()
{
    Game game = Game("CraftyEditor", 1400, 800);
    game.Run();
}