using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Momo
{
    public class FollowCameraOnce : MonoBehaviour
    {
        public bool followX;
        public bool followY;
        // Update is called once per frame
        void Start()
        {
            if (followX)
                transform.position = new Vector3(Camera.main.gameObject.transform.position.x, transform.position.y, transform.position.z);
            if (followY)
                transform.position = new Vector3(transform.position.x, Camera.main.gameObject.transform.position.y, transform.position.z);
            Destroy(this);
        }
    }
}