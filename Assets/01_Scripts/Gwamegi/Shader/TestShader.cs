using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShader : MonoBehaviour
{
    [SerializeField] private Material _material;

    private void Update()
    {
        _material.SetFloat("_SplitValue", Mathf.Sin(Time.time));
    }
}
