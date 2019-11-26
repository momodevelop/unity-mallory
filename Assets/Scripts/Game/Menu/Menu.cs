using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public event Action IntroDoneEvent;
    public event Action OutroDoneEvent;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.I.ShowMenuEvent += OnShowMenu;
        GameManager.I.HideMenuEvent += OnHideMenu;

        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnShowMenu()
    {
        this.gameObject.SetActive(true);
    }

    void OnHideMenu()
    {
        this.gameObject.SetActive(false);
    }
}
