#pragma once
#include "../../OGAME/base/Entity.cpp"
#include "../../OGAME/components/Body.cpp"
#include "../../OGAME/components/Visual.cpp"
#include <iostream>

class Entity2D : public Entity
{
	friend class Entity;

	public: Entity2D() : Entity()
	{
		add(reinterpret_cast<Body::Component*>(new Body()));
		add(reinterpret_cast<Visual::Component*>(new Visual()));
	}

	public: void resize(int w, int h)
	{
		if (w != reinterpret_cast<Body*>(get("body"))->previous_width || h != reinterpret_cast<Body*>(get("body"))->previous_height)
		{
			reinterpret_cast<Body*>(get("body"))->previous_width = w;
			reinterpret_cast<Body*>(get("body"))->previous_height = h;

			reinterpret_cast<Body*>(get("body"))->width = w;
			reinterpret_cast<Body*>(get("body"))->height = h;
			update();
		}
	}

	public: void move(float nx, float ny)
	{
		if (nx != reinterpret_cast<Body*>(get("body"))->previous_x || ny != reinterpret_cast<Body*>(get("body"))->previous_y)
		{
			reinterpret_cast<Body*>(get("body"))->previous_x = nx;
			reinterpret_cast<Body*>(get("body"))->previous_y = ny;

			reinterpret_cast<Body*>(get("body"))->x = nx;
			reinterpret_cast<Body*>(get("body"))->y = ny;
			update();
		}
	}

	public: void move(int f, float nx, float ny)
	{
		reinterpret_cast<Body*>(get("body"))->previous_x = reinterpret_cast<Body*>(get("body"))->x;
		reinterpret_cast<Body*>(get("body"))->previous_y = reinterpret_cast<Body*>(get("body"))->y;

		reinterpret_cast<Body*>(get("body"))->x = nx;
		reinterpret_cast<Body*>(get("body"))->y = ny;

		reinterpret_cast<Visual*>(get("view"))->sprite.setPosition(Vector2f(reinterpret_cast<Body*>(get("body"))->x, reinterpret_cast<Body*>(get("body"))->y));
	
		setFrame(f);
	}

	public: void fill(Color color)
	{
		reinterpret_cast<Visual*>(get("view"))->color = color;
		reinterpret_cast<Visual*>(get("view"))->rectangle.setFillColor(reinterpret_cast<Visual*>(get("view"))->color);
	}

	public: void fill(int r, int g, int b, int a)
	{
		reinterpret_cast<Visual*>(get("view"))->color = Color(r, g, b, a);
		reinterpret_cast<Visual*>(get("view"))->rectangle.setFillColor(reinterpret_cast<Visual*>(get("view"))->color);
	}

	public: void fill(string hexa)
	{
		reinterpret_cast<Visual*>(get("view"))->a = 255;
		hexa.substr(1);
		hexa.replace(0, 1, "");
		sscanf_s(hexa.c_str(), "%02x%02x%02x", &reinterpret_cast<Visual*>(get("view"))->r, &reinterpret_cast<Visual*>(get("view"))->g, &reinterpret_cast<Visual*>(get("view"))->b);
		reinterpret_cast<Visual*>(get("view"))->color = Color(reinterpret_cast<Visual*>(get("view"))->r, reinterpret_cast<Visual*>(get("view"))->g, reinterpret_cast<Visual*>(get("view"))->b, reinterpret_cast<Visual*>(get("view"))->a);
		reinterpret_cast<Visual*>(get("view"))->rectangle.setFillColor(reinterpret_cast<Visual*>(get("view"))->color);
	}

	public: void loadFromFile(string path, int uw = -1, int uh = -1)
	{
		reinterpret_cast<Visual*>(get("view"))->texture.loadFromFile("C:/Users/tangi/Desktop/crafty/CraftyEditor/OGAME/assets/" + path + ".png");
		reinterpret_cast<Visual*>(get("view"))->sprite.setTexture(reinterpret_cast<Visual*>(get("view"))->texture);
		update(uw, uh, true);
	}

	public: void setFrame(int f)
	{
		reinterpret_cast<Body*>(get("body"))->previous_frame = reinterpret_cast<Body*>(get("body"))->frame;
		reinterpret_cast<Body*>(get("body"))->frame = f;
		reinterpret_cast<Visual*>(get("view"))->sprite.setTextureRect(reinterpret_cast<Visual*>(get("view"))->frames[reinterpret_cast<Body*>(get("body"))->frame]);
	}

	private: void update(int uw = -1, int uh = -1, bool loading = false)
	{
		reinterpret_cast<Visual*>(get("view"))->rectangle.setPosition(Vector2f(reinterpret_cast<Body*>(get("body"))->x, reinterpret_cast<Body*>(get("body"))->y));
		reinterpret_cast<Visual*>(get("view"))->sprite.setPosition(Vector2f(reinterpret_cast<Body*>(get("body"))->x, reinterpret_cast<Body*>(get("body"))->y));
	
		reinterpret_cast<Visual*>(get("view"))->rectangle.setSize(Vector2f(reinterpret_cast<Body*>(get("body"))->width, reinterpret_cast<Body*>(get("body"))->height));

		reinterpret_cast<Body*>(get("body"))->texture_width = reinterpret_cast<Visual*>(get("view"))->texture.getSize().x;
		reinterpret_cast<Body*>(get("body"))->texture_height = reinterpret_cast<Visual*>(get("view"))->texture.getSize().y;

		if (loading)
		{
			reinterpret_cast<Body*>(get("body"))->width = reinterpret_cast<Body*>(get("body"))->texture_width;
			reinterpret_cast<Body*>(get("body"))->height = reinterpret_cast<Body*>(get("body"))->texture_height;

			reinterpret_cast<Visual*>(get("view"))->rectangle.setSize(Vector2f(reinterpret_cast<Body*>(get("body"))->width, reinterpret_cast<Body*>(get("body"))->height));
		}

		if (uw != 1 && uh != -1 || reinterpret_cast<Visual*>(get("view"))->frames.size() > 0)
		{
			reinterpret_cast<Body*>(get("body"))->unit_width = uw;
			reinterpret_cast<Body*>(get("body"))->unit_height = uh;
			
			for (int j = 0; j < (reinterpret_cast<Body*>(get("body"))->texture_height / uh); j++)
			{ for (int i = 0; i < (reinterpret_cast<Body*>(get("body"))->texture_width / uw); i++)
					{ reinterpret_cast<Visual*>(get("view"))->frames.push_back(IntRect(i * uw, j * uh, uw, uh)); } }
		}
	}

	public: Sprite& sprite() { return reinterpret_cast<Visual*>(get("view"))->sprite; }

	public: RectangleShape& rectangle() { return reinterpret_cast<Visual*>(get("view"))->rectangle; }
};