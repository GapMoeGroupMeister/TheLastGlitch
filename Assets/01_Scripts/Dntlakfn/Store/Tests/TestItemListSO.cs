using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="SO/TestItemList")]
public class TestItemListSO : ScriptableObject
{
    public List<TestItemSO> list;
}
