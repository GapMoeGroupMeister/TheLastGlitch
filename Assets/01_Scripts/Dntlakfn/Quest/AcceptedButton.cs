using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AcceptedButton : MonoBehaviour
{
    [SerializeField] protected GameObject a;
    [SerializeField] protected GameObject q;

    [SerializeField] protected GameObject aa;
    [SerializeField] protected GameObject bb;

    [SerializeField] protected TextMeshProUGUI aaa;
    [SerializeField] protected TextMeshProUGUI bbb;
        
    private void OnEnable()
    {
        aa = FindAnyObjectByType<AcceptedQuest>().gameObject;
        bb = FindAnyObjectByType<DisplayQuest>().gameObject;
    }
    public void PressAccepted()
    {
        Debug.Log("El");

        bbb.color = new Color(0, 255, 255);
        aaa.color = new Color(0, 174, 164);
        aa.gameObject.SetActive(true);
        bb.gameObject.SetActive(false);
       
    }
    
    public void PressQuest()
    {
        Debug.Log("rl");

        aaa.color = new Color(0, 255, 255, 255);
        bbb.color = new Color(0, 174, 164, 255);
        Debug.Log(aaa.color);
        aa.gameObject.SetActive(false);
        bb.gameObject.SetActive(true);
        
    }
     
}
