using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerController;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    private PlayerController playerController;

    public Action OnJumpEvent;
    public Action OnAttackEvent;

    public Action OnUseGadgetEvent;
    public Action OnActiveSkillEvent;
    public Action OnSwapingEvent;
    public Action OnInteractionEvent;

    private void OnEnable()
    {
        if (playerController == null)
        {
            playerController = new PlayerController();
        }
        playerController.Player.SetCallbacks(this);
        playerController.Player.Enable();
    }

    public Vector2 Movement { get; private set; }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnJumpEvent?.Invoke();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnAttackEvent?.Invoke();
        }
    }

    public void OnSwap(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnSwapingEvent?.Invoke();
        }

    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnInteractionEvent?.Invoke();
    }

    public void OnUseGadget(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnUseGadgetEvent?.Invoke();
    }

    public void OnActiveSkill(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnActiveSkillEvent?.Invoke();
    }
}
