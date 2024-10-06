using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TestEffectPlayer : MonoBehaviour
{
    public UnityEvent ming;

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            ming?.Invoke();
        }
    }
}
