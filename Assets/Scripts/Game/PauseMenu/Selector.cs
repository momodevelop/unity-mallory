using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CanvasRenderer))]
public class Selector : MonoBehaviour
{

    public enum Options
    {
        GO_TO_GAME,
        RESTART,
        QUIT
    }
    CanvasRenderer cr;
    float timer = 1.0f;
    float duration = 2.0f;
    Color targetColor;
    Color startColor;
    bool update = true;

    private int selected = 0;

    [SerializeField]
    Transform[] optionTransforms = new Transform[3];

    // Start is called before the first frame update
    void Awake()
    {
        cr = GetComponent<CanvasRenderer>();
        startColor = targetColor = new Color(UnityEngine.Random.value , UnityEngine.Random.value, UnityEngine.Random.value);
        cr.SetColor(targetColor);

        EventManager.I.Events.StartListening("pause", ShowMenu);
        EventManager.I.Events.StartListening("unpause", HideMenu);

        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, optionTransforms[0].position.y + 5.0f, pos.z);
    }

    private void ShowMenu(object obj)
    {
        Controller.I.GetControls().Player.Up.performed += SelectionUp;
        Controller.I.GetControls().Player.Down.performed += SelectionDown;
        Controller.I.GetControls().Player.Jump.performed += SelectionConfirm;
        update = true;

    }

    private void HideMenu(object obj)
    {
        Controller.I.GetControls().Player.Up.performed -= SelectionUp;
        Controller.I.GetControls().Player.Down.performed -= SelectionDown;
        Controller.I.GetControls().Player.Jump.performed -= SelectionConfirm;
        update = false;
    }

    private void OnDestroy()
    {
        Controller.I.GetControls().Player.Up.performed -= SelectionUp;
        Controller.I.GetControls().Player.Down.performed -= SelectionDown;
        Controller.I.GetControls().Player.Jump.performed -= SelectionConfirm;
    }

    // Update is called once per frame
    void Update()
    {
        if (!update)
            return;

        if (timer >= duration)
        {
            // transition complete
            // assign the target color
            cr.SetColor(targetColor);

            // start a new transition
            startColor = targetColor;
            targetColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
            timer = 0.0f;
        }
        else
        {
            cr.SetColor(Color.Lerp(startColor, targetColor, timer/duration));
            timer +=  Time.deltaTime;
        }

    }

    void SelectionUp(InputAction.CallbackContext obj)
    {
        if (selected == (int)Options.GO_TO_GAME)
            return;
        --selected;
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, optionTransforms[selected].position.y + 5.0f, pos.z);
    }

    void SelectionDown(InputAction.CallbackContext obj)
    {
        if (selected == (int)Options.QUIT)
            return;
        ++selected;
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, optionTransforms[selected].position.y + 5.0f, pos.z);
    }


    public void SelectionConfirm(InputAction.CallbackContext obj)
    {
        switch((Options)selected)
        {
            case Options.GO_TO_GAME:
                EventManager.I.Events.TriggerEvent("unpause", null);
                break;
            case Options.QUIT:
                EventManager.I.Events.TriggerEvent("game_quit", null);
                break;
            case Options.RESTART:
                EventManager.I.Events.TriggerEvent("game_restart", null);
                break;
        }
    }
}
