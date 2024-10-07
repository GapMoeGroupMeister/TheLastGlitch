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

    private void OnEnable()
    {
        _playTimeText.SetText($"��Ƴ��� �ð� : {playTime.ToString("F1")}");
        _haveCoinText.SetText($"���� ���� : {haveCoin}");
        StartCoroutine(ClickWating());
    }

    public IEnumerator ClickWating()
    {
        while (true)
        {
            yield return null;
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                LoadingSceneManager.LoadScene("MenuScene");
                break;
            }
        }
    }
}
