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

		glfwWindowHint(GLFW_RESIZABLE, GLFW_FALSE);

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

	public: void Draw()
	{
		//...
	}

	private: void Render()
	{
		Clear();

		glfwPollEvents();

		Draw();
	}

	private: void Clear()
	{
		print(background);
		glClearColor(background.R(), background.G(), background.B(), background.A());
		glfwSwapBuffers(window);
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