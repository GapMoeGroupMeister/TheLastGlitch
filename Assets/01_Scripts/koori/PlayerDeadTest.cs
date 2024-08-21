using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadTest : MonoBehaviour
{
    [SerializeField] private Player1 Player;
    [SerializeField] private GameObject text;

    private void Start()
    {
        text.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Player._isDead = true;
            text.SetActive(true);
        }
    }
}
