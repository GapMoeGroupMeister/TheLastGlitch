using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseParticle : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        transform.position += new Vector3(0.04f, 0, 0);
        yield return new WaitForSeconds(0.02f);
        transform.position += new Vector3(-0.04f, 0, 0);
        yield return new WaitForSeconds(0.02f);

        StartCoroutine(Move());
    }
}
