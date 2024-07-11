using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGM : MonoBehaviour
{
    [SerializeField] protected TestInventory inventory;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
            inventory.gameObject.SetActive(inventory.Trigger);
    }
}
