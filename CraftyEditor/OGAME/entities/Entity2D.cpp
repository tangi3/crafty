#pragma once
#include "../../OGAME/base/Entity.cpp"
#include "../../OGAME/components/Position.cpp"
#include "../../OGAME/components/Size.cpp"
#include "../../OGAME/components/Visual.cpp"

class Entity2D : public Entity
{
	private: int r, g, b, a;

	public: Entity2D() : Entity() { init_components(); }

	public: Entity2D(string id) : Entity(id) { init_components(); }

	public: Entity2D(string id, float xUser, float yUser) : Entity(id) { init_components(xUser, yUser); }

	public: Entity2D(string id, float xUser, float yUser, int widthUser, int heightUser) : Entity(id) { init_components(xUser, yUser, widthUser, heightUser); }

	private: void init_components(float xUser = 0, float yUser = 0, int widthUser = 0, int heightUser = 0)
	{
		add(reinterpret_cast<Position::Component*>(new Position(xUser, xUser)));
		add(reinterpret_cast<Position::Component*>(new Size(widthUser, heightUser)));
		add(reinterpret_cast<Visual::Component*>(new Visual()));

		move(0, 0);
		resize(50, 50);
		fill("#ffffff");
	}

	public: void move(float xUser, float yUser)
	{
		reinterpret_cast<Position*>(get("position"))->x = xUser;
		reinterpret_cast<Position*>(get("position"))->y = yUser;
		reinterpret_cast<Visual*>(get("view"))->rectangle.setPosition(Vector2f(xUser, yUser));
	}

	public: void resize(int widthUser, int heightUser)
	{
		reinterpret_cast<Size*>(get("size"))->width = widthUser;
		reinterpret_cast<Size*>(get("size"))->height = heightUser;
		reinterpret_cast<Visual*>(get("view"))->rectangle.setSize(Vector2f(widthUser, heightUser));
	}

	public: void fill(string hexa)
	{
		a = 1;
		hexa.substr(1);
		hexa.replace(0, 1, "");
		sscanf_s(hexa.c_str(), "%02x%02x%02x", &r, &g, &b);
		reinterpret_cast<Visual*>(get("view"))->color = Color(r, g, b, a);
		reinterpret_cast<Visual*>(get("view"))->rectangle.setFillColor(reinterpret_cast<Visual*>(get("view"))->color);
	}

	public: void load(string path, int subx = -1, int suby = 0, int subwidth = 1, int subheight = 1)
	{
		reinterpret_cast<Visual*>(get("view"))->texture.loadFromFile("C:\\Users\\tangi\\Desktop\\crafty\\CraftyEditor\\OGAME\\assets\\" + path + ".png");
		reinterpret_cast<Visual*>(get("view"))->sprite.setTexture(reinterpret_cast<Visual*>(get("view"))->texture);
		if (subx != -1) { reinterpret_cast<Visual*>(get("view"))->sprite.setTextureRect(IntRect(subx, suby, subwidth, subheight)); }
	}

	public: Position* position() { return reinterpret_cast<Position*>(get("position")); }

	public: float x() { return reinterpret_cast<Position*>(get("position"))->x; }

	public: float y() { return reinterpret_cast<Position*>(get("position"))->y; }

	public: float x(float xUser) { reinterpret_cast<Position*>(get("position"))->x = xUser;  return reinterpret_cast<Position*>(get("position"))->x; }

	public: float y(float yUser) { reinterpret_cast<Position*>(get("position"))->y = yUser;  return reinterpret_cast<Position*>(get("position"))->y; }


	public: Size* size() { return reinterpret_cast<Size*>(get("size")); }

	public: float width() { return reinterpret_cast<Size*>(get("size"))->width; }

	public: float height() { return reinterpret_cast<Size*>(get("size"))->height; }

	public: float width(int widthUser) { reinterpret_cast<Size*>(get("size"))->width = widthUser;  return reinterpret_cast<Size*>(get("size"))->width; }

	public: float height(int heightUser) { reinterpret_cast<Size*>(get("size"))->height = heightUser;  return reinterpret_cast<Size*>(get("size"))->height; }


	public: Sprite& sprite() { return reinterpret_cast<Visual*>(get("view"))->sprite; }

	public: RectangleShape& rect() { return reinterpret_cast<Visual*>(get("view"))->rectangle; }

	public: Color& color() { return reinterpret_cast<Visual*>(get("view"))->color; }
};