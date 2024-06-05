using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReinforcemenSystem : MonoBehaviour
{
    [SerializeField] private GameObject _reinforcementexplanation;
    [SerializeField] private GameObject[] _reinforceButton;
    [SerializeField] private GameObject[] _treeIine;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private GameObject _effectPrefab;
    [SerializeField] private Transform _effectPos;
    [SerializeField] private int _count = 0;
    private void Start()
    {
        _reinforcementexplanation.SetActive(false);
        for(int i= 1; i<_reinforceButton.Length; i++)
        {
            _reinforceButton[i].SetActive(false);
        }
        for(int i= 0; i<_treeIine.Length; i++)
        {
            _treeIine[i].SetActive(false);
        }
        gameObject.SetActive(false);
    }
    public void LevelButtonClik()
    {
        _reinforcementexplanation.SetActive(true);
    }

    public void LevelUpClik()
    {
        GameObject effectObj = Instantiate(_effectPrefab, _effectPos);
        _effect.Play();    

        _reinforcementexplanation.SetActive(false);
        _treeIine[_count].SetActive(true);
        _count += 1;
        _reinforceButton[_count].SetActive(true);
    }
}
