using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCoolTime : MonoBehaviour
{
    public static WeaponCoolTime instance;

    public bool _attack = false;

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
