using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textTmp;
    private float _timer = Time.time;

    public float TimeerSet
    {
        get => _timer;
        set => _timer += value;
    }

    private void Update()
    {
        _textTmp.text = $"Timer : {Mathf.FloorToInt(_timer)}";
    }
}
