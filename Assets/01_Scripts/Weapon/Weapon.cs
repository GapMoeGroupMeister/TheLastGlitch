using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public UnityEvent OnWeaponChanged;
    public WeaponDataSO _weaponData;

    private void Awake()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ �������
        
    }

    public void WeaponChange()
    {
        _weaponData = GetComponentInParent<WeaponManager>()._weaponQueue.Last();
    }

}
