using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Momo
{
    public class FollowCameraSideOnce : MonoBehaviour
    {
        public enum Side
        {
            TOP,
            LEFT,
            BOTTOM,
            RIGHT
        }

        public Side side = Side.TOP;
        void Start()
        {
            Vector3 pos = transform.position;
            switch (side)
            {
                case Side.TOP:
                    pos.y += CameraStats.GetCameraHeight();
                    break;
                case Side.BOTTOM:
                    pos.y -= CameraStats.GetCameraHeight();
                    break;
                case Side.LEFT:
                    pos.x -= CameraStats.GetCameraWidth();
                    break;
                case Side.RIGHT:
                    pos.x += CameraStats.GetCameraWidth();
                    break;
            }
            transform.position = new Vector3(transform.position.x, Camera.main.gameObject.transform.position.y + CameraStats.GetCameraHeight(), transform.position.z);
            Destroy(this);
        }
    }
}