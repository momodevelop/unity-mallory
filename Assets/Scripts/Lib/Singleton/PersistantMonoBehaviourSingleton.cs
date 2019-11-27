using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Momo
{
    public class PersistantMonoBehaviourSingleton<T> : MonoBehaviour where T : Component
    {
        public static T I { get; private set; }

        // Virtual void this in case we need to override
        public virtual void Awake()
        {
            if (I == null)
            {
                I = this as T; // cast upwards to T :)
                if (I == null)
                {
                    Debug.LogError("MonoBehaviour creation error: T is not this");
                }
                //DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }


    }
}
