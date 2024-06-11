using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent<Vector2> OnPoiterChange;
    public Action OnFireButton;
    public Action OnFrenzyPressed;
    public Action OnDashPressed;

    private Camera mainCam;
    public Vector2 moveDir { get; private set; }

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        GetMouseInput();
        FireInput();
        MoveInput();
        FrenzySkill();
        DashSkill();
    }

    public void GetMouseInput()
    {
        Vector3 mouse = mainCam.ScreenToWorldPoint(Input.mousePosition);
        OnPoiterChange?.Invoke(mouse);
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
            OnFireButton?.Invoke();
        }
    }

    public void FrenzySkill()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnFrenzyPressed?.Invoke();
        }
    }

    public void DashSkill()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnDashPressed?.Invoke();
        }
    }
}
