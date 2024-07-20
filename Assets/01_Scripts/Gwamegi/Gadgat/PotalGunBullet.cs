using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PotalGunBullet : MonoBehaviour
{
    private Vector2 _mousePos;

    [SerializeField] protected GameObject _bluePotalPrefab;
    [SerializeField] protected GameObject _redPotalPrefab;

    protected Vector2 _redPotalTransform;
    protected Vector2 _bluePotalTransform;


    private void Start()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dis = _mousePos - (Vector2)transform.position;
        float dir = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, dir - 90);
    }

    private void Update()
    {
        transform.position += transform.up * 10 * Time.deltaTime;
    }

    public abstract void OnCollisionEnter2D(Collision2D collision);

}
