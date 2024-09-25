using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField] private Transform _backGround_Y;
    private Player _player;

    private void Start()
    {
        _player = GameManager.Instance.Player;
    }

    private void Update()
    {


        if(PlayerPositionIsRight())
        {
            
            if (transform.position.x > _backGround_Y.position.x) //현재 배경이 다른 배경보다 오른쪽에 있을떄
            {
                _backGround_Y.position = new Vector3((transform.position.x * 2) + _backGround_Y.position.x, transform.position.y, transform.position.z); //현재 배경 x값에 자신의 x값 만큼 더함 (오른쪽으로 이동)
            }

            if (transform.position.x < _backGround_Y.position.x)//현재 배경이 다른 배경보다 왼쪽에 있을떄
            {
                _backGround_Y.position = new Vector3(-((transform.position.x * 2) + _backGround_Y.position.x), transform.position.y, transform.position.z);//현재 배경 x값에 자신의 x값 만큼 빼줌 (왼쪽으로 이동)

            }
        }
        else
        {
            if (transform.position.x > _backGround_Y.position.x) //현재 배경이 다른 배경보다 오른쪽에 있을떄
            {
                _backGround_Y.position = new Vector3((transform.position.x * 2) + _backGround_Y.position.x, transform.position.y, transform.position.z); //현재 배경 x값에 자신의 x값 만큼 더함 (오른쪽으로 이동)
            }

            if (transform.position.x < _backGround_Y.position.x)//현재 배경이 다른 배경보다 왼쪽에 있을떄
            {
                _backGround_Y.position = new Vector3(-((transform.position.x * 2) + _backGround_Y.position.x), transform.position.y, transform.position.z);//현재 배경 x값에 자신의 x값 만큼 빼줌 (왼쪽으로 이동)

            }
        }
    }

    private bool PlayerPositionIsRight()
    {
        return transform.position.x < _player.transform.position.x;
    }
}
