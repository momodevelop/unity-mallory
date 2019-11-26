using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    IPauseable[] pauseables;
    // Start is called before the first frame update
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
}
