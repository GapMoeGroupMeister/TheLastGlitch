using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIEnum
{
    MoveUI,
    EnableUI,
}

[CreateAssetMenu(menuName = "SO/UISet")]
public class UISet : ScriptableObject
{
    public UIEnum uiSet;
    public float moveSpeed;
    public int startPosition;
    public int endPosition;
    

}
