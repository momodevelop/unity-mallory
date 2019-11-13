using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{

    private int _groundLayerId;
    private int _playerLayerId;
    public string groundLayerName;
    public string playerLayerName;
    // Start is called before the first frame update
    void Start()
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float camHeight = Camera.main.orthographicSize * 2;
        float camWidth = screenAspect * camHeight;

        _groundLayerId = LayerMask.NameToLayer(groundLayerName);
        _playerLayerId = LayerMask.NameToLayer(playerLayerName);

        this.transform.localScale = new Vector3(camWidth * 100, 96);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - Camera.main.orthographicSize - 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _groundLayerId)
        {
            Destroy(collision.gameObject);
        }
    }
}
