using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.Player.gameObject.SetActive(false);
        WeaponCoolTime.instance._attack = true;
    }
}
