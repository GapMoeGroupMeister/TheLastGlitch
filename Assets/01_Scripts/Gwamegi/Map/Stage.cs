using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.Player.gameObject.SetActive(true);
        GameManager.Instance.Player.MovementComponent._canMove = true;
        WeaponCoolTime.instance._attack = false;

    }
}
