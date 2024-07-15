using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    public ContactFilter2D filter;
    public float damageRaduis;
    public int detecutCont = 1;

    public Collider2D[] _colliders;

    private void Awake()
    {
        _colliders = new Collider2D[detecutCont];
    }

    public bool CastDamge(int damage, float knockbackPower)
    {
        int cut = Physics2D.OverlapCircle(transform.position, damageRaduis,filter,_colliders);

        for(int i = 0; i < cut; i++)
        {
            if(_colliders[i].TryGetComponent(out Health health))
            {
                Vector2 direction = _colliders[i].transform.position - transform.position;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, direction.magnitude, filter.layerMask);
                health.TakeDamage(damage, hit.normal, hit.point, knockbackPower);
            }
        }
        return cut > 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, damageRaduis);
        Gizmos.color = Color.white;
    }
}
