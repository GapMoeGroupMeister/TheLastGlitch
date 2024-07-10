using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private LchTestPlayer _player;
    public static PlayerManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
    }
    public LchTestPlayer Player
    {
        get
        {
            if(_player == null)
            {
                _player = FindAnyObjectByType<LchTestPlayer>();
            }
            return _player;
        }
    }

    public Transform PlayerTrm => _player.transform;
}
