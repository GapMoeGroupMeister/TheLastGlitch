using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LchPlayer : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private float _speed = 5f;
    private bool _waitIsUpGradeShop = false;
    private bool _waitIsShop = false;
    [SerializeField] private LayerMask _thisIsUpGradeShop;
    [SerializeField] private LayerMask _thisIsShop;
    private Vector2 _boxCastSize = new Vector2(1f,1f);

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(x, y);
        _rigid.velocity = move.normalized * _speed;
        UpgradeShop();
        if(_waitIsUpGradeShop)
        {
            Debug.Log("°¨ÁöµÊ");
        }
    }

    private void UpgradeShop()
    {
        _waitIsUpGradeShop = Physics2D.BoxCast(transform.position,_boxCastSize,0f,transform.position,_thisIsUpGradeShop);
    }

    private void GizmosDrawBox()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawCube();
    }
}
