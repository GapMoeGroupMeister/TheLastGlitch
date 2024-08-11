using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyAttack : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private LineRenderer _lineRenderer;

    private void Awake()
    {
        _target = GameObject.FindWithTag("Player").transform;
        _lineRenderer = _laserPrefab.GetComponent<LineRenderer>();
    }

    public void FireLaser()
    {
        Vector3 startPosition = transform.position;

        Vector3 endPosition = _target.position;

        _lineRenderer.SetPosition(0, startPosition);
        _lineRenderer.SetPosition(1, endPosition);

        transform.LookAt(_target);
    }
}
