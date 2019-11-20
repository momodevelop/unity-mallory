using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public event Action eventPlayerDead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if under the camera
        float deathPositionY = Camera.main.transform.position.y - Camera.main.orthographicSize;
        if(transform.position.y < deathPositionY)
        {
            Debug.Log("Player died");
            this.enabled = false;
            if (eventPlayerDead != null)
                eventPlayerDead();
        }
    }
}
