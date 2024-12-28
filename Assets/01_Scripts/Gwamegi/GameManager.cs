using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Player player;
    private bool isClear;

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
