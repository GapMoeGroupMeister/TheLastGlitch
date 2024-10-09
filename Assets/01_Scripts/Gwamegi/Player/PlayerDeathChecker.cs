using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathChecker : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    private GameOver _gameOver;
    private Timer _playTimer;

    private void OnEnable()
    {
        _inputReader.playerController.Enable();
        _gameOver = FindAnyObjectByType<GameOver>();
        _playTimer = FindAnyObjectByType<Timer>();

        if(_gameOver != null)
            _gameOver.gameObject.SetActive(false);
    }


    public void Die()
    {
        DataManager.Instance.money += (int)_playTimer._timer * 10;
        PlayerItemData.Instance.SaveGadgetDataToJson();
        _playTimer.isGameOver = true;
        _gameOver.playTime = _playTimer._timer;
        _gameOver.haveCoin = (int)_playTimer._timer * 10;
        _inputReader.playerController.Disable();
        _gameOver.gameObject.SetActive(true);
        gameObject.GetComponent<Health>().ResetHealth();
        gameObject.SetActive(false);
    }
}
