using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapPosition : MonoBehaviour
{
    public bool wrapX = false;
    public bool wrapY = false;

    Vector3 mins;
    Vector3 maxs;
    private void Start()
    {
        mins = Camera.main.ScreenToWorldPoint(Vector3.zero);
        maxs = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        if (!wrapX && !wrapY)
            return;

        Vector2 newPosition = transform.position;
        if (wrapX) {
            if (transform.position.x < mins.x)
            {
                newPosition.x = maxs.x;
            }

            if (transform.position.x > maxs.x)
            {
                newPosition.x = mins.x;
            }
        }

        if (wrapY)
        {
            if (transform.position.y < mins.y)
            {
                newPosition.y = maxs.y;
            }

            if (transform.position.y > maxs.y)
            {
                newPosition.y = mins.y;
            }
        }

        transform.position = newPosition;
        


    }
}
