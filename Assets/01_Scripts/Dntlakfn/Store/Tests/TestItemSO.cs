using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/TestItem")]
public class TestItemSO : ScriptableObject
{
    [Header("UI")]
    public Sprite _icon;
    public string _name;
    public string _toolTip;

    [Header("ItemStat")]
    public PassiveSO passiveSO;
    public int _price;
    

}
