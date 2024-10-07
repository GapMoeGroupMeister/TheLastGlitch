using System.Collections.Generic;
using UnityEngine;

public enum PlayerTypeEnum
{
    None,
    PowerPlayer,
    SpeedPlayer
}
public class PlayerSpawner : MonoBehaviour
{
    public PlayerTypeEnum playerTypeEnum;

    public List<GameObject> playerList;

    private void Awake()
    {
        playerTypeEnum = DataManager.Instance.PlayerType;


        switch (playerTypeEnum)
        {
            case PlayerTypeEnum.PowerPlayer:
                Instantiate(playerList[0], transform.position, Quaternion.identity);
                break;
            case PlayerTypeEnum.SpeedPlayer:
                Instantiate(playerList[1], transform.position, Quaternion.identity);
                break;
        }

    }
}
