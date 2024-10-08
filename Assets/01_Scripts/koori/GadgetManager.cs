using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GadgetManager : MonoSingleton<GadgetManager>
{
    [SerializeField] private  GameObject _dopingPre, _hackPulsePre, _aedPre, _shieldPre, _rocketPre;
    internal void GadgetChange(GadgetType newGadget)
    {
        PlayerItemData.Instance.CurrentGadget = newGadget;
    }

    private void Start()
    {
        
    }

    private void InitGadget()
    {
        switch (PlayerItemData.Instance.CurrentGadget)
        {
            case GadgetType.None:break;
            case GadgetType.doping:   break;
        }
    }
}
