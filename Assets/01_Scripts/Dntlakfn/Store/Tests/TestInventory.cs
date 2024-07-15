using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class TestInventory : MonoBehaviour
{
    
    public static List<TestItemSO> HaveItems;
    public static int ItemCount = 0;
    [SerializeField] protected bool trigger = false;
    public bool Trigger
    {
        get
        {
            trigger = !trigger;
            return !trigger;
        }
    }
    
    [SerializeField] protected GameObject haveItem;

    private void Awake()
    {
        HaveItems = new List<TestItemSO>();
        gameObject.SetActive(Trigger);
        
    }

    
    public void SetInventory()
    {
        Image a = Instantiate(haveItem, transform).GetComponent<Image>();
        a.sprite = HaveItems.Last()._icon;

    }

   

}
