using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPause : MonoBehaviour
{
    Vector3 oldVelocity;

    private void Start()
    {
        GameManager.I.PauseGameEvent += Pause;
        GameManager.I.UnpauseGameEvent += Unpause;
    }

    public void Pause()
    {
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
            script.enabled = false;
        GetComponent<SpriteRenderer>().enabled = true;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        oldVelocity = rb.velocity;
        rb.Sleep();

    }

    public void Unpause()
    {
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
            script.enabled = true;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = oldVelocity;
        rb.WakeUp();
    }
}
