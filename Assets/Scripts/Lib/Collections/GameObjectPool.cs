using System.Collections.Generic;
using UnityEngine;

namespace Momo
{
    class GameObjectPool : MonoBehaviour
    {
        public class Poolable : MonoBehaviour
        {
            internal GameObjectPool parent = null;
            internal int index = -1;
            public void Return()
            {
                parent.Despawn(gameObject);
            }
        }

        
        [SerializeField] private GameObject _prefab = null;
        // TODO: For pools that are growable.
        // [SerializeField] private bool _growable;
        [SerializeField] private int _capacity = 0;

        Stack<int> _freeIndices;
        List<GameObject> _pool;

        // Some properties to display
        public int TotalGameObjects { get => _pool.Count; }
        public int FreeGameObjects { get => _freeIndices.Count; }

        private void Start()
        {
            _pool = new List<GameObject>();
            _freeIndices = new Stack<int>();
            for (int i = 0; i < _capacity; ++i)
            {
                GameObject obj = (GameObject)Instantiate(_prefab);
                obj.SetActive(false);

                // Add our poolable script that gives helper functions
                // and help us identify if the game object belongs to us.
                Poolable poolable = obj.AddComponent<Poolable>();
                poolable.index = i;
                poolable.parent = this;

                // Book keeping.
                _freeIndices.Push(i);
                _pool.Add(obj);
            }
        }

        public GameObject Spawn()
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

            // check if it has the Poolable component and if the parent is us
            Poolable poolableComponent = obj.GetComponent<Poolable>();
            if (poolableComponent && poolableComponent.parent == this)
            {
                obj.SetActive(false);

                // Registers itself back into the 
                _freeIndices.Push(poolableComponent.index);
            }
            
        }
    }


}
