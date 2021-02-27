using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Controls controls;

    private float movement;

    private void Start()
    {
        controls.Player.Jump.performed += ctx => Jump();

        controls.Player.Movement.performed += ctx => movement = ctx.ReadValue<float>();
        controls.Player.Movement.performed += ctx => movement = 0;
    }

    private void Update()
    {
        Move();
    }

    private void Jump () {

    }

    private void Move () {

    }
}
