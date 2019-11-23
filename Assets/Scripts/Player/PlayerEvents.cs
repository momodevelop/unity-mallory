using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public delegate void ReachedNewHeight(float height);
    public event ReachedNewHeight ReachedNewHeightEvent;
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > Camera.main.transform.position.y)
        {
           
            Services.cam.transform.position = new Vector3(Services.cam.transform.position.x, this.transform.position.y, Services.cam.transform.position.z);
            ReachedNewHeightEvent?.Invoke(Services.cam.transform.position.y);
        }
    }
}
