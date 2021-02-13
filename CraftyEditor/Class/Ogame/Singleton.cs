using System;
using System.Collections.Generic;
using System.Text;

namespace CraftyEditor
{
    public abstract class Singleton<T> where T : class, new()
    {
        private static T _instance;

        public static T GetInstance()
        {
            if (_instance == null)
                _instance = new T();
            return _instance;
        }
    }
}
