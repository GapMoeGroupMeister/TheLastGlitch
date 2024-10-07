using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathChecker : MonoBehaviour
{
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Timer _playTimer;



    public void Die()
    {
        _gameOver.playTime = _playTimer._timer;
        _gameOver.haveCoin = (int)_playTimer._timer;
        _inputReader.playerController.Disable();
        _gameOver.gameObject.SetActive(true);
        StartCoroutine(_gameOver.ClickWating());

        Destroy(gameObject);
    }
}
