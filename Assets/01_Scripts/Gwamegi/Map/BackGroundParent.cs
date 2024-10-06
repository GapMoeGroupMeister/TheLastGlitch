using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundParent : MonoBehaviour
{
    private Player _player;
    private void Start()
    {
        _player = GameManager.Instance.Player;
    }

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, transform.position.y, transform.position.z);
    }
}
