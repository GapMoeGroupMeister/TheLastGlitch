using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LchPlayer : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private float _speed = 5f;
    private bool _waitIsUpGrade = false;
    private bool _waitIsShop = false;
    [SerializeField] private LayerMask _thisIsUpGrade;
    [SerializeField] private LayerMask _thisIsShop;
    private Vector2 _boxCastSize = new Vector2(1f,1f);
    private float _boxCastDirection = 0.6f;
    [SerializeField] private GameObject _UpGraddeUI;
    [SerializeField] private GameObject _ShopUI;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(x, y);
        _rigid.velocity = move.normalized*_speed;
        UpgradeShop();
        if (_waitIsUpGrade && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("°¨ÁöµÊ");
            _UpGraddeUI.SetActive(true);
        }
        if(_waitIsShop && Input.GetKeyDown(KeyCode.F))
        {
            _ShopUI.SetActive(true);
        }
    }

    private void UpgradeShop()
    {
        _waitIsUpGrade = Physics2D.BoxCast(transform.position,_boxCastSize,0f,transform.position,_boxCastDirection,_thisIsUpGrade);
        _waitIsShop = Physics2D.BoxCast(transform.position, _boxCastSize, 0f, transform.position, _boxCastDirection, _thisIsShop);
    }

    private void GizmosDrawBox()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawCube();
    }
}
