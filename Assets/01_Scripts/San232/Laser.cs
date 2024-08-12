using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform _muzzlePos;

    private void Awake()
    {
        _muzzlePos.position = gameObject.transform.position;
        _target = GameObject.FindWithTag("Player").transform;
        _lineRenderer = _laserPrefab.GetComponent<LineRenderer>();
        FireLaser();
    }

    private void FireLaser()
    {
        Vector3 startPosition = _muzzlePos.position;

        Vector3 endPosition = _target.position;

        _lineRenderer.SetPosition(0, startPosition);
        _lineRenderer.SetPosition(1, endPosition);

        transform.LookAt(_target);
    }
}