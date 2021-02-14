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

	public: int R() { return r; }

	public: int G() { return g; }

	public: int B() { return b; }

	public: int A() { return a; }

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