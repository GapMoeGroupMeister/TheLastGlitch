using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D RbCompo { get; private set; }

    private void Awake()
    {
        RbCompo = GetComponent<Rigidbody2D>();
    }
}
