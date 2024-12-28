using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doping : MonoBehaviour
{
    [SerializeField] private float _dopedMoveSpeed;
    [SerializeField] private float _dopedAtkPower;
    [SerializeField] private float _dopedCritDamage;
    [SerializeField] private float _dopedCritProbability;
    [SerializeField] private float _moveNuff;
    [SerializeField] private float _atkNuff;
    [SerializeField] private float _critNuff;
    [SerializeField] private float _critProbabilityNuff;
    [SerializeField] private float _dopeTime;
    private Stat _dopedStat;
    private Stat _nuffStat;
    private void Start()
    {
        StartCoroutine(Dope());
    }

    private void StatUp()
    {
        _dopedStat = new Stat();
        _dopedStat.atkPower += _dopedAtkPower;
        _dopedStat.critDamage += _dopedCritDamage;
        _dopedStat.critProbability += _dopedCritProbability;
        _dopedStat.moveSpeed += _dopedMoveSpeed;
        GameManager.Instance.Player.GetComponent<PlayerStat>().StatSet(_dopedStat);
    }

    private void HighRisk()
    {
        _nuffStat = new Stat();
        _nuffStat.critProbability -= (_dopedCritProbability + _critProbabilityNuff);
        _nuffStat.atkPower -= (_dopedAtkPower + _atkNuff);
        _nuffStat.critDamage -=( _dopedCritDamage + _critNuff);
        _nuffStat.moveSpeed -= (_dopedMoveSpeed + _moveNuff);
        GameManager.Instance.Player.GetComponent<PlayerStat>().StatSet(_nuffStat);
    }

    private IEnumerator Dope()
    {
        StatUp();
        yield return new WaitForSeconds(_dopeTime);
        HighRisk();
        Destroy(gameObject);
    }
}
