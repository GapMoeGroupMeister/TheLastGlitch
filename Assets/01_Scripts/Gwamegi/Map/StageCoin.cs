using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageCoin : MonoBehaviour
{
    private TextMeshProUGUI _coinText;
    private void Awake()
    {
        _coinText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _coinText.SetText($": {DataManager.Instance.money}");
    }
}
