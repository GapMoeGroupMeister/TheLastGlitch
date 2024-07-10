using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestInventory : MonoBehaviour
{
    
    public static List<TestItemSO> HaveItems;
    public static int ItemCount = 0;

    [SerializeField] protected GameObject item;

    private void Awake()
    {
        HaveItems = new List<TestItemSO>();
    }

    public void SetInventory()
    {
        foreach (TestItemSO item in HaveItems)
        {
            if(item != null)
            {
                Instantiate(this.item, transform);
            }
                
        }
        
    }
}
