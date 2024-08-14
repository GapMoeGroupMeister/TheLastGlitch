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
        
    private void Awake()
    {
        aa = FindAnyObjectByType<AcceptedQuest>().gameObject;
        bb = FindAnyObjectByType<DisplayQuest>().gameObject;
    }
    public void PressAccepted()
    {
        Debug.Log("El");

        a.GetComponentInChildren<TextMeshProUGUI>().color = new Color(0, 255, 255);
        q.GetComponentInChildren<TextMeshProUGUI>().color = new Color(0, 174, 164);
        aa.gameObject.SetActive(true);
        bb.gameObject.SetActive(false);
       
    }
    
    public void PressQuest()
    {
        Debug.Log("rl");

        q.GetComponentInChildren<TextMeshProUGUI>().color = new Color(0, 255, 255);
        a.GetComponentInChildren<TextMeshProUGUI>().color = new Color(0, 174, 164);
        aa.gameObject.SetActive(false);
        bb.gameObject.SetActive(true);
        
    }
     
}
