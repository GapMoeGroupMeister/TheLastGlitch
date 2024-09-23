using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField] private Transform _backGround;
    private Player _player;
    private Vector3 point1, point2;

    private void Awake()
    {
        point1 = new Vector3(_backGround.position.x, _backGround.position.y); // ¿À¸¥ÂÊ
        point2 = new Vector3(-_backGround.position.x, _backGround.position.y); // ¿ÞÂÊ
    }

    private void Start()
    {
        _player = GameManager.Instance.Player;
    }

    private void Update()
    {
        if(PlayerPositionIsRight())
        {
            _backGround.position = point1;
        }
        else
        {
            _backGround.position = point2;
        }
    }

    private bool PlayerPositionIsRight()
    {
        return transform.position.x < _player.transform.position.x;
    }
}
