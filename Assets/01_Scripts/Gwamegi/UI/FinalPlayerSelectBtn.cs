using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalPlayerSelectBtn : MonoBehaviour
{

    [SerializeField] private RectTransform _selectPanel;

    public void BtnYes()
    {

        LoadingSceneManager.LoadScene("MenuScene");
    }

    public void BtnNo()
    {
        _selectPanel.DOScaleY(0, 0.2f);
    }
}
