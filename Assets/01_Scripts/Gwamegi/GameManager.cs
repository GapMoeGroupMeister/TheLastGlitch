using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private Player player;

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

    private void Awake()
    {
        Player = FindObjectOfType<Player>();
    }
}
