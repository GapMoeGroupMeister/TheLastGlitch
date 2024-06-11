using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Queue<WeaponDataSO> _weaponQueue;
    [SerializeField] protected WeaponDataSO _defaltWeapon;

    private void Awake()
    {
        _defaltWeapon = GetComponentInChildren<Weapon>()._weaponData;

        _weaponQueue = new Queue<WeaponDataSO>();
        _weaponQueue.Enqueue(_defaltWeapon);
        
        
    }
    private void Update()
    {
        if (Input.GetButtonDown("Mouse ScrollWheel") && _weaponQueue.Count > 1)
        {
            WeaponDataSO secondWeapon = _weaponQueue.Dequeue();
            _weaponQueue.Append(secondWeapon);
        }
    }




}
