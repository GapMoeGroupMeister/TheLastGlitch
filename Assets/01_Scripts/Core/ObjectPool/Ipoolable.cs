using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ipoolable
{
    public string ItemName { get; }
    public GameObject ObjectPrefab { get; }
    public void ResetItem();
}
