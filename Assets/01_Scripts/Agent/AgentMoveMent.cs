using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [Header("Setting")]
    public float moveSpeed = 5f;
    public float dashPower = 10f;

    public Rigidbody2D _rigid { get; private set; }

    protected float _XMove;
    private float _YMove;

    private Agent _onwer;

    public void Initialize(Agent agent)
    {
        _onwer = agent;
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void GetMoveMent(float _xMove, float _yMove)
    {
        _XMove = _xMove;
        _YMove = _yMove;
    }

    public void MoveStop(bool isStop = false)
    {
        _XMove = 0;
        if(isStop)
        {
            _rigid.velocity = Vector2.zero;
        }
        else
        {
            _rigid.velocity = new Vector2(_XMove, _YMove);
        }
    }

}
