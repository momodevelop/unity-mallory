using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasRenderer))]
public class Selector : MonoBehaviour
{
    CanvasRenderer cr;
    float timer = 1.0f;
    float duration = 2.0f;
    Color targetColor;
    Color startColor;
    // Start is called before the first frame update
    void Start()
    {
        cr = GetComponent<CanvasRenderer>();
        startColor = targetColor = new Color(Random.value , Random.value, Random.value);
        cr.SetColor(targetColor);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= duration)
        {
            // transition complete
            // assign the target color
            cr.SetColor(targetColor);

            // start a new transition
            startColor = targetColor;
            targetColor = new Color(Random.value, Random.value, Random.value);
            timer = 0.0f;
        }
        else
        {
            cr.SetColor(Color.Lerp(startColor, targetColor, timer/duration));
            timer += Time.deltaTime;
        }
    }
}
