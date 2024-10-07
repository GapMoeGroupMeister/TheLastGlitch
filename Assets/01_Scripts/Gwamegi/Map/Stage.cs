using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.Player.gameObject.SetActive(true);       
    }
}
