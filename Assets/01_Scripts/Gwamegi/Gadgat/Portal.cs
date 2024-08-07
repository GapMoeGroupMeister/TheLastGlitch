using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform _teleportingPortal;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.GetMask("Player") && collision.gameObject.GetComponent<PortalPlayer>().isTeleporting)
        {
            collision.gameObject.transform.position = _teleportingPortal.position;
            collision.gameObject.GetComponent<PortalPlayer>().isTeleporting = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.GetMask("Player"))
        {
            collision.gameObject.GetComponent<PortalPlayer>().isTeleporting = true;
        }
    }

}
