using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerFreezeOnPause : MonoBehaviour
{
    Vector2 oldVelocity;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        EventManager.I.Events.StartListening("pause", Pause);
        EventManager.I.Events.StartListening("unpause", Unpause);
    }

    public void Pause(object o)
    {
        this.enabled = false;
        oldVelocity = rb.velocity;
        rb.Sleep();

    }

    public void Unpause(object o)
    {
        this.enabled = true;
        rb.WakeUp();
        rb.velocity = oldVelocity;
    }
}
