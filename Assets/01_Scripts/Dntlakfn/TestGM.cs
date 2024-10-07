using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TestGM : MonoBehaviour
{
    [SerializeField] protected TestInventory inventory;
    [SerializeField] protected FConsole Fco_NsOLe;

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.F1))
        {
            Fco_NsOLe.gameObject.SetActive(Fco_NsOLe.Trigger);
        }
    }
}
