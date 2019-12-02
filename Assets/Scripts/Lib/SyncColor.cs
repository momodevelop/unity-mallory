using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Momo
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SyncColor : MonoBehaviour
    {
       
        public SpriteRenderer target;
        SpriteRenderer sr;
        // Start is called before the first frame update
        void Start()
        {
            if (target == null)
                Destroy(this);

            sr = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            sr.color = target.color;
        }
    }

}