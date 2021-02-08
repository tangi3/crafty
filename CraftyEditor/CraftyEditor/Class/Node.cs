using System;
using System.Collections.Generic;

public class Node
{
    public int Count = 0;
    public Object[] childs;
    private Object[] buffer;

    public Dictionary<int, string> data;

    public delegate void sendDelegate(string msg);
    public sendDelegate callback_send;
    public delegate void afterReceiveDelegate();
    public afterReceiveDelegate callback_receive;

    public Node()
    {
        childs = new Object[] { };

        data = new Dictionary<int, string>();

        callback_send = new sendDelegate(_send);
        callback_receive = new afterReceiveDelegate(_receive);
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

    public void _send(string msg)
    {
        data.Add(data.Count, msg);
        callback_receive();
    }
    public virtual void _receive()
    {
        //...
    }

    public void print(string msg) { Console.WriteLine(msg); }
}
