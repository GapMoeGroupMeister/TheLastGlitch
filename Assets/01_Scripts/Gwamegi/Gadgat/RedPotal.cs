using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotal : MonoBehaviour
{
    private Collider2D player;

    private void Update()
    {
        player = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Player"));

        if (player != null)
        {
            Warp();
        }
        else
        {
            if (PotalManager.Instance.isRed && !PotalManager.Instance.isWarp)
            {
                Debug.Log("RedPotal");
                PotalManager.Instance.isWarp = true;
            }
        }

    }

    private void Warp()
    {
        if (PotalManager.Instance.isWarp)
        {
            Debug.Log("!ÆÄ¶û¿¡¼­ »¡°»ÀÌ·Î.");
            PotalManager.Instance.isWarp = false;
            player.transform.position = PotalManager.Instance._bluePotalTranform;
            PotalManager.Instance.isWarp = false;

            PotalManager.Instance.isRed = false;

        }

    }
}
