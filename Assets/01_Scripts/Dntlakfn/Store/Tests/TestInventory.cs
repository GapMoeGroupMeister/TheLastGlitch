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

    private void Start()
    {
        HaveItems = new List<TestItemSO>();
        gameObject.SetActive(Trigger);
    }


    public void UpdateInventory()
    {

        if(HaveItems.Count == 0)
        {
            return;
        }
        Image a = Instantiate(haveItem, transform).GetComponent<Image>();
        a.sprite = HaveItems.Last()._icon;
        
 
    }

   

}
