using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private Player player;
    private bool isClear;

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


    public void Initialize()
    {
        Player = FindObjectOfType<Player>();
    }
}
