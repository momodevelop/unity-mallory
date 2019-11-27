using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CanvasRenderer))]
public class Selector : MonoBehaviour
{

    public enum Options
    {
        GO_TO_GAME,
        RESTART,
        QUIT
    }
    CanvasRenderer cr;
    float timer = 1.0f;
    float duration = 2.0f;
    Color targetColor;
    Color startColor;

    private int selected = 0;

    GameObject[] optionTransforms = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        cr = GetComponent<CanvasRenderer>();
        startColor = targetColor = new Color(Random.value , Random.value, Random.value);
        cr.SetColor(targetColor);

        optionTransforms[0] = GameObject.Find("GoToGame");
        optionTransforms[1] = GameObject.Find("Restart");
        optionTransforms[2] = GameObject.Find("Quit");
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

    public void SelectionUp()
    {
        if (selected == 0)
            return;
        --selected;
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, optionTransforms[selected].transform.position.y + 5.0f, pos.z);
    }

    public void SelectionDown()
    {
        if (selected == 2)
            return;
        ++selected;
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, optionTransforms[selected].transform.position.y + 5.0f, pos.z);
    }

    public Options GetSelectedIndex()
    {
        return (Options)selected;
    } 
   
}
