using System;
using System.Collections.Generic;

public class Node
{
    public int Count = 0;
    public Object[] childs;
    private Object[] buffer;

    public Node()
    {
        childs = new Object[] { };
    }

    public Object get(int key) { return childs[key]; }

    public void set(int key, Object child) { childs[key] = child; }

    public void Add(Object child)
    {
        buffer = childs;
        childs = new Object[buffer.Length + 1];

        for (int i = 0; i < buffer.Length; i++) { childs[i] = buffer[i]; }
        childs[buffer.Length] = child;

        Count = childs.Length;
    }

    public void print(string msg) { Console.WriteLine(msg); }
}
