using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    private TextMeshProUGUI text;
    public static int money = 0;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        money = DataManager.Instance.money;
    }

    private void Update()
    {
        money = DataManager.Instance.money;
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            DataManager.Instance.money += 1000000;
        }
        text.text = money.ToString() + " Coin";
    }
}
