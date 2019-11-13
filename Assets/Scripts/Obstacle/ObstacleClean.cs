using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Momo;

public class ObstacleClean : MonoBehaviour
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
            GameObjectPool.Poolable poolable = GetComponent<GameObjectPool.Poolable>();
            if (poolable)
            {
                this.GetComponent<Momo.GameObjectPool.Poolable>().Return();
            }
        }
    }
}
