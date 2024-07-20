using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private LineRenderer laser;
    public void LaslerAttack(Vector3 target)
    {
        laser.SetPosition(0, transform.position);
        laser.SetPosition(1, target);
    }
}
