using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
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
