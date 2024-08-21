using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AED : MonoBehaviour
{
    [SerializeField] private GameObject visual;
    [SerializeField] private Player1 Player;

    private void Start()
    {
        visual.SetActive(false);
    }

    private void Update()
    {
         if (Player._isDead)
        {
            StartCoroutine(Revival());
        }
    }

    IEnumerator Revival()
    {
        yield return new WaitForSeconds(2);
        visual.SetActive (true);
        visual.transform.Translate(new Vector2(transform.position.x, transform.position.y + 3));
        Player._isDead = false;
    }
}
