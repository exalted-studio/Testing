using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    InputMaster controls;

    void Awake()
    {
        controls = new InputMaster();
        controls.Player.Attack.performed += Attack;
        controls.Player.Movement.performed += Move;
    }

    void Move(InputAction.CallbackContext ctx)
    {
        Vector2 direction = ctx.ReadValue<Vector2>();
        Debug.Log("Moving: " + direction);
    }

    void Attack(InputAction.CallbackContext ctx)
    {
        Debug.Log("Bang bang!");
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }
}
