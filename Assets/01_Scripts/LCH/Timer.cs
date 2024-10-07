using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textTmp;
    [SerializeField] private GameObject _timerUi;

    public bool isGameOver;
    public float _timer { get; set; }

    private void Start()
    {
        _timerUi.SetActive(true);
    }

    private void OnDisable()
    {
        _timer = 0F;
    }

    private void Update()
    {
        if (isGameOver) return;
        _timer += Time.deltaTime;
        _textTmp.text = $"{Mathf.FloorToInt(_timer)}";
    }
}
