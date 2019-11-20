using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameState : MonoBehaviour
{


    public GameObject levelManager;
    public GameObject player;
    public GameObject cleaner;
    public GameObject generateLevelTrigger;


    private Vector3 prevPlayerVelocity;

    public void Pause()
    {
        levelManager.SetActive(false);
        cleaner.SetActive(false);
        generateLevelTrigger.SetActive(false);

        MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
            script.enabled = false;
        
        player.GetComponent<SpriteRenderer>().enabled = true;
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        prevPlayerVelocity = rb.velocity;
        rb.Sleep();

    }

    public void Unpause()
    {
        levelManager.SetActive(true);
        cleaner.SetActive(true);
        generateLevelTrigger.SetActive(true);

        MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
            script.enabled = true;

        player.GetComponent<SpriteRenderer>().enabled = true;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.WakeUp();
        rb.velocity = prevPlayerVelocity;
    }

}
