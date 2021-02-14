#include "../Ogame/Toolbox.cpp"
#include <GLFW/glfw3.h>

class Ogame
{
	private: string title;

	private: int width, height, editorViewX, editorViewY;
	private: float ratio;

	private: Color background;

	private: GLFWwindow* window;

	public: Ogame(string screen_title, int screen_width, int screen_height)
	{
		title = screen_title;

		width = screen_width;
		height = screen_height;

		editorViewX = 0;
		editorViewY = 0;

		background = Color("#db970f");
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

		setParameters();

		window = glfwCreateWindow(width, height, title.c_str(), NULL, NULL);

		setViewport();
		
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

	//function draw() to draw image, part of an image, rectangles...

	public: void Draw()
	{
		//...
	}

	private: void Render()
	{
		Clear();

		glfwPollEvents();

		Draw();

		glfwSwapBuffers(window);
	}

	private: void Clear()
	{
		glClearColor(background.R(), background.G(), background.B(), background.A());
		glClear(GL_COLOR_BUFFER_BIT);
	}

	private: int Exit()
	{
		glfwTerminate();

		return 0;
	}

	private: void setParameters()
	{
		glfwWindowHint(GLFW_RESIZABLE, GLFW_FALSE);
		glDisable(GL_BLEND);
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