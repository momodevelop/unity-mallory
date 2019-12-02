using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerColor : MonoBehaviour
{
    SpriteRenderer sr;
    float timer = 1.0f;
    float duration = 2.0f;
    Color targetColor;
    Color startColor;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startColor = targetColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        sr.color = targetColor;

    }

    // Update is called once per frame
    void Update()
    {

        if (timer >= duration)
        {
            // transition complete
            // assign the target color
            sr.color = targetColor;

            // start a new transition
            startColor = targetColor;
            targetColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
            timer = 0.0f;
        }
        else
        {
            sr.color = Color.Lerp(startColor, targetColor, timer / duration);
            timer += Time.deltaTime;
        }

    }
}
