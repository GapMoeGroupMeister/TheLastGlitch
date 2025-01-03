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
                Vector2 attackableDir = _colliders[i].transform.position - transform.position;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, attackableDir.normalized, attackableDir.magnitude, filter.layerMask);

                Debug.Log(hit.collider.name);
                Vector2 attackDir = new Vector2(Mathf.Clamp(Vector3.Cross(hit.transform.position, transform.position).z, -1, 1), 0);
                if(attackableDir.x < 0)
                {
                    attackDir *= -1;
                }
                else
                {
                    attackDir *= 1;
                }
                health.TakeDamage(damage, attackDir, knockbackPower);
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
