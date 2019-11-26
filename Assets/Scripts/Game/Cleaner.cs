using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(Utils.GetCameraWidthPixels(), Utils.GetPixelPerUnit());

        GameManager.I.PauseGameEvent += Pause;
        GameManager.I.UnpauseGameEvent += Unpause;

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - Camera.main.orthographicSize - 1.5f);
    }

    public void Pause()
    {
        this.gameObject.SetActive(false);
    }

    public void Unpause()
    {
        this.gameObject.SetActive(true);
    }

}
