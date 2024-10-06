using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GadgetManager : MonoSingleton<GadgetManager>
{
    internal void GadgetChange(GadgetType newGadget)
    {
        DataManager.Instance.SelectedGadget = newGadget;
    }
}
