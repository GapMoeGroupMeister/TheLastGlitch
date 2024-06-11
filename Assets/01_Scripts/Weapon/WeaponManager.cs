using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Queue<WeaponDataSO> _weaponQueue;
    [SerializeField] protected WeaponDataSO _defaltWeapon;
    [SerializeField] protected WeaponDataSO _tempWeapon;
    [SerializeField] protected WeaponDataSO _selectedWeapon;

    private void Awake()
    {
        _defaltWeapon = GetComponentInChildren<Weapon>()._weaponData;

        _weaponQueue = new Queue<WeaponDataSO>();
        _weaponQueue.Enqueue(_defaltWeapon);
        _weaponQueue.Enqueue(_tempWeapon);
        
        
    }
    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && _weaponQueue.Count > 1)
        {
            WeaponDataSO secondWeapon = _weaponQueue.Dequeue();
            _selectedWeapon = secondWeapon;
            _weaponQueue.Enqueue(secondWeapon);
        }
    }




}
