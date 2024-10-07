using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _craftUI;
    [SerializeField] private GameObject _mainUI;
    [SerializeField] private CraftUI _craft;
    [SerializeField] private float _moveY;
    [SerializeField] private Vector3 _ori;

    private void Start()
    {
        _ori = _mainUI.GetComponent<RectTransform>().position;
        _mainUI.GetComponent<RectTransform>().DOMoveY(_moveY, 0.5f);
    }

    public void CraftBtn()
    {
        _mainUI.GetComponent<RectTransform>().DOMoveY(_ori.y, 0.5f);
        _craftUI.GetComponent<RectTransform>().DOMoveY(_moveY,0.5f);
        _craft.ReloadItemCount();
    }

    public void CraftExit()
    {
        _craftUI.GetComponent<RectTransform>().DOMoveY(_ori.y, 0.5f);
        _mainUI.GetComponent<RectTransform>().DOMoveY(_moveY, 0.5f);
    }
}
