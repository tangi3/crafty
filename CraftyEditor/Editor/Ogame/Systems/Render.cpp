#pragma once
#include "../ECS/System.cpp"
#include "../Drawable/Rectangle.cpp"

class Render : public System
{
	public: int screen_width, screen_height;

	public: Render() : System() {}

	public: Render(int screenWidth, int screenHeight) : System()
	{
		screen_width = screenWidth;
		screen_height = screenHeight;
	}

	public: void run() { System::run(); }

	public: void draw(Rectangle& rect)
	{
		projection_setup();

		glClearColor(rect.color.R(), rect.color.G(), rect.color.B(), rect.color.A());
		glBegin(GL_QUADS);

		glVertex2f(1.0f, 1.0f);
		glVertex2f(2.0f, 1.0f);
		glVertex2f(2.0f, 2.0f);
		glVertex2f(1.0f, 2.0f);

		glEnd();
	}

	private: void projection_setup()
	{
		glMatrixMode(GL_PROJECTION);
		glLoadIdentity();
		glOrtho(0.0, screen_width, 0.0, screen_height, -1.0, 1.0);
		glMatrixMode(GL_MODELVIEW);
		glLoadIdentity();
		glViewport(0, 0, screen_width, screen_height);
	}
};