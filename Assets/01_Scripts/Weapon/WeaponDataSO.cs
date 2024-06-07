using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "SO/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    
    public Sprite _image;

    [Header("Tooltip")]
    public string _toolTip;
    [Header("State")]
    public string _name;
    public float _damage;
    public float _attackSpeed;
    public Vector2 _attackRange;
    public float _stunTime;
    [Header("UseSmithy")]
    public int _upGrandePrice;
    public int _needIngredients;
    public int _count;
    [Header("UseShop")]
    public int _price;
    
}
