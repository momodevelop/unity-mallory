using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(CanvasRenderer))]
[RequireComponent(typeof(Text))]
public class Quote : MonoBehaviour
{
    CanvasRenderer cr;
    Text txt;
    float timer = 0.0f;
    float erasingOneLetterDuration = 0.1f;
    float displayDuration = 3.0f;
    float typingOneLetterDuration = 0.1f;
    int targetTextPos = 0;

    string[] randomQuotes = new string[]
    {
        "Why am I climbing so high for?",
        "I wondering what's at the top...?",
        "It sure is getting lonely...",
        "I have to climb. I have to.",
        "I have already forgotten the reason...",
        "Did I reach this high before?",
        "When will this end?",
        "Momo is such an amazing developer...",
        "What does Mallory even mean anyway?",
        "I'm hungry..."
    };

    string targetText = "Why am I climbing so high for?";
    enum States
    {
        TYPING,
        ERASING,
        DISPLAY
    }
    States state = States.TYPING;

    // Start is called before the first frame update
    void Start()
    {
        cr = GetComponent<CanvasRenderer>();
        txt = GetComponent<Text>();
        targetText = GetRandomQuote();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case States.TYPING:
                Typing();
                break;
            case States.ERASING:
                Erasing();
                break;
            case States.DISPLAY:
                Display();
                break;
        }
    }

    void Typing()
    {
        timer += Time.deltaTime;
        if (timer >= typingOneLetterDuration)
        {
            txt.text = targetText.Substring(0, targetTextPos++);
            timer = 0.0f;
        }

        if (txt.text == targetText)
        {
            state = States.DISPLAY;
        }
    }

    void Erasing()
    {
        timer += Time.deltaTime;
        if (timer >= erasingOneLetterDuration)
        {
            txt.text = targetText.Substring(0, --targetTextPos);
            timer = 0.0f;
        }


        if (txt.text == "")
        {
            state = States.TYPING;
            targetText = GetRandomQuote();
        }
    }

    string GetRandomQuote()
    {
        return randomQuotes[Random.Range(0, randomQuotes.Length)];
    }
    void Display()
    {
        timer += Time.deltaTime;
        if (timer >= displayDuration)
        {
            state = States.ERASING;
            timer = 0.0f;
        }
    }
}
