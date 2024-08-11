using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Vector2 _mousePos;

    private void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (((Vector2)(_player.transform.position - transform.position)).magnitude <= new Vector2(1,1).magnitude)
            return;

        transform.position = _mousePos;

    }
}
