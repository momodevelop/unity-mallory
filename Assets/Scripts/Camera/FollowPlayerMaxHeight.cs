using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    Vector3 savedPosition;

    private void Start()
    {
        savedPosition = transform.position;
    }
    void SaveCurrentPosition()
    {
        savedPosition = this.transform.position;
    }

    Vector3 GetSavedPosition()
    {
        return savedPosition;
    }
}
