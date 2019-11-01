using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerMaxHeight : MonoBehaviour
{
    [SerializeField]
    Transform player;
    
    // Update is called once per frame
    void Update()
    {
        if (player.position.y > this.transform.position.y)
        {
            this.transform.position = new Vector3(this.transform.position.x, player.position.y, this.transform.position.z);
        }

    }
}
