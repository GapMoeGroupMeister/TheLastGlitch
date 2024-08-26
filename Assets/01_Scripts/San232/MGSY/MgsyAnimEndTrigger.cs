using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyAnimEndTrigger : MonoBehaviour
{
    [SerializeField] private MGSY _mgsy;

    private void Awake()
    {
        _mgsy = gameObject.transform.parent.GetComponent<MGSY>();
    }

    public void OpeningEnd()
    {
        float standardHealth = _mgsy.HealthComponent._maxHealth * 0.5f;
        float currentHealth = _mgsy.HealthComponent.GetCurrentHP();

        if (currentHealth >= standardHealth)
        {
            _mgsy.StateMachine.ChangeState(BossStateEnum.Opened);
        }
        else if (currentHealth < standardHealth)
        {
            _mgsy.StateMachine.ChangeState(BossStateEnum.AngryOpened);
        }
    }
}
