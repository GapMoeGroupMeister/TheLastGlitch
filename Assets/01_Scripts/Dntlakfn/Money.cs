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
        money = PlayerItemData.Instance.gadgetData.Gold;
    }

    private void Update()
    {
        money = PlayerItemData.Instance.gadgetData.Gold;
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            PlayerItemData.Instance.gadgetData.Gold += 1000000;
        }
        text.text = money.ToString() + " Coin";
    }
}
