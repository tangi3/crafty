using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Node2D : Node
{
    public Node2D() : base()
    {
        //...
    }

    public T Get<T>(int key){ return (T)base.childs[key]; }
    
    public void broadcast(string msg)
    {
        for (int key = 0; key < childs.Length; key++)
        {
            Node2D tmp = (Node2D)childs[key];
            tmp.callback_send(msg);
        }
    }
}
