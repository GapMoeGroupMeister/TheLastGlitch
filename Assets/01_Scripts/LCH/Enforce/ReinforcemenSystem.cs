using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReinforcemenSystem : MonoBehaviour
{
    [SerializeField] private GameObject _Description;
    [SerializeField] private GameObject[] _reinforceButton;
    [SerializeField] private GameObject[] _treeIine;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private GameObject _effectPrefab;
    [SerializeField] private Transform[] _effectPos;
    public int UpgradeCount = 0;
    private void Start()
    {
        _Description.SetActive(false);
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
        _Description.SetActive(true);
    }

    public void LevelUpClik()
    {
        GameObject effectObj = Instantiate(_effectPrefab, _effectPos[UpgradeCount]);
        _effect.Play();    
        _treeIine[UpgradeCount].SetActive(true);
        UpgradeCount += 1;
        _reinforceButton[UpgradeCount].SetActive(true);
    }
}
