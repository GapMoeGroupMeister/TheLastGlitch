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
    /// �⺻ ������
    /// </summary>
    public float damage = 20f;
    /// <summary>
    /// �˹� �Ŀ�
    /// </summary>
    public float knockBackPower = 20f;
    /// <summary>
    /// ġ��Ÿ ����
    /// </summary>
    [Range(0,4)] public float criticalHit;
    /// <summary>
    /// ġ��Ÿ Ȯ��
    /// </summary>
    [Range(0,100)] public float criticalhHitProbability;

    public WeaponType type;

}
