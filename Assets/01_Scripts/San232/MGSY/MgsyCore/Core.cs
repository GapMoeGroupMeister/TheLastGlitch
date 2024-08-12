using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    [Header("Core Status")]
    [SerializeField] private Health _coreHealth;
    [SerializeField] private int _coreBombDamager;
    [SerializeField] private float _coreBombRadius;

    public static int coreCount;

    private void Start()
    {
        
    }
}
