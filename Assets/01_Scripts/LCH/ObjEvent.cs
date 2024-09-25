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

    private void Update()
    {
        Debug.Log(_health.CurrentHealth);
    }

    public void DestroyObj()
    {
        Destroy(gameObject);
    }
}
