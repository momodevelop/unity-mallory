using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{
    public PlayerEvents playerEvents;
    // Start is called before the first frame update
    void Start()
    {
        if (playerEvents == null)
            Destroy(this.gameObject);
        playerEvents.eventPlayerDead += onPlayerDeath;
    }

    void onPlayerDeath()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
