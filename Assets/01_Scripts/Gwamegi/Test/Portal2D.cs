using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2D : MonoBehaviour
{
    public Portal2D linkedPortal; // ����� ��Ż

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (linkedPortal != null)
        {
            Vector2 portalToPlayer = (Vector2)other.transform.position - (Vector2)transform.position;
            float dotProduct = Vector2.Dot(transform.right, portalToPlayer);

            if (dotProduct < 0f)
            {
                // ��Ż�� ����� ��ġ�� ����
                other.transform.position = (Vector2)linkedPortal.transform.position + (Vector2)(other.transform.position - transform.position);

                // ��Ż�� ����� ��ü�� ������ ����
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = linkedPortal.GetComponent<Rigidbody2D>().velocity;
                }
            }
        }
    }
}
