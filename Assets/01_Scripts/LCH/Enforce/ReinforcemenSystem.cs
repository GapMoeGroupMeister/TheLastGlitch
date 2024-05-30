using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReinforcemenSystem : MonoBehaviour
{
    [SerializeField] GameObject _reinforcementexplanation;
    [SerializeField] GameObject[] _reinforceButton;
    [SerializeField] GameObject[] _treeIine;
    [SerializeField] private int _count = 0;
    private void Start()
    {
        _reinforcementexplanation.SetActive(false);
        for(int i=1; i<_reinforceButton.Length; i++)
        {
            _reinforceButton[i].SetActive(false);
        }
        for(int i= 0; i<_treeIine.Length; i++)
        {
            _treeIine[i].SetActive(false);
        }
    }
    public void LevelButtonClik()
    {
        _reinforcementexplanation.SetActive(true);
    }

    public void LevelUpClik()
    {
        _reinforcementexplanation.SetActive(false);
        _treeIine[_count].SetActive(true);
        _count += 1;
        _reinforceButton[_count].SetActive(true);
    }
}
