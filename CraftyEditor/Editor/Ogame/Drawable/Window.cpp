#include "../ECS/Headers.cpp"
#pragma once
#include "../Drawable/Drawable.cpp"
#include "Color.cpp"

class Window : public Drawable
{
	public: GLFWwindow* window;
public: Color color;

	public: int fps;
	public: double elapsed_time, delta;
	private: double t;

	public: bool init;

	public: Window(string title, int width, int height) : Drawable()
	{
		init = glfwInit();

		glfwWindowHint(GLFW_RESIZABLE, GLFW_FALSE);
		glDisable(GL_BLEND);
		glDisable(GL_DEPTH_TEST);

		if (init) window = glfwCreateWindow(width, height, title.c_str(), NULL, NULL);

		color = Color("#4d3634");

		glfwMakeContextCurrent(window);

		if (!init) glfwTerminate();
	}

	public: void run()
	{
		while (!glfwWindowShouldClose(window)) { update(); }
	}

	public: void update()
	{
		elapsed_time = glfwGetTime();
		delta = (t - elapsed_time) * -1;
		t = elapsed_time;

		fps = (1000 / delta) / 1000;

		glClearColor(color.R(), color.G(), color.B(), color.A());
		glClear(GL_COLOR_BUFFER_BIT);

		glfwPollEvents();

		running_time();
		
		glfwSwapBuffers(window);

		glFlush();

		Drawable::update();
	}

	public: virtual void running_time() { }
};