using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerTypeEnum
{
    PowerPlayer,
    SpeedPlayer
}
public class PlayerSpawner : MonoBehaviour
{
    public PlayerTypeEnum playerTypeEnum;

    

    private void OnEnable()
    {
        
    }
}
