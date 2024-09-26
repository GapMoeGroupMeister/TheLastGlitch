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
                Debug.LogError("플레이어가 존재하지 않습니다 / Not Find Player");
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
