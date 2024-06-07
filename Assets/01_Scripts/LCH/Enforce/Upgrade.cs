using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] protected WeaponDataSO _weapon;
    

    private void Start()
    {
        
        _weapon = FindAnyObjectByType<WeaponManager>()._weaponQueue.Last();
    }
    public void WeaponUpgrade()
    {
        switch (_weapon._count)
        {
            case 0:
                _weapon._damage += _weapon._damage / 8;
                Debug.Log("¾Ó");
                break;
            case 1:
                _weapon._damage += _weapon._damage / 6;
                Debug.Log("±â");
                break;
            case 2:
                _weapon._damage += _weapon._damage * 2;
                Debug.Log("¸ð");
                break;
            default:
                
                return;
        }
        _weapon._count++;
        Debug.Log("¶ì");




    }
}
