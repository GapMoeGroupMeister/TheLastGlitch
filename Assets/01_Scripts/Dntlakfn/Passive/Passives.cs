using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Passives : MonoBehaviour
{
    /* Todo
     * 
     * 플래이어 완성되면 페시브 고른거 3개 구현하기
     */



    private Player player;

    private void Awake()
    {
        player = FindAnyObjectByType<Player>();
    }

    public bool _isEquipped = false;

    public abstract void ActivePassive();

    public abstract void InactivePassive();


}
