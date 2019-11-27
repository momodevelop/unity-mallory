using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Momo;
using UnityEngine.SceneManagement;

public class PlayerClean : MonoBehaviour
{
    private int _cleanerLayerId;
    public string cleanerLayerName;

    private void Start()
    {
        _cleanerLayerId = LayerMask.NameToLayer(cleanerLayerName);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _cleanerLayerId)
        {
            SceneManager.LoadScene("Splash");
        }
    }
}
