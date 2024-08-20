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
        gameObject.SetActive(true);
        for (int i = gameObject.GetComponentsInChildren<GoodsControl>() != null ? gameObject.GetComponentsInChildren<GoodsControl>().Length : 0; i < HaveItems.Count; i++)
        {
            Image icon = Instantiate(empty, transform).GetComponent<Image>();
            icon.sprite = HaveItems[i]._icon;
        }
        gameObject.SetActive(false);




    }

   

}
