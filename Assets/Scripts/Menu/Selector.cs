using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class Selector : MonoBehaviour
{
    public float height = 48;
    public float transparency = 0.5f;
    // Start is called before the first frame update
    void Awake()
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float camHeight = Camera.main.orthographicSize * 2 * 100; ;
        float camWidth = screenAspect * camHeight;

        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(camWidth, height) ;

        Color color = this.gameObject.GetComponent<Image>().color;
        this.gameObject.GetComponent<Image>().color = new Color(color.r, color.g, color.b, transparency);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
