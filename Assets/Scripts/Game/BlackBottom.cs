using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBottom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float camHeight = Camera.main.orthographicSize * 2 * 100;
        float camWidth = screenAspect * camHeight;

        Transform camTransform = Camera.main.transform;
        this.transform.localScale = new Vector3(camWidth, camHeight);
        this.transform.position = camTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
