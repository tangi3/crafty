using System;
using System.Collections.Generic;

public class StateMachine : Node
{
    public int state;

    public bool initialized = false;
    public bool loop = true;

    public const int inactive = 0;
    public const int active = 1;
    public const int exited = 3;
    public const int paused = 2;

    public StateMachine() : base() { state = inactive;  }

    public void Next()
    {
        if (state == inactive && initialized == false | loop)
        {
            state = active;
            initialized = true;
        }
        else if (state == active) state = exited;
        else if (state == exited) state = inactive;
    }

    public void Previous()
    {
        if (state == active) state = inactive;
        else if (state == exited) state = active;
    }

    public void Pause() { state = paused; }

    public void debug()
    {
        switch(state)
        {
            case inactive: Console.WriteLine("> inactive"); break;
            case active: Console.WriteLine("> active"); break;
            case exited: Console.WriteLine("> exited"); break;
            case paused: Console.WriteLine("> paused"); break;
        }
    }
}