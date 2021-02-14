#include <iostream>
#include <GLFW/glfw3.h>
using namespace std;

class Ogame
{
	private: string title;

	private: int width, height, editorViewX, editorViewY;
	private: float ratio;

	private: GLFWwindow* window;

	public: Ogame(string screen_title, int screen_width, int screen_height)
	{
		title = screen_title;

		width = screen_width;
		height = screen_height;

		editorViewX = 0;
		editorViewY = 0;
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
		if (!glfwInit()) return -1;

		//glfwWindowHint(GLFW_CLIENT_API, GLFW_NO_API);
		//glfwWindowHint(GLFW_RESIZABLE, GLFW_FALSE);

		window = glfwCreateWindow(width, height, title.c_str(), NULL, NULL);
		//setViewport();
		
		if (!window)
		{
			glfwTerminate();
			return -1;
		}

		glfwMakeContextCurrent(window);

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
		Clear();

		glfwSwapBuffers(window);

		glfwPollEvents();

		Draw();
	}

	private: void Clear(int r = -1, int g = 0, int b = 0, int alpha = 255)
	{
		if(r > -1) glClearColor(r, g, b, alpha);
		else glClear(GL_COLOR_BUFFER_BIT);
	}

	private: int Exit()
	{
		glfwTerminate();

		return 0;
	}

	private: void setViewport()
	{
		glfwGetFramebufferSize(window, &width, &height);
		ratio = width / (float)height;
		glViewport(editorViewX, editorViewY, width, height);
	}

	private: void debug()
	{
		//...
	}
};