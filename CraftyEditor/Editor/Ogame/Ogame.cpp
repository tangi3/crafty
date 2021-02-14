#include <iostream>
#include <GLFW/glfw3.h>
using namespace std;

class Ogame
{
	private: string title;
	private: int width, height;

	private: GLFWwindow* window;

	public: Ogame(string screen_title, int screen_width, int screen_height)
	{
		title = screen_title;

		width = screen_width;
		height = screen_height;
	}

	public: void Run()
	{
		Initialize();

		while (!glfwWindowShouldClose(window))
		{
			Update();
			Render();
		}

		Exit();
	}

	private: int Initialize()
	{
		if (!glfwInit())
		{
			cout << "OpenGL couldn't initialize\n" << endl;
			return -1;
		}

		glfwWindowHint(GLFW_CLIENT_API, GLFW_NO_API);
		glfwWindowHint(GLFW_RESIZABLE, GLFW_FALSE);

		window = glfwCreateWindow(width, height, title.c_str(), NULL, NULL);
		
		if (!window)
		{
			cout << "OpenGL couldn't create a window\n" << endl;

			glfwTerminate();
			return -1;
		}

		Init();
	}

	public: void Init()
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

	private: void Render()
	{
		glClear(GL_COLOR_BUFFER_BIT);

		glfwSwapBuffers(window);

		glfwPollEvents();

		Draw();
	}

	private: int Exit()
	{
		cout << "OpenGL closed safely" << endl;

		glfwTerminate();

		return 0;
	}
};