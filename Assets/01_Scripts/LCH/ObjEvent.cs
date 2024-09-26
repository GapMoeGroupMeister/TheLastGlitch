using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjEvent : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void DestroyObj()
    {
        Debug.Log("사라져라");
        Destroy(gameObject);
    }
}
