using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SettingPanelUI : MonoBehaviour
{
    [SerializeField] private RectTransform _SettingPanel;

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            FadeOutPanel();
        }
    }

    public void FadeOnPanel()
    {
        _SettingPanel.gameObject.SetActive(true);
    }

    public void FadeOutPanel()
    {
        _SettingPanel.gameObject.SetActive(false);

    }
}
