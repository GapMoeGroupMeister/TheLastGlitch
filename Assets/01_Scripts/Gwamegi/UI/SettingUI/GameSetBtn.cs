using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetBtn : MonoBehaviour
{
    [SerializeField] private GameObject _soundSettingUI;
    [SerializeField] private GameObject _keySettingUI;
    [SerializeField] private GameObject _screenSettingUI;

    public void SoundSetBtnClick()
    {
        _keySettingUI.SetActive(false);
        _screenSettingUI.SetActive(false);
        _soundSettingUI.SetActive(true);
    }

    public void KeySettingBtnClick()
    {
        _screenSettingUI.SetActive(false);
        _soundSettingUI.SetActive(false);
        _keySettingUI.SetActive(true);
    }

    public void ScreenSettingBtnClick()
    {

        _keySettingUI.SetActive(false);
        _soundSettingUI.SetActive(false);
        _screenSettingUI.SetActive(true);
    }


}
