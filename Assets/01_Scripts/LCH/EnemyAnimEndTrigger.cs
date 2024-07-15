using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimEndTrigger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    public UnityEvent OnAnimationEvent;

    private void AnimationEnd()
    {
        
    }
}
