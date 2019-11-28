using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerFreezeOnPause : MonoBehaviour
{
    Vector3 oldVelocity;

    private void Awake()
    {
        EventManager.I.Events.StartListening("pause", Pause);
        EventManager.I.Events.StartListening("unpause", Unpause);
    }

    public void Pause(object o)
    {
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
            script.enabled = false;
        GetComponent<SpriteRenderer>().enabled = true;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        oldVelocity = rb.velocity;
        rb.Sleep();

    }

    public void Unpause(object o)
    {
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
            script.enabled = true;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = oldVelocity;
        rb.WakeUp();
    }
}
