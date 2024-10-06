using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemChecker : MonoBehaviour
{
    [SerializeField] private PlayerItemSO _itemEat;

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);

            switch (collision.gameObject.GetComponent<Item>().itemType)
            {
                case RequireItemType.pcb:
                    _itemEat.requireItemDic[RequireItemType.pcb] += 1;
                    break;
                case RequireItemType.battery:
                    _itemEat.requireItemDic[RequireItemType.battery] += 1;
                    break;
                case RequireItemType.sensor:
                    _itemEat.requireItemDic[RequireItemType.sensor] += 1;
                    break;
                case RequireItemType.metal:
                    _itemEat.requireItemDic[RequireItemType.metal] += 1;
                    break;
                default:
                    break;
            }
        }
    }

}
