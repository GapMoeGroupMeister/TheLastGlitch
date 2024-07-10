using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private TestPlayer _player;
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
    public TestPlayer Player
    {
        get
        {
            if(_player == null)
            {
                _player = FindAnyObjectByType<TestPlayer>();
            }
            return _player;
        }
    }

    public Transform PlayerTrm => _player.transform;
}
