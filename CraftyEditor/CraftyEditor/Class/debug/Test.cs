using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Test : Node2D
{
    public Test() : base()
    {
        //...
    }


    public void debug() { print("Hello world !"); }
}

/* how to use Node2D
test.Add(new Node2D());
test.Add(new Test());
test.Add(new Test());
test.Add(new Test());

test.broadcast("test");
Console.WriteLine(test.Get<Node2D>(0).data[0]);
 */
