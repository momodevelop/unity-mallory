using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Momo
{
    public abstract class Singleton<T> : MonoBehaviour where T : class
    {
        private static readonly Lazy<T> instance = new Lazy<T>(() => CreateInstanceOfT());

        public static T Instance { get { return instance.Value as T; } }

        private static T CreateInstanceOfT()
        {
            return Activator.CreateInstance(typeof(T), true) as T;
        }

    }
}
