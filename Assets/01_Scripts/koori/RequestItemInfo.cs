using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RequestItemInfo : MonoBehaviour
{
    [SerializeField] private Image _item1, _item2;
    [SerializeField] private TMP_Text _item1Price, _item2Price;
    public void ReloadData(int item1, int item2, Sprite item1Img, Sprite item2Img)
    {
        _item1Price.text = $"{item1}";
        _item2Price.text = $"{item2}";
        _item1.sprite = item1Img ;
        _item2.sprite = item2Img ;
    }
}
