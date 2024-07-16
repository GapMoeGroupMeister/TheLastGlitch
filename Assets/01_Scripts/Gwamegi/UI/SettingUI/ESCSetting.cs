using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCSetting : MonoBehaviour
{
    [SerializeField] private RectTransform _escSetPanel;
    private bool _isEscSetTrue;
    private bool _isEscSetTime = true;

    [SerializeField] private GameObject _GameSetPanel;
    private bool _isGameSetPanelTrue;

    [field: SerializeField] private InputReader _inputReader;

    private void Awake()
    {
        //_inputReader.OnEscKeyDown += SetPanel;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isEscSetTime)
        {
            SetPanel();
        }
    }

    public void SetPanel()
    {

        if (_isGameSetPanelTrue)
        {
            _GameSetPanel.SetActive(false);
            _isGameSetPanelTrue = false;
            _isEscSetTrue = false;
            return;
        }

        _isEscSetTime = false;

        if (_isEscSetTrue)
        {
            _escSetPanel.DOAnchorPosY(1100, 0.5f).OnComplete(() => { _isEscSetTime = true; });
            _isEscSetTrue = false;
            return;
        }

        _escSetPanel.DOAnchorPosY(-165, 0.5f).OnComplete(() => { _isEscSetTime = true; });
        _isEscSetTrue = true;
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void GameSet()
    {
        _GameSetPanel.SetActive(true);

        _escSetPanel.anchoredPosition = new Vector2(410, 1100);

        _isGameSetPanelTrue = true;
    }
}
