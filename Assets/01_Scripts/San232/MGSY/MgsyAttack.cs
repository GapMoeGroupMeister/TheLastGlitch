using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyAttack : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _laserPrefab;

    private void Awake()
    {
        _target = GameObject.FindWithTag("Player").transform;
    }

    public void FireLaser()
    {
        
    }
}
