using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimEndTrigger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void AnimationEnd()
    {
        _enemy.AnimationEndTrigger();
    }
}
