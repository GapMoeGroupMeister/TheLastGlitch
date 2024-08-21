using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponCoolTime : MonoBehaviour
{
    public static WeaponCoolTime instance;

    public bool _attack = false;

    public bool _player1Gun;
    public bool _player1Knife;

    public bool _player2BigSword;
    public bool _player2Katana;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
