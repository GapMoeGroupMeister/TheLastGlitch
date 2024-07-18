using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FConsole : MonoBehaviour
{
    [SerializeField] private TMP_InputField audfuddj;
    [SerializeField] private AudioSource zmdkdkr;

    [SerializeField] protected bool trigger = false;
    public bool Trigger
    {
        get
        {
            trigger = !trigger;
            return !trigger;
        }
    }
    public void Roland()
    {
        
        if (audfuddj.text == "Roland")
        {
            zmdkdkr.Play();
        }
    }

    private void Start()
    {
        gameObject.SetActive(Trigger);
    }
   
}
