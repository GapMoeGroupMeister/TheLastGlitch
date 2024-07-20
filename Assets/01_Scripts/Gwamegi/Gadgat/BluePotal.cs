using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BluePotal : MonoBehaviour
{
    private Collider2D player;

    private void Update()
    {
        player = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Player"));


        if (player != null && PotalManager.Instance.isWarp)
        {
            Warp();
        }
        else if(player == null)
        {
            if (!PotalManager.Instance.isWarp)
            {
                PotalManager.Instance.isWarp = true;
            }
        }
    }

    private void Warp()
    {
        
    }
}
