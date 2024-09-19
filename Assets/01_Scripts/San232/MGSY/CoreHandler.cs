using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreHandler : MGSYPattern
{
    [SerializeField] private List<Core> cores = new List<Core>();

    private void Awake()
    {
        Init(PatternTypeEnum.CoreBomb, this);
    }

    protected override void PatternStart()
    {
        foreach (Core core in cores)
        {
            core.CoreExplode();
        }
    }
}
