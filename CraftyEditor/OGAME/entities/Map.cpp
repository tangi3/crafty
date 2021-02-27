#pragma once
#include "Entity2D.cpp"
#include "SFMLWindow.cpp"
#include "../components/RenderView.cpp"
#include <iostream>

using namespace Ogame;

namespace Ogame
{
	class Map : public Entity2D
	{
		friend class Entity2D;

		private: int tile_size, screen_width, screen_height;
		private: int nbTiles, nbRows, nbChunkPerRow, nbTilesPerRow, nbRowPerChunk, chunkOffset;

		public: Map() : Entity2D()
		{
			add(reinterpret_cast<RenderView::Component*>(new RenderView("grid")));
		}

		public: void load(string name, int tileSize, int screenWidth, int screenHeight)
		{
			loadFromFile("tileset", name);
			loadTiles(tileSize);

			tile_size = tileSize;
			screen_width = screenWidth;
			screen_height = screenHeight;

			//.......................... WIP ..............................................
			/*
			nbRows = 3;
			nbChunkPerRow = 3;
			nbTiles = (screenWidth / tileSize) * (screenHeight / tileSize);
			nbTilesPerRow = (screenWidth / tileSize) / nbChunkPerRow;
			nbRowPerChunk = (screenHeight / tileSize) / nbRows;
			chunkOffset = 2;

			for (int c = 0; c < (nbRows + chunkOffset) * (nbChunkPerRow + chunkOffset); c++)
			{
				add(reinterpret_cast<RenderView::Component*>(new RenderView("ground_chunk_" + c)));

				ground(c)->texture.create(screen_width, screen_height);
				ground(c)->texture.clear();

				for (int j = 0; j < nbRowPerChunk; j++)
				{
					for (int i = 0; i < nbTilesPerRow; j++)
					{
						move((c * nbTilesPerRow) + i, (c * nbRowPerChunk) + j);
						setFrame(0);
						update(tile_size);
						ground(c)->texture.draw(view()->sprite);
					}
				}

				ground(c)->texture.display();
				ground(c)->sprite.setTexture(ground(c)->texture.getTexture());
			}
			*/
			//..............................................................................................

			Grid()->texture.create(screen_width, screen_height);
			Grid()->texture.clear();

			for (int j = 0; j < screen_height / tile_size; j++)
			{ for (int i = 0; i < screen_width / tile_size; i++) {
				move(i, j);
				setFrame(1);
				update(tile_size);
				Grid()->texture.draw(view()->sprite);}}

			Grid()->texture.display();
			Grid()->sprite.setTexture(Grid()->texture.getTexture());
		}

		public: Sprite& grid() { return Grid()->sprite; }

		public: void blit(RenderWindow& window, int f, int i, int j)
		{
			move(i, j);
			setFrame(f);
			window.draw(view()->sprite);
		}

		private: RenderView* Grid() { return reinterpret_cast<RenderView*>(get("grid")); }

		private: RenderView* ground(int c) { return reinterpret_cast<RenderView*>(get("ground_chunk_" + c)); }
	};
}