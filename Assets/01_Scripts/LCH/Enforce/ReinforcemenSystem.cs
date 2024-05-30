using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReinforcemenSystem : MonoBehaviour
{
    [SerializeField] GameObject Reinforcementexplanation;
    [SerializeField] GameObject[] ReinforceButton;
    [SerializeField] GameObject[] TreeIine;
    [SerializeField] private int Count = 0;
    private void Start()
    {
        Reinforcementexplanation.SetActive(false);
        for(int i=1; i<ReinforceButton.Length; i++)
        {
            ReinforceButton[i].SetActive(false);
        }
        for(int i= 0; i<TreeIine.Length; i++)
        {
            TreeIine[i].SetActive(false);
        }
    }
    public void LevelButtonClik()
    {
        Reinforcementexplanation.SetActive(true);
    }

    public void LevelUpClik()
    {
        Reinforcementexplanation.SetActive(false);
        TreeIine[Count].SetActive(true);
        Count += 1;
        ReinforceButton[Count].SetActive(true);
    }
}
