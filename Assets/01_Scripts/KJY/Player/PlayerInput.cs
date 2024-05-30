using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PlayerInput : MonoBehaviour
{
    public Action OnFireButton;
    public Action OnRunPressed;

    public Vector2 moveDir { get; private set; }

    private void Update()
    {
        MoveInput();
        RunSpeed();
    }

    public void MoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(x, y);
    }

    public void FireInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            OnFireButton.Invoke();
        }
    }

    public void RunSpeed()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnRunPressed.Invoke();
        }
    }
}
