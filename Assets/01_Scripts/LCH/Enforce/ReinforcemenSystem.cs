using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReinforcemenSystem : MonoBehaviour
{
    [SerializeField] GameObject Reinforcementexplanation;
    [SerializeField] GameObject[] ReinforceButton;
    public UnityEvent LevelButton;
    private void Start()
    {
        Reinforcementexplanation.SetActive(false);
        for(int i=1; i<ReinforceButton.Length; i++)
        {
            ReinforceButton[i].SetActive(false);
        }
    }
    private void Update()
    {
        
    }

    private void LevelButtonClik()
    {
        Reinforcementexplanation.SetActive(true);
    }
}
