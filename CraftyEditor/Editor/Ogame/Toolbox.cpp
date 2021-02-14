#include "../Ogame/Color.cpp"

#include <iostream>
#include <sstream>
#include <string>

using namespace std;

inline void print(string msg) { cout << msg << endl; }

inline void print(int value) { cout << to_string(value) << endl; }

inline void print(double value) { cout << to_string(value) << endl; }

inline void print(float value) { cout << to_string(value) << endl; }

inline void print(Color& color) { cout << color << endl; }