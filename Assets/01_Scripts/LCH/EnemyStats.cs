using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Enemy/Stats"))]
public class EnemyStats : ScriptableObject
{
	public int EnemyHeath;

	public int EnemydetectRadius;

	public int EnemyattackRadius;

	public int Enemydamge;

	public int EnemyknockbackPower;

	public int EnemyattackCooldown;

	public float EnemystopRay;

}
