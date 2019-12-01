using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAddScore : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        EventManager.I.Events.StartListening("add_score", AddScore);
    }

    private void AddScore(object obj)
    {
        transform.position = new Vector3(
            transform.position.x,
            (float)obj,
            transform.position.z);
    }
}
