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
        Controller.Instance.GetControls().Player.Left.performed += OnLeftDown;
        Controller.Instance.GetControls().Player.Left.canceled += OnLeftUp;
        Controller.Instance.GetControls().Player.Right.performed += OnRightDown;
        Controller.Instance.GetControls().Player.Right.canceled += OnRightUp;
        Controller.Instance.GetControls().Player.Jump.performed += OnJumpUp;
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
