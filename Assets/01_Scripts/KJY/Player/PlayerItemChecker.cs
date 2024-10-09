using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemChecker : MonoBehaviour
{
    [SerializeField] private PlayerItemData _itemEat;

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
                    PlayerItemData.Instance.requireItemDic[RequireItemType.pcb] += 1;
                    break;
                case RequireItemType.battery:
                    PlayerItemData.Instance.requireItemDic[RequireItemType.battery] += 1;
                    break;
                case RequireItemType.sensor:
                    PlayerItemData.Instance.requireItemDic[RequireItemType.sensor] += 1;
                    break;
                case RequireItemType.metal:
                    PlayerItemData.Instance.requireItemDic[RequireItemType.metal] += 1;
                    break;
                case RequireItemType.gear:
                    PlayerItemData.Instance.requireItemDic[RequireItemType.gear] += 1;
                    break;
                default:
                    break;
            }
        }
    }

}
