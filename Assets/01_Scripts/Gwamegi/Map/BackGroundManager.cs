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
            
            if (transform.position.x > _backGround_Y.position.x) //���� ����� �ٸ� ��溸�� �����ʿ� ������
            {
                _backGround_Y.position = new Vector3((transform.position.x * 2) + _backGround_Y.position.x, transform.position.y, transform.position.z); //���� ��� x���� �ڽ��� x�� ��ŭ ���� (���������� �̵�)
            }

            if (transform.position.x < _backGround_Y.position.x)//���� ����� �ٸ� ��溸�� ���ʿ� ������
            {
                _backGround_Y.position = new Vector3(-((transform.position.x * 2) + _backGround_Y.position.x), transform.position.y, transform.position.z);//���� ��� x���� �ڽ��� x�� ��ŭ ���� (�������� �̵�)

            }
        }
        else
        {
            if (transform.position.x > _backGround_Y.position.x) //���� ����� �ٸ� ��溸�� �����ʿ� ������
            {
                _backGround_Y.position = new Vector3((transform.position.x * 2) + _backGround_Y.position.x, transform.position.y, transform.position.z); //���� ��� x���� �ڽ��� x�� ��ŭ ���� (���������� �̵�)
            }

            if (transform.position.x < _backGround_Y.position.x)//���� ����� �ٸ� ��溸�� ���ʿ� ������
            {
                _backGround_Y.position = new Vector3(-((transform.position.x * 2) + _backGround_Y.position.x), transform.position.y, transform.position.z);//���� ��� x���� �ڽ��� x�� ��ŭ ���� (�������� �̵�)

            }
        }
    }

    private bool PlayerPositionIsRight()
    {
        return transform.position.x < _player.transform.position.x;
    }
}
