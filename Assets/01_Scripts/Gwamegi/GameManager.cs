using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private Player player;
    private bool isClear;

    [SerializeField] private GameObject _playerObject;

    private void Awake()
    {
        var obj = FindObjectsOfType<GameManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Player = _playerObject.GetComponent<Player>();

        //if(Player != null) return;
        //Player = FindObjectOfType<Player>();
        //Player.gameObject.SetActive(false);
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


}
