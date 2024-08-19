using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Player/PlayerList")]
public class PlayerList : ScriptableObject
{
    public List<Player> playerlist = new List<Player>();
}
