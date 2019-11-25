using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public delegate void ReachedNewHeight(float height);
    public event ReachedNewHeight ReachedNewHeightEvent;

    void Start()
    {
        ReachedNewHeightEvent?.Invoke(Camera.main.transform.position.y);
    }
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > Camera.main.transform.position.y)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);
            ReachedNewHeightEvent?.Invoke(Camera.main.transform.position.y);
        }
    }
}
