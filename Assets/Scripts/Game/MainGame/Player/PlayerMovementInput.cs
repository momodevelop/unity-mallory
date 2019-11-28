using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Momo;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementInput : MonoBehaviour
{
    private float _movementAxis = 0.0f;
    private CharacterController _charController;

    private void Awake()
    {
        _charController = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        EventManager.I.Events.StartListening("pause", Pause);
        EventManager.I.Events.StartListening("unpause", Unpause);

        Controller.I.GetControls().Player.Left.performed += OnLeftDown;
        Controller.I.GetControls().Player.Left.canceled += OnLeftUp;
        Controller.I.GetControls().Player.Right.performed += OnRightDown;
        Controller.I.GetControls().Player.Right.canceled += OnRightUp;
        Controller.I.GetControls().Player.Jump.performed += OnJumpUp;
    }

    private void Unpause(object obj)
    {
        this.gameObject.SetActive(true);
    }

    private void Pause(object obj)
    {
        this.gameObject.SetActive(false);
    }

    private void OnJumpUp(InputAction.CallbackContext obj)
    {
        _charController.Jump();
    }

    private void OnRightUp(InputAction.CallbackContext obj)
    {
        _movementAxis -= 1.0f;
        _charController.Move(_movementAxis);
    }

    private void OnLeftUp(InputAction.CallbackContext obj)
    {
        _movementAxis += 1.0f;
        _charController.Move(_movementAxis);
    }

    private void OnLeftDown(InputAction.CallbackContext obj)
    {
        _movementAxis -= 1.0f;
        _charController.Move(_movementAxis);
    }

    private void OnRightDown(InputAction.CallbackContext obj)
    {
        _movementAxis += 1.0f;
        _charController.Move(_movementAxis);
    }

    // Update is called once per frame
    void Update()
    {
       
    }



}
