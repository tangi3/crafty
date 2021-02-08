using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Test : Node
{
    public Test() : base()
    {
        //...
    }

    public T Get<T>(int key){ return (T)base.childs[key]; }

    public void debug() { print("Hello world !"); }
}
