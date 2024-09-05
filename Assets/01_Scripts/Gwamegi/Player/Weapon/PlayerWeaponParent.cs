using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Gun,
    Katana,
    Knife,
    BigSword
}

public abstract class PlayerWeaponParent : MonoBehaviour
{
    /// <summary>
    /// 기본 데미지
    /// </summary>
    public float damage = 20f;
    /// <summary>
    /// 넉백 파워
    /// </summary>
    public float knockBackPower = 20f;
    /// <summary>
    /// 치명타 배율
    /// </summary>
    [Range(0,4)] public float criticalHit;
    /// <summary>
    /// 치명타 확률
    /// </summary>
    [Range(0,100)] public float criticalhHitProbability;

    public WeaponType type;

}
