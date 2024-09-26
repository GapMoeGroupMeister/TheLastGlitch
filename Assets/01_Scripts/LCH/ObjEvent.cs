using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjEvent : MonoBehaviour
{
    [SerializeField] private float _objHp = 40;

    [SerializeField] private LayerMask _layer;
    [SerializeField] private Vector2 _size;

    private void Update()
    {
       bool isWeapon = Physics2D.OverlapBox(transform.position, _size, 0, _layer);

        if (isWeapon)
        {
            DestroyObj();
        }
    }

    public void DestroyObj()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _size);
    }


}
