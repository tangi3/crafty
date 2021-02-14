#include <sstream>
using namespace std;

class Color
{
	private: stringstream rgbconverter;

	private: int r, g, b, a;
	private: int buffer[4] = {};

	public: Color()
	{
		r = 0;
		g = 0;
		b = 0;
		a = 1;
	}

	friend ostream& operator<<(ostream& Str, Color const& color)
	{
		Str << to_string(color.r);
		Str << ", ";
		Str << to_string(color.g);
		Str << ", ";
		Str << to_string(color.b);
		Str << ", ";
		Str << to_string(color.a);
		return Str;
	}

	public: Color(string hexa) { convert(hexa); }

	public: float R() { return (1.0f / 255) * r; }

	public: float G() { return (1.0f / 255) * g; }

	public: float B() { return (1.0f / 255) * b; }

	public: float A() { return (1.0f / 255) * a; }

	public: int* get()
	{
		buffer[0] = r;
		buffer[1] = g;
		buffer[2] = b;
		buffer[3] = a;

		return buffer;
	}

	public: void set(string hexa) { convert(hexa); }

	private: void convert(string hexa)
	{
		a = 1;
		hexa.substr(1);
		hexa.replace(0, 1, "");
		sscanf_s(hexa.c_str(), "%02x%02x%02x", &r, &g, &b);
	}
};