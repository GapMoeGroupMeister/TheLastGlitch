using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameOver : MonoBehaviour
{
    [SerializeField] private RectTransform _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _haveCoinText;
    [SerializeField] private TextMeshProUGUI _playTimeText;

    public int haveCoin;
    public float playTime;

    private void Update()
    {
        if (GameManager.Instance.Player.IsDie)
        {
            _gameOverPanel.gameObject.SetActive(true);
            _playTimeText.SetText($"살아남은 시간 : {playTime}");
            _haveCoinText.SetText($"얻은 코인 : {haveCoin}");
        }
    }

    public IEnumerator ClickWating()
    {
        while (true)
        {
            yield return null;
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                LoadingSceneManager.LoadScene("Title");
                break;
            }
        }
    }
}
