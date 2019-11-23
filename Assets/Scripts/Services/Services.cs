using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Services : MonoBehaviour
{
    public static PauseManager pauseManager { get; } = new PauseManager();
    public static GameManager gameManager { get; } = GameObject.Find("GameManager").GetComponent<GameManager>();
    public static Camera cam { get; } = Camera.main;
    public static GameObject player { get; } = GameObject.Find("Player");
}
