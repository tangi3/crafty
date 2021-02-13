using System;
using OpenTK;

namespace CraftyEditor
{
    public class Ogame : Singleton<Ogame>
    {
        public bool initialize, running;

        public Ogame() : base()
        {
            initialize = true;
            running = true;
        }

        public void Run()
        {
            while(running)
            {
                if (initialize)
                {
                    Initialize();
                    initialize = false;
                }
                Clear();
                Update();
                Draw();
            }
        }

        public void Close() { running = false; }

        public virtual void Initialize()
        {
            //...
        }

        public virtual void Clear()
        {
            //...
        }

        public virtual void Update()
        {
            //...
        }

        public virtual void Draw()
        {
            //...
        }
    }
}
