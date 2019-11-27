using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    IPauseable[] pauseables;

    [SerializeField]
    Transform player;
    int score = 0;

    void Start()
    {
        pauseables = GetComponentsInChildren<IPauseable>();
    }

    public void Pause()
    {
        foreach (IPauseable pauseable in pauseables)
            pauseable.Pause();
    }

    public void Unpause()
    {
        foreach (IPauseable pauseable in pauseables)
            pauseable.Unpause();
    }

    void Update()
    {
        // score keeping
        if (this.transform.position.y > Camera.main.transform.position.y)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);
            ++score;
        }
    }

    public int GetScore()
    {
        return score;
    }
}
