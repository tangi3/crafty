#include <GLFW/glfw3.h>
#include <iostream>
using namespace std;

class Ogame
{
	private: bool init;

	private: string title;
	private: int width, height;

	private: GLFWwindow* window;

	public: Ogame(string screen_title, int screen_width, int screen_height)
	{
		title = screen_title;
		width = screen_width;
		height = screen_height;

		init = false;
	}

	public: void Run()
	{
		while (!glfwWindowShouldClose(window))
		{
			if (init == false)
			{
				if (Initialize() == -1) EXIT_FAILURE;
				init = true;
			}
			Update();
			Render();
		}
		
		Exit();
	}

	public: int Initialize()
	{
		if (!glfwInit()) return -1;

		window = glfwCreateWindow(width, height, title.c_str(), NULL, NULL);
		
		if (!window)
		{
			glfwTerminate();
			return -1;
		}

		glfwMakeContextCurrent(window);

		Load();
	}

	public: void Load()
	{
		//...
	}

	public: void Update()
	{
		//...
	}

	public: void Draw()
	{
		//...
	}

	public: void Render()
	{
		glClear(GL_COLOR_BUFFER_BIT);

		glfwSwapBuffers(window);

		glfwPollEvents();

		Draw();
	}

	public: int Exit()
	{
		glfwTerminate();

		return 0;
	}
};