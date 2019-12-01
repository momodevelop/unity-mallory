using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundGlow : MonoBehaviour
{
    float timer = 0.1f;
    float duration = 0.1f;
    float increment = 1.0f;

    SpriteRenderer sr;
    public float speed = 0.1f;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += increment * Time.deltaTime * speed;
        if (timer >= duration)
        {
            timer = duration;
            increment = -1.0f;
        }
        if (timer <= 0.0f)
        {
            timer = 0.0f;
            increment = 1.0f;
        }

        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, Mathf.Lerp(0.1f, 1.0f, timer / duration));
    }
}
