using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGainScore : MonoBehaviour
{
    private void Awake()
    {
        EventManager.I.Events.StartListening("pause", Pause);
        EventManager.I.Events.StartListening("unpause", Unpause);
    }
    private void Unpause(object obj)
    {
        this.enabled = true;
    }

    private void Pause(object obj)
    {
        this.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > Camera.main.transform.position.y)
        {
            EventManager.I.Events.TriggerEvent("add_score", transform.transform.position.y);
        }
    }
}
