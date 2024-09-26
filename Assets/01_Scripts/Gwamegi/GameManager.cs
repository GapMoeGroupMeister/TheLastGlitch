using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private Player player;
    private Enemy _enemy;
    private bool isClear;

    private void Start()
    {
        _enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
    }

    public Player Player
    {

        get 
        {
            return player;
        }
        set 
        {
            if(value == null)
            {
                Debug.LogError("�÷��̾ �������� �ʽ��ϴ� / Not Find Player");
            }
            else
            {
                player = value;
            }
        }
    }

    private void Update()
    {
        if(_enemy == null)
        {
            isClear = true;
        }
    }

    public void Initialize()
    {
        Player = FindObjectOfType<Player>();
    }
}
