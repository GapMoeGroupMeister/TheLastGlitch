using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AcceptedButton : MonoBehaviour
{
    

    [SerializeField] protected GameObject accepted;
    [SerializeField] protected GameObject quest;
        
    private void OnEnable()
    {
        accepted = FindAnyObjectByType<AcceptedQuest>().gameObject;
        quest = FindAnyObjectByType<DisplayQuest>().gameObject;
    }
    public void PressAccepted()
    {
        Debug.Log("Accepted");
        accepted.gameObject.SetActive(true);
        quest.gameObject.SetActive(false);
       
    }
    
    public void PressQuest()
    {
        Debug.Log("Quest");

        accepted.gameObject.SetActive(false);
        quest.gameObject.SetActive(true);
        
    }
     
}
