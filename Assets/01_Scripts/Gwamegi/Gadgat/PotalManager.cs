using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalManager : MonoSingleton<PotalManager>
{
    public bool isRed = false;
    public bool isWarp = true;

    public Vector2 _redPotalTranform;
    public Vector2 _bluePotalTranform;

    public BluePotal bluePotal;
    public RedPotal redPotal;
}
