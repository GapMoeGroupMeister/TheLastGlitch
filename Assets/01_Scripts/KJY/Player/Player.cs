using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public enum PlayerStateEnum
{
    Idle,
    Walk,
    Run,
    Jump,
    Fall,
    Hit,
    Dead,

    ActiveSkill,

    Weapon1Attack1,
    Weapon1Attack2,

    Weapon2Attack1,
    Weapon2Attack2,

    Weapon1Swap,
    Weapon2Swap,
    Weapon1SwapAttak,
    Weapon2SwapAttak,

}

public abstract class Player : Agent
{
    [field: SerializeField] private InputReader _input;

    [Header("Input bool")]
    public bool _isAttack;
    public bool _isDoubleAttack;
    public bool _isActiveSkill;
    public bool _isInteraction;
    public bool _isSwaping;
    public bool _isUseGadget;

    public bool _isCanAttack = true;

    public float _xMove;


    protected override void Awake()
    {
        base.Awake();
        _input.OnJumpEvent += OnJump;
        _input.OnAttackEvent += OnAttack;
        _input.OnActiveSkillEvent += OnActiveSkill;
        _input.OnInteractionEvent += OnInteraction;
        _input.OnSwapingEvent += OnSwaping;
        _input.OnUseGadgetEvent += OnUseGadget;
    }

    private void OnUseGadget()
    {
        _isUseGadget = true;
    }

    private void OnSwaping()
    {
        _isSwaping = true;
        _isCanAttack = false;
    }

    private void OnInteraction()
    {
        _isInteraction = true;
    }

    private void OnActiveSkill()
    {
        _isActiveSkill = true;
    }

    protected void OnJump()
    {
        if (MovementComponent.isGround.Value)
        {
            MovementComponent.Jump();
        }
    }

    protected virtual void Update()
    {
        OnMovement();
    }

    private void OnMovement()
    {
        _xMove = _input.Movement.x;
    }

    private void OnAttack()
    {
        if (!_isAttack)
        {
            _isAttack = true;
            print("1");
        }
        else
        {
            _isDoubleAttack = true;
            _isAttack = false;
            print("2");
        }
    }

    public override void SetDeadState()
    {
        IsDie = true;
    }

}
