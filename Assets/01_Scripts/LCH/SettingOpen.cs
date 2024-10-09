using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SettingOpen : MonoBehaviour
{
	[SerializeField] private GameObject _settingPanel;

    private int _count = 0;

    private void Start()
    {
        _settingPanel.SetActive(false);
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            _settingPanel.SetActive(true);
        }
    }
}
