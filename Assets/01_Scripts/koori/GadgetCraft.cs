using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GadgetCraft : MonoBehaviour, IInteractive
{
    [SerializeField] private GameObject _craftWindow;

    private void Awake()
    {
        _craftWindow.SetActive(false);
    }
    public void OnInteract()
    {
        _craftWindow.SetActive(true);
    }
}
