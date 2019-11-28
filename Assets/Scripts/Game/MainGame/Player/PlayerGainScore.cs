using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGainScore : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > Camera.main.transform.position.y)
        {
            Camera.main.transform.position = new Vector3(
                Camera.main.transform.position.x,
                this.transform.position.y,
                Camera.main.transform.position.z);

            EventManager.I.Events.TriggerEvent("add_score", null);
        }
    }
}
