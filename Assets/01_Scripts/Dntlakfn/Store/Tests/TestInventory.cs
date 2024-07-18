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
    
    [SerializeField] protected GameObject empty;
    
    [SerializeField] protected bool trigger = false;
    public bool Trigger
    {
        get
        {
            
            trigger = !trigger;
            return !trigger;
        }
    }
    
    

    private void Start()
    {
        HaveItems = new List<TestItemSO>();
        gameObject.SetActive(Trigger);
    }


    public void SetInventory()
    {
        Image icon = Instantiate(empty, transform).GetComponent<Image>();
        icon.sprite = HaveItems.Last()._icon;
        
 
    }

   

}
