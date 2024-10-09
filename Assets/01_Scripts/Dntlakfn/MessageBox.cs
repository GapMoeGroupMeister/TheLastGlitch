using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageBox : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _warningText;
    private PlayerInteract interact;

    private void OnEnable()
    {
        interact = FindAnyObjectByType<PlayerInteract>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cancel();
        }
    }
 
    public void SetMessage(string message)
    {
        
        _warningText.text = message;
    }

    public void Cancel()
    {

        Destroy(gameObject);
    }

}
