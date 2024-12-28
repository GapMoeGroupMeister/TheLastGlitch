using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.InputSystem;


public class SettingManager : MonoBehaviour
{
	[SerializeField] private AudioMixer _Audiomixer;
	[SerializeField] private Slider _musicSlider;
	[SerializeField] private Slider _sfxSlider;

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            gameObject.SetActive(false);
        }

        if(GameObject.Find(gameObject.name) != null)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }


    public void SettingPanelClose()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SettingOpen()
    {
        gameObject.SetActive(true);
    }
}
