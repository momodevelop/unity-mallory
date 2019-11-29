using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Momo;
using UnityEngine.SceneManagement;

public class PlayerClean : MonoBehaviour
{
    private int _cleanerLayerId;
    public string cleanerLayerName;

    private void Awake()
    {
        _cleanerLayerId = LayerMask.NameToLayer(cleanerLayerName);
        EventManager.I.Events.StartListening("pause", Pause);
        EventManager.I.Events.StartListening("unpause", Unpause);
    }
    private void Unpause(object obj)
    {
        this.enabled = false;
    }

    private void Pause(object obj)
    {
        this.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _cleanerLayerId)
        {
            EventManager.I.Events.TriggerEvent("player_died", null);
        }
    }
}
