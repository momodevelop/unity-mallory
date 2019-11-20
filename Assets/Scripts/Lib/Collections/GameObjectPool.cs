using System.Collections.Generic;
using UnityEngine;

namespace Momo
{
    class Simpool
    {
        public class Simpoolable : MonoBehaviour
        {
            internal Simpool parent = null;
            internal int index = -1;
            public void Return()
            {
                parent.Despawn(gameObject);
            }
        }

        
        private GameObject _prefab = null;
        // TODO: For pools that are growable.
        // [SerializeField] private bool _growable;

        Stack<int> _freeIndices;
        List<GameObject> _pool;

        // Some properties to display
        public int TotalGameObjects { get => _pool.Count; }
        public int FreeGameObjects { get => _freeIndices.Count; }

        public Simpool(GameObject prefab, int capacity)
        {
            _prefab = prefab;
            _pool = new List<GameObject>();
            _freeIndices = new Stack<int>();
            for (int i = 0; i < capacity; ++i)
            {
                GameObject obj = (GameObject)Object.Instantiate(_prefab);
                obj.SetActive(false);

                // Add our poolable script that gives helper functions
                // and help us identify if the game object belongs to us.
                Simpoolable poolable = obj.AddComponent<Simpoolable>();
                poolable.index = i;
                poolable.parent = this;

                // Book keeping.
                _freeIndices.Push(i);
                _pool.Add(obj);
            }
        }

        public GameObject Borrow()
        {
            if (_freeIndices.Count == 0)
            {
                // TODO: Growable
                return null;
            }
            else
            {
                int index = _freeIndices.Pop();
                GameObject obj = _pool[index];
                obj.SetActive(true);
                return obj;
            }
        }

        // NOTE: I would love to pass a ref to null the actual Reference Type but alas I can't...I think.
        public void Despawn(GameObject obj)
        {
            if (obj == null)
                return;

            // check if it has the Simpoolable component and if the parent is us
            Simpoolable poolableComponent = obj.GetComponent<Simpoolable>();
            if (poolableComponent && poolableComponent.parent == this)
            {
                obj.SetActive(false);

                // Registers itself back into the 
                _freeIndices.Push(poolableComponent.index);
            }
            
        }
    }


}
